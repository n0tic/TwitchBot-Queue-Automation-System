namespace TwitchBotQueue.Forms
{
    partial class OptionsForm
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
            this.input_botName = new MetroFramework.Controls.MetroTextBox();
            this.input_oAuth = new MetroFramework.Controls.MetroTextBox();
            this.input_channelName = new MetroFramework.Controls.MetroTextBox();
            this.input_host = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.input_port = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.input_port)).BeginInit();
            this.SuspendLayout();
            // 
            // input_botName
            // 
            this.input_botName.Location = new System.Drawing.Point(23, 89);
            this.input_botName.Name = "input_botName";
            this.input_botName.Size = new System.Drawing.Size(266, 23);
            this.input_botName.TabIndex = 0;
            this.input_botName.Text = "YourBotNameIdentifier";
            // 
            // input_oAuth
            // 
            this.input_oAuth.Location = new System.Drawing.Point(23, 137);
            this.input_oAuth.Name = "input_oAuth";
            this.input_oAuth.PasswordChar = '*';
            this.input_oAuth.Size = new System.Drawing.Size(266, 23);
            this.input_oAuth.TabIndex = 1;
            this.input_oAuth.Text = "oauth:FullAuthKeyHere";
            // 
            // input_channelName
            // 
            this.input_channelName.Location = new System.Drawing.Point(23, 202);
            this.input_channelName.Name = "input_channelName";
            this.input_channelName.Size = new System.Drawing.Size(266, 23);
            this.input_channelName.TabIndex = 2;
            this.input_channelName.Text = "bert_ika";
            // 
            // input_host
            // 
            this.input_host.Location = new System.Drawing.Point(23, 279);
            this.input_host.Name = "input_host";
            this.input_host.Size = new System.Drawing.Size(266, 23);
            this.input_host.TabIndex = 3;
            this.input_host.Text = "irc.chat.twitch.tv";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(23, 67);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(80, 19);
            this.metroLabel5.TabIndex = 21;
            this.metroLabel5.Text = "Bot Name:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 115);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 19);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "oAuth Key:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(23, 180);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(117, 19);
            this.metroLabel2.TabIndex = 23;
            this.metroLabel2.Text = "Channel To Join:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(23, 257);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(44, 19);
            this.metroLabel3.TabIndex = 24;
            this.metroLabel3.Text = "Host:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(23, 305);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(42, 19);
            this.metroLabel4.TabIndex = 25;
            this.metroLabel4.Text = "Port:";
            // 
            // input_port
            // 
            this.input_port.Location = new System.Drawing.Point(23, 327);
            this.input_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.input_port.Name = "input_port";
            this.input_port.Size = new System.Drawing.Size(266, 20);
            this.input_port.TabIndex = 26;
            this.input_port.Value = new decimal(new int[] {
            6667,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(20, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "https://twitchapps.com/tmi/";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(214, 353);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 28);
            this.metroButton1.TabIndex = 28;
            this.metroButton1.Text = "Save";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(23, 353);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 28);
            this.metroButton2.TabIndex = 29;
            this.metroButton2.Text = "Close";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(313, 396);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_port);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.input_host);
            this.Controls.Add(this.input_channelName);
            this.Controls.Add(this.input_oAuth);
            this.Controls.Add(this.input_botName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Resizable = false;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.input_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroTextBox input_botName;
        public MetroFramework.Controls.MetroTextBox input_oAuth;
        public MetroFramework.Controls.MetroTextBox input_channelName;
        public MetroFramework.Controls.MetroTextBox input_host;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        public System.Windows.Forms.NumericUpDown input_port;
    }
}