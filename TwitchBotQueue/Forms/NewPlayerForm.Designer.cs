namespace TwitchBotQueue.Forms
{
    partial class NewPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Inputfield_playername = new MetroFramework.Controls.MetroTextBox();
            this.AddPlayerButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Inputfield_playername
            // 
            this.Inputfield_playername.Location = new System.Drawing.Point(23, 63);
            this.Inputfield_playername.Name = "Inputfield_playername";
            this.Inputfield_playername.Size = new System.Drawing.Size(163, 23);
            this.Inputfield_playername.TabIndex = 0;
            this.Inputfield_playername.Text = "Playername...";
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.Location = new System.Drawing.Point(110, 96);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(76, 24);
            this.AddPlayerButton.TabIndex = 1;
            this.AddPlayerButton.Text = "Add Player";
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(23, 96);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(76, 24);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel Player";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NewPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(216, 132);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddPlayerButton);
            this.Controls.Add(this.Inputfield_playername);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPlayer";
            this.Resizable = false;
            this.Text = "Add New Player";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton AddPlayerButton;
        private MetroFramework.Controls.MetroButton CancelButton;
        public MetroFramework.Controls.MetroTextBox Inputfield_playername;
    }
}