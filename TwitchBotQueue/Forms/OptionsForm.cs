using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using TwitchBotQueue.Data;

namespace TwitchBotQueue.Forms
{
    public partial class OptionsForm : MetroForm
    {
        public OptionsForm(Options options)
        {
            InitializeComponent();
            input_botName.Text = options.botName;
            input_channelName.Text = options.channelName;
            input_oAuth.Text = options.password;
            input_host.Text = options.host;
            input_port.Value = options.port;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitchapps.com/tmi/");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(input_botName.Text) && !string.IsNullOrEmpty(input_channelName.Text) && !string.IsNullOrEmpty(input_oAuth.Text) && !string.IsNullOrEmpty(input_host.Text) && input_port.Value >= 1 && input_port.Value <= 65535)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No field can be empty. Port needs to be between 1 and 65535.", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
