using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace TwitchBotQueue.Forms
{
    public partial class NewPlayerForm : MetroForm
    {
        public NewPlayerForm()
        {
            InitializeComponent();

            Inputfield_playername.KeyDown += Inputfield_playername_KeyDown;
        }

        private void Inputfield_playername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => this.Close();

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
