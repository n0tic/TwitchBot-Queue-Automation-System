namespace TwitchBotQueue
{
    partial class MainForm
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
            this.QueueList = new System.Windows.Forms.ListBox();
            this.UnQueuedList = new System.Windows.Forms.ListBox();
            this.UnQueuePlayer = new MetroFramework.Controls.MetroButton();
            this.ReQueuePlayer = new MetroFramework.Controls.MetroButton();
            this.AddPlayerButton = new MetroFramework.Controls.MetroButton();
            this.PlayerNameText = new MetroFramework.Controls.MetroLabel();
            this.PlayerQueuedText = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.PlayerQueuedText2 = new MetroFramework.Controls.MetroLabel();
            this.PlayerNameText2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.PlayerDeQueuedText2 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.StatusIndicator = new System.Windows.Forms.Label();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.StartBotButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // QueueList
            // 
            this.QueueList.FormattingEnabled = true;
            this.QueueList.Location = new System.Drawing.Point(23, 111);
            this.QueueList.Name = "QueueList";
            this.QueueList.Size = new System.Drawing.Size(164, 316);
            this.QueueList.TabIndex = 0;
            this.QueueList.SelectedValueChanged += new System.EventHandler(this.QueueList_SelectedValueChanged);
            // 
            // UnQueuedList
            // 
            this.UnQueuedList.FormattingEnabled = true;
            this.UnQueuedList.Location = new System.Drawing.Point(319, 176);
            this.UnQueuedList.Name = "UnQueuedList";
            this.UnQueuedList.Size = new System.Drawing.Size(164, 251);
            this.UnQueuedList.TabIndex = 1;
            this.UnQueuedList.SelectedValueChanged += new System.EventHandler(this.UnQueuedList_SelectedValueChanged);
            // 
            // UnQueuePlayer
            // 
            this.UnQueuePlayer.Location = new System.Drawing.Point(206, 208);
            this.UnQueuePlayer.Name = "UnQueuePlayer";
            this.UnQueuePlayer.Size = new System.Drawing.Size(93, 26);
            this.UnQueuePlayer.TabIndex = 2;
            this.UnQueuePlayer.Text = "Move Player -->";
            this.UnQueuePlayer.Click += new System.EventHandler(this.UnQueuePlayer_Click);
            // 
            // ReQueuePlayer
            // 
            this.ReQueuePlayer.Location = new System.Drawing.Point(206, 240);
            this.ReQueuePlayer.Name = "ReQueuePlayer";
            this.ReQueuePlayer.Size = new System.Drawing.Size(93, 26);
            this.ReQueuePlayer.TabIndex = 3;
            this.ReQueuePlayer.Text = "<-- Move Player";
            this.ReQueuePlayer.Click += new System.EventHandler(this.ReQueuePlayer_Click);
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.Highlight = true;
            this.AddPlayerButton.Location = new System.Drawing.Point(193, 176);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(120, 26);
            this.AddPlayerButton.TabIndex = 4;
            this.AddPlayerButton.Text = "Add Player Maunally";
            this.AddPlayerButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // PlayerNameText
            // 
            this.PlayerNameText.AutoSize = true;
            this.PlayerNameText.Location = new System.Drawing.Point(86, 63);
            this.PlayerNameText.Name = "PlayerNameText";
            this.PlayerNameText.Size = new System.Drawing.Size(85, 19);
            this.PlayerNameText.TabIndex = 5;
            this.PlayerNameText.Text = "Player Name";
            // 
            // PlayerQueuedText
            // 
            this.PlayerQueuedText.AutoSize = true;
            this.PlayerQueuedText.Location = new System.Drawing.Point(86, 82);
            this.PlayerQueuedText.Name = "PlayerQueuedText";
            this.PlayerQueuedText.Size = new System.Drawing.Size(96, 19);
            this.PlayerQueuedText.TabIndex = 6;
            this.PlayerQueuedText.Text = "Player Queued";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(57, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Player:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(23, 82);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Queued:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(319, 96);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(65, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Queued:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(319, 60);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(57, 19);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Player:";
            // 
            // PlayerQueuedText2
            // 
            this.PlayerQueuedText2.AutoSize = true;
            this.PlayerQueuedText2.Location = new System.Drawing.Point(319, 115);
            this.PlayerQueuedText2.Name = "PlayerQueuedText2";
            this.PlayerQueuedText2.Size = new System.Drawing.Size(96, 19);
            this.PlayerQueuedText2.TabIndex = 10;
            this.PlayerQueuedText2.Text = "Player Queued";
            // 
            // PlayerNameText2
            // 
            this.PlayerNameText2.AutoSize = true;
            this.PlayerNameText2.Location = new System.Drawing.Point(319, 79);
            this.PlayerNameText2.Name = "PlayerNameText2";
            this.PlayerNameText2.Size = new System.Drawing.Size(85, 19);
            this.PlayerNameText2.TabIndex = 9;
            this.PlayerNameText2.Text = "Player Name";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel8.Location = new System.Drawing.Point(319, 134);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(79, 19);
            this.metroLabel8.TabIndex = 15;
            this.metroLabel8.Text = "DeQueued";
            // 
            // PlayerDeQueuedText2
            // 
            this.PlayerDeQueuedText2.AutoSize = true;
            this.PlayerDeQueuedText2.Location = new System.Drawing.Point(319, 153);
            this.PlayerDeQueuedText2.Name = "PlayerDeQueuedText2";
            this.PlayerDeQueuedText2.Size = new System.Drawing.Size(85, 19);
            this.PlayerDeQueuedText2.TabIndex = 13;
            this.PlayerDeQueuedText2.Text = "Player Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TwitchBotQueue.Properties.Resources.iconfinder_Settings_2001888;
            this.pictureBox1.Location = new System.Drawing.Point(286, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TwitchBotQueue.Properties.Resources.iconfinder_Retract_2001886;
            this.pictureBox2.Location = new System.Drawing.Point(429, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TwitchBotQueue.Properties.Resources.iconfinder_Close_2001866;
            this.pictureBox3.Location = new System.Drawing.Point(455, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // StatusIndicator
            // 
            this.StatusIndicator.AutoSize = true;
            this.StatusIndicator.BackColor = System.Drawing.Color.Red;
            this.StatusIndicator.Location = new System.Drawing.Point(248, 384);
            this.StatusIndicator.Name = "StatusIndicator";
            this.StatusIndicator.Size = new System.Drawing.Size(10, 13);
            this.StatusIndicator.TabIndex = 19;
            this.StatusIndicator.Text = " ";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(193, 379);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(53, 19);
            this.metroLabel5.TabIndex = 20;
            this.metroLabel5.Text = "Status:";
            // 
            // StartBotButton
            // 
            this.StartBotButton.Highlight = true;
            this.StartBotButton.Location = new System.Drawing.Point(193, 401);
            this.StartBotButton.Name = "StartBotButton";
            this.StartBotButton.Size = new System.Drawing.Size(120, 26);
            this.StartBotButton.TabIndex = 21;
            this.StartBotButton.Text = "Start Bot";
            this.StartBotButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.StartBotButton.Click += new System.EventHandler(this.StartBotButton_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(71, 430);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(378, 19);
            this.metroLabel6.TabIndex = 22;
            this.metroLabel6.Text = "If the bot was successful there should be a message in the chat. ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.StartBotButton);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.StatusIndicator);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.PlayerDeQueuedText2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.PlayerQueuedText2);
            this.Controls.Add(this.PlayerNameText2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.PlayerQueuedText);
            this.Controls.Add(this.PlayerNameText);
            this.Controls.Add(this.AddPlayerButton);
            this.Controls.Add(this.ReQueuePlayer);
            this.Controls.Add(this.UnQueuePlayer);
            this.Controls.Add(this.UnQueuedList);
            this.Controls.Add(this.QueueList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "TwitchBot Queue System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox UnQueuedList;
        private MetroFramework.Controls.MetroButton UnQueuePlayer;
        private MetroFramework.Controls.MetroButton ReQueuePlayer;
        private MetroFramework.Controls.MetroButton AddPlayerButton;
        private MetroFramework.Controls.MetroLabel PlayerNameText;
        private MetroFramework.Controls.MetroLabel PlayerQueuedText;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel PlayerQueuedText2;
        private MetroFramework.Controls.MetroLabel PlayerNameText2;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel PlayerDeQueuedText2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label StatusIndicator;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton StartBotButton;
        public System.Windows.Forms.ListBox QueueList;
        private MetroFramework.Controls.MetroLabel metroLabel6;
    }
}

