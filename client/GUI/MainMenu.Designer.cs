namespace ATM
{
    partial class MainMenu
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
            this.fbground = new System.Windows.Forms.Panel();
            this.bankIcon = new System.Windows.Forms.Label();
            this.bankName = new System.Windows.Forms.Label();
            this.WithdrawBtn = new System.Windows.Forms.Button();
            this.DepositBtn = new System.Windows.Forms.Button();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.AccSettingBtn = new System.Windows.Forms.Button();
            this.CheckBalBtn = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.changePINBtn = new System.Windows.Forms.Button();
            this.fbground.SuspendLayout();
            this.SuspendLayout();
            // 
            // fbground
            // 
            this.fbground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbground.BackgroundImage = global::ATMClient.GUI.Properties.Resources.fbg_image;
            this.fbground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fbground.Controls.Add(this.bankIcon);
            this.fbground.Controls.Add(this.bankName);
            this.fbground.Location = new System.Drawing.Point(0, 0);
            this.fbground.Name = "fbground";
            this.fbground.Size = new System.Drawing.Size(990, 115);
            this.fbground.TabIndex = 0;
            // 
            // bankIcon
            // 
            this.bankIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bankIcon.AutoSize = true;
            this.bankIcon.BackColor = System.Drawing.Color.Transparent;
            this.bankIcon.Image = global::ATMClient.GUI.Properties.Resources.HSVC_image1;
            this.bankIcon.Location = new System.Drawing.Point(530, 20);
            this.bankIcon.MinimumSize = new System.Drawing.Size(110, 60);
            this.bankIcon.Name = "bankIcon";
            this.bankIcon.Size = new System.Drawing.Size(110, 60);
            this.bankIcon.TabIndex = 3;
            // 
            // bankName
            // 
            this.bankName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bankName.AutoSize = true;
            this.bankName.BackColor = System.Drawing.Color.Transparent;
            this.bankName.Font = new System.Drawing.Font("Rockwell", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bankName.Location = new System.Drawing.Point(355, 15);
            this.bankName.Name = "bankName";
            this.bankName.Size = new System.Drawing.Size(184, 68);
            this.bankName.TabIndex = 2;
            this.bankName.Text = "HSBC";
            // 
            // WithdrawBtn
            // 
            this.WithdrawBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WithdrawBtn.BackColor = System.Drawing.Color.Transparent;
            this.WithdrawBtn.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.WithdrawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WithdrawBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WithdrawBtn.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WithdrawBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.WithdrawBtn.Location = new System.Drawing.Point(143, 220);
            this.WithdrawBtn.Name = "WithdrawBtn";
            this.WithdrawBtn.Size = new System.Drawing.Size(237, 60);
            this.WithdrawBtn.TabIndex = 1;
            this.WithdrawBtn.Text = "Withdrawal";
            this.WithdrawBtn.UseVisualStyleBackColor = false;
            this.WithdrawBtn.Click += new System.EventHandler(this.WithdrawBtn_Click);
            // 
            // DepositBtn
            // 
            this.DepositBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepositBtn.BackColor = System.Drawing.Color.Transparent;
            this.DepositBtn.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.DepositBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DepositBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DepositBtn.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepositBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.DepositBtn.Location = new System.Drawing.Point(570, 220);
            this.DepositBtn.Name = "DepositBtn";
            this.DepositBtn.Size = new System.Drawing.Size(237, 60);
            this.DepositBtn.TabIndex = 7;
            this.DepositBtn.Text = "Deposit";
            this.DepositBtn.UseVisualStyleBackColor = false;
            this.DepositBtn.Click += new System.EventHandler(this.DepositBtn_Click);
            // 
            // HelpBtn
            // 
            this.HelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBtn.BackColor = System.Drawing.Color.Transparent;
            this.HelpBtn.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.HelpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HelpBtn.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.HelpBtn.Location = new System.Drawing.Point(822, 492);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(148, 49);
            this.HelpBtn.TabIndex = 8;
            this.HelpBtn.Text = "Help";
            this.HelpBtn.UseVisualStyleBackColor = false;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // AccSettingBtn
            // 
            this.AccSettingBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AccSettingBtn.BackColor = System.Drawing.Color.Transparent;
            this.AccSettingBtn.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.AccSettingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AccSettingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AccSettingBtn.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccSettingBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.AccSettingBtn.Location = new System.Drawing.Point(570, 415);
            this.AccSettingBtn.Name = "AccSettingBtn";
            this.AccSettingBtn.Size = new System.Drawing.Size(237, 60);
            this.AccSettingBtn.TabIndex = 9;
            this.AccSettingBtn.TabStop = false;
            this.AccSettingBtn.Text = "Account Settings";
            this.AccSettingBtn.UseVisualStyleBackColor = false;
            this.AccSettingBtn.Click += new System.EventHandler(this.AccSettingBtn_Click);
            // 
            // CheckBalBtn
            // 
            this.CheckBalBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckBalBtn.BackColor = System.Drawing.Color.Transparent;
            this.CheckBalBtn.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.CheckBalBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CheckBalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckBalBtn.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBalBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.CheckBalBtn.Location = new System.Drawing.Point(143, 319);
            this.CheckBalBtn.Name = "CheckBalBtn";
            this.CheckBalBtn.Size = new System.Drawing.Size(237, 60);
            this.CheckBalBtn.TabIndex = 10;
            this.CheckBalBtn.Text = "Check Balance";
            this.CheckBalBtn.UseVisualStyleBackColor = false;
            this.CheckBalBtn.Click += new System.EventHandler(this.CheckBalBtn_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogOutBtn.BackColor = System.Drawing.Color.Transparent;
            this.LogOutBtn.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.LogOutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogOutBtn.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.LogOutBtn.Location = new System.Drawing.Point(143, 415);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(237, 60);
            this.LogOutBtn.TabIndex = 11;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = false;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // changePINBtn
            // 
            this.changePINBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changePINBtn.BackColor = System.Drawing.Color.Transparent;
            this.changePINBtn.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.changePINBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changePINBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changePINBtn.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePINBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.changePINBtn.Location = new System.Drawing.Point(570, 319);
            this.changePINBtn.Name = "changePINBtn";
            this.changePINBtn.Size = new System.Drawing.Size(237, 60);
            this.changePINBtn.TabIndex = 12;
            this.changePINBtn.Text = "Change PIN";
            this.changePINBtn.UseVisualStyleBackColor = false;
            this.changePINBtn.Click += new System.EventHandler(this.changePINBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::ATMClient.GUI.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.changePINBtn);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.CheckBalBtn);
            this.Controls.Add(this.AccSettingBtn);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.DepositBtn);
            this.Controls.Add(this.WithdrawBtn);
            this.Controls.Add(this.fbground);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.fbground.ResumeLayout(false);
            this.fbground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fbground;
        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Label bankName;
        private System.Windows.Forms.Button WithdrawBtn;
        private System.Windows.Forms.Button DepositBtn;
        private System.Windows.Forms.Button HelpBtn;
        private System.Windows.Forms.Button AccSettingBtn;
        private System.Windows.Forms.Button CheckBalBtn;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Button changePINBtn;
    }
}