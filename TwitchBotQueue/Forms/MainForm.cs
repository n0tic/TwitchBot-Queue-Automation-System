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
        public AutomationManager autoManager;

        public MainForm()
        {
            InitializeComponent();

            queue = new Queue(this);
            autoManager = new AutomationManager(this);

            LoadSettings();

            if (string.IsNullOrEmpty(options.botName) || string.IsNullOrEmpty(options.password) || string.IsNullOrEmpty(options.channelName) || string.IsNullOrEmpty(options.host) && options.port >= 1 && options.port <= 65535)
            {
                if (MessageBox.Show("It appears that this is the first time you are running this application. Setup is required.", "Setup Required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    SettingsButton_Click(null, EventArgs.Empty);
                }
            }

            // Empty all fields.
            PlayerNameText.Text = "";
            PlayerQueuedText.Text = "";

            PlayerNameText2.Text = "";
            PlayerQueuedText2.Text = "";
            PlayerDeQueuedText2.Text = "";

            metroTabControl1.SelectTab(0);
            metroTabControl2.SelectTab(0);
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

        public void RunAutomation(Automation automation) {
            this.Invoke(new Action(() => {
                if(twitchBot.twitchChat.Connected)
                    twitchBot.SendMsg(automation.message);
            }));
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
                    SettingsButton_Click(null, EventArgs.Empty);
                    return;
                }
            }

            if (twitchBot == null)
            {
                twitchBot = new TwitchChatBot(this, options.host, options.port, options.botName, options.password, options.channelName, true);
                autoManager.StartThreads();
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
                autoManager.KillThreads();

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

            autoList_SelectedIndexChanged(null, EventArgs.Empty);

            GC.Collect();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (twitchBot != null)
                twitchBot.KillThreads();

            autoManager.KillThreads();
        }

        private void autoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (autoList.SelectedItem != null)
                {
                    Automation auto = autoManager.GetAutomation(autoList.SelectedItem.ToString());
                    if(auto != null)
                    {
                        edit_AutomationNameInputfield.Text = auto.automationName;
                        edit_Minutes.SelectedItem = auto.interval.ToString();
                        edit_Active.Checked = auto.active;
                        edit_Message.Text = auto.message;

                        edit_AutomationNameInputfield.Enabled = true;
                        edit_Minutes.Enabled = true;
                        edit_Active.Enabled = true;
                        edit_Message.Enabled = true;

                        view_AutomationName.Text = auto.automationName;
                        view_AutomationInterval.Text = auto.interval.ToString() + " Minutes";
                        view_AutomationActive.Text = auto.active.ToString();

                        if (auto.running) view_AutomationRunningIndicator.BackColor = Color.Green;
                        else view_AutomationRunningIndicator.BackColor = Color.Red;

                        view_message.Text = auto.message;
                    }
                }
                else
                {
                    edit_AutomationNameInputfield.Text = "";
                    edit_Minutes.SelectedItem = "";
                    edit_Active.Checked = false;
                    edit_Message.Text = "";

                    edit_AutomationNameInputfield.Enabled = false;
                    edit_Minutes.Enabled = false;
                    edit_Active.Enabled = false;
                    edit_Message.Enabled = false;
                }
            }
            catch (System.Exception)
            {
                //Do nothing
            }
        }

        private void AutoMessageInputfield_TextChanged(object sender, EventArgs e)
        {
            CharLength.Text = "Characters: " + AutoMessageInputfield.Text.Length.ToString() + "/470";
            if (AutoMessageInputfield.Text.Length > 470 || AutoMessageInputfield.Text.Length <= 4)
                CharLength.ForeColor = Color.Red;
            else
                CharLength.ForeColor = Color.Black;
        }

        private void AddAutomationButton_Click(object sender, EventArgs e)
        {
            if (AddAutomationNameInputfield.Text.Length > 0 && AutoMessageInputfield.Text.Length <= 470 && AutoMessageInputfield.Text.Length > 4 && autoMinutes.SelectedItem != null && Int32.Parse(autoMinutes.SelectedItem.ToString()) >= 5)
            {
                if(autoManager.AddAutomation(AddAutomationNameInputfield.Text, Int32.Parse(autoMinutes.SelectedItem.ToString()), AutoMessageInputfield.Text, autoActive.Checked))
                {
                    AddAutomationNameInputfield.Text = "";
                    autoMinutes.SelectedIndex = -1;
                    autoMinutes.Focus();
                    autoActive.Checked = false;
                    AutoMessageInputfield.Text = "";
                }
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
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

        private void MinimizeButton_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void MainCloseButton_Click(object sender, EventArgs e) => Application.Exit();

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

        private void DeQueuePlayerButton_Click(object sender, EventArgs e)
        {
            try
            {
                UnQueuedList.Items.Add(QueueList.SelectedItem);
                queue.DeQueuePlayer(QueueList.SelectedItem.ToString());
                QueueList.Items.Remove(QueueList.SelectedItem);
            }
            catch (System.Exception)
            {
                //Do nothing
            }
        }

        private void ReQueuePlayerButton_Click(object sender, EventArgs e)
        {
            try
            {
                QueueList.Items.Add(UnQueuedList.SelectedItem);
                UnQueuedList.Items.Remove(UnQueuedList.SelectedItem);
            }
            catch (System.Exception)
            {
                //Do nothing
            }
        }

        private void edit_Message_TextChanged(object sender, EventArgs e)
        {
            edit_CharLength.Text = "Characters: " + edit_Message.Text.Length.ToString() + "/470";
            if (edit_Message.Text.Length > 470 || edit_Message.Text.Length <= 4)
                edit_CharLength.ForeColor = Color.Red;
            else
                edit_CharLength.ForeColor = Color.Black;
        }

        private void DeleteAutomationButton_Click(object sender, EventArgs e)
        {
            if (autoList.SelectedItem != null)
                autoManager.DeleteAutomation(autoList.SelectedItem.ToString());
        }

        private void manualStartAutomationButton_Click(object sender, EventArgs e)
        {
            if (twitchBot != null && twitchBot.twitchChat != null && twitchBot.twitchChat.Connected && autoList.SelectedItem != null)
            {
                Automation auto = autoManager.GetAutomation(autoList.SelectedItem.ToString());
                if (auto != null)
                {
                    if (auto.running && autoManager.timers[auto.threadIndex].Enabled)
                        return;

                    autoManager.Automation(AutomationManager.AutomationController.Start, autoList.SelectedItem.ToString());

                    autoList_SelectedIndexChanged(null, EventArgs.Empty);
                }
            }
        }

        private void manualStopAutomationButton_Click(object sender, EventArgs e)
        {
            if (twitchBot != null && twitchBot.twitchChat != null && twitchBot.twitchChat.Connected && autoList.SelectedItem != null)
            {
                Automation auto = autoManager.GetAutomation(autoList.SelectedItem.ToString());
                if (auto != null)
                {
                    MessageBox.Show(auto.automationName + " " + autoManager.timers[auto.threadIndex].Enabled.ToString());

                    if (!auto.running && !autoManager.timers[auto.threadIndex].Enabled)
                        return;

                    autoManager.Automation(AutomationManager.AutomationController.Stop, autoList.SelectedItem.ToString());

                    autoList_SelectedIndexChanged(null, EventArgs.Empty);
                }
            }
        }

        private void manualSendNowAutomationButton_Click(object sender, EventArgs e)
        {
            if (twitchBot != null && twitchBot.twitchChat != null && twitchBot.twitchChat.Connected && autoList.SelectedItem != null)
            {
                Automation auto = autoManager.GetAutomation(autoList.SelectedItem.ToString());
                if (auto != null)
                {
                    twitchBot.SendMsg(auto.message);
                }
            }
        }

        private void EditAutomationButton_Click(object sender, EventArgs e)
        {
            if (edit_AutomationNameInputfield.Text.Length > 0 && edit_Message.Text.Length <= 470 && edit_Message.Text.Length > 4 && edit_Minutes.SelectedItem != null && Int32.Parse(edit_Minutes.SelectedItem.ToString()) >= 5 && autoList.SelectedItem != null)
            {
                Automation auto = autoManager.GetAutomation(autoList.SelectedItem.ToString());
                if (auto != null)
                {
                    string prevString = autoList.SelectedItem.ToString();
                    string tmpString = edit_AutomationNameInputfield.Text;
                    if (tmpString.Length > 20) tmpString = tmpString.Substring(0, 20);

                    if(autoManager.DoesNameAlreadyExist(tmpString))
                    {
                        MessageBox.Show("This name does already exist. Try again.", "Name already exist!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }    

                    auto.automationName = tmpString;
                    auto.interval = Int32.Parse(edit_Minutes.SelectedItem.ToString());
                    auto.active = edit_Active.Checked;
                    auto.message = edit_Message.Text;

                    edit_AutomationNameInputfield.Text = "";
                    edit_Minutes.SelectedIndex = -1;
                    edit_Minutes.Focus();
                    edit_Active.Checked = false;
                    edit_Message.Text = "";

                    autoList.Items[autoList.Items.IndexOf(prevString)] = tmpString;
                }
            }
        }
    }
}
