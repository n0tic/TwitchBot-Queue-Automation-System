using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using MetroFramework.Forms;
using Microsoft.Win32;
using TwitchBot.Object;
using TwitchBotQueue.Data;
using TwitchBotQueue.Forms;

namespace TwitchBotQueue
{
    public partial class MainForm : MetroForm
    {
        public Queue queue;
        public Options options = new Options();
        public TwitchChatBot twitchBot;

        public MainForm()
        {
            InitializeComponent();

            queue = new Queue(this);

            LoadSettings();

            if (string.IsNullOrEmpty(options.botName) || string.IsNullOrEmpty(options.password) || string.IsNullOrEmpty(options.channelName) || string.IsNullOrEmpty(options.host) && options.port >= 1 && options.port <= 65535)
            {
                if (MessageBox.Show("It appears that this is the first time you are running this application. Setup is required.", "Setup Required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    pictureBox1_Click(null, EventArgs.Empty);
                }
            }

            // Empty all fields.
            PlayerNameText.Text = "";
            PlayerQueuedText.Text = "";

            PlayerNameText2.Text = "";
            PlayerQueuedText2.Text = "";
            PlayerDeQueuedText2.Text = "";
        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            NewPlayerForm np = new NewPlayerForm();
            if (np.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(np.Inputfield_playername.Text))
                {
                    Player player = queue.QueuePlayer(string.Concat(np.Inputfield_playername.Text.Where(char.IsLetterOrDigit)));
                    if (!string.IsNullOrEmpty(player.playerName))
                        QueueList.Items.Add(player.playerName);
                }
            }

            GC.Collect();
        }

        public void AddPlayerToQueue(string usr)
        {
            this.Invoke(new Action(() => {
                if (!string.IsNullOrEmpty(usr))
                {
                    Player player = queue.QueuePlayer(string.Concat(usr.Where(char.IsLetterOrDigit)));
                    if(!string.IsNullOrEmpty(player.playerName))
                    {
                        QueueList.Items.Add(usr);

                        if(QueueList.Items.Count == 1)
                            twitchBot.SendMsg("@" + usr + " - You have the next spot.");
                        else
                            twitchBot.SendMsg("@" + usr + " - You have spot " + QueueList.Items.Count.ToString() + " in list.");
                    }
                }
            }));
        }

        public void RemovePlayerFromQueue(string usr)
        {
            this.Invoke(new Action(() => {
                if (!string.IsNullOrEmpty(usr))
                {
                    QueueList.Items.Remove(usr);
                    queue.DeQueuePlayer(usr);
                }
            }));
        }

        private void UnQueuePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                UnQueuedList.Items.Add(QueueList.SelectedItem);
                queue.DeQueuePlayer(QueueList.SelectedItem.ToString());
                QueueList.Items.Remove(QueueList.SelectedItem);
            }
            catch(System.Exception)
            {
                //Do nothing
            }
        }

        private void ReQueuePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                QueueList.Items.Add(UnQueuedList.SelectedItem);
                UnQueuedList.Items.Remove(UnQueuedList.SelectedItem);
            }
            catch(System.Exception)
            {
                //Do nothing
            }
}

        private void QueueList_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(QueueList.SelectedItem != null)
                {
                    PlayerNameText.Text = QueueList.SelectedItem.ToString();
                    Player player = queue.GetPlayer(PlayerNameText.Text);
                    if (!string.IsNullOrEmpty(player.playerName))
                        PlayerQueuedText.Text = player.queueTime.ToString();
                }
                else
                {
                    PlayerNameText.Text = "";
                    PlayerQueuedText.Text = "";
                }
            }
            catch(System.Exception)
            {
                //Do nothing
            }
        }

        private void UnQueuedList_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (UnQueuedList.SelectedItem != null)
                {
                    PlayerNameText2.Text = UnQueuedList.SelectedItem.ToString();
                    Player player = queue.GetPlayer(PlayerNameText2.Text);
                    if (!string.IsNullOrEmpty(player.playerName))
                        PlayerQueuedText2.Text = player.queueTime.ToString();
                    if (!string.IsNullOrEmpty(player.playerName))
                        PlayerDeQueuedText2.Text = player.unQueuedTime.ToString();
                }
                else
                {
                    PlayerNameText2.Text = "";
                    PlayerQueuedText2.Text = "";
                    PlayerDeQueuedText2.Text = "";
                }
            }
            catch (System.Exception)
            {
                //Do nothing
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (twitchBot != null)
            {
                twitchBot.KillThreads();

                if (twitchBot.twitchChat.Connected)
                {
                    StatusIndicator.BackColor = Color.Green;
                    StartBotButton.Text = "Stop Bot";
                }
                else
                {
                    StatusIndicator.BackColor = Color.Red;
                    StartBotButton.Text = "Start Bot";
                }

                twitchBot = null;
            }

            OptionsForm ow = new OptionsForm(options);
            if (ow.ShowDialog() == DialogResult.OK)
            {
                options.botName = ow.input_botName.Text;
                options.channelName = ow.input_channelName.Text;
                options.password = ow.input_oAuth.Text;
                options.host = ow.input_host.Text;
                options.port = (int)ow.input_port.Value;
                SaveSettings();
                LoadSettings();
            }

            GC.Collect();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void LoadSettings()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TwitchBotQueueSystem");

                if (key != null)
                {
                    options.botName = key.GetValue("botName").ToString();
                    options.channelName = key.GetValue("channelName").ToString();
                    options.password = key.GetValue("oAuth").ToString();
                    options.host = key.GetValue("host").ToString();
                    options.port = Int32.Parse(key.GetValue("port").ToString());

                    key.Close();
                }
            }
            catch (Exception) { MessageBox.Show("Unknown error occured when loading settings. Try again..."); }
        }

        private void SaveSettings()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\TwitchBotQueueSystem");

                if (key != null)
                {
                    key.SetValue("botName", options.botName, RegistryValueKind.String);
                    key.SetValue("channelName", options.channelName, RegistryValueKind.String);
                    key.SetValue("oAuth", options.password, RegistryValueKind.String);
                    key.SetValue("host", options.host, RegistryValueKind.String);
                    key.SetValue("port", options.port.ToString(), RegistryValueKind.String);

                    key.Close();
                }
            }
            catch (Exception) { MessageBox.Show("Unknown error occured when saving settings. Try again..."); }
        }

        private void StartBotButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(options.botName) || string.IsNullOrEmpty(options.password) || string.IsNullOrEmpty(options.channelName) || string.IsNullOrEmpty(options.host) && options.port >= 1 && options.port <= 65535)
            {
                if (MessageBox.Show("It appears that the setup have blank fields. That is not allowed.", "Setup Required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    pictureBox1_Click(null, EventArgs.Empty);
                    return;
                }
            }

            if (twitchBot == null)
            {
                twitchBot = new TwitchChatBot(this, options.host, options.port, options.botName, options.password, options.channelName, true);
                if (twitchBot.twitchChat.Connected)
                {
                    StatusIndicator.BackColor = Color.Green;
                    StartBotButton.Text = "Stop Bot";
                }
                else
                {
                    StatusIndicator.BackColor = Color.Red;
                    StartBotButton.Text = "Start Bot";
                }
            }
            else
            {
                twitchBot.KillThreads();

                if (twitchBot.twitchChat.Connected)
                {
                    StatusIndicator.BackColor = Color.Green;
                    StartBotButton.Text = "Stop Bot";
                }
                else
                {
                    StatusIndicator.BackColor = Color.Red;
                    StartBotButton.Text = "Start Bot";
                }

                twitchBot = null;
            }

            GC.Collect();
        }
    }
}
