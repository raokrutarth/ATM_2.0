namespace ATM
{
    partial class changePIN
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bankIcon = new System.Windows.Forms.Label();
            this.bankName = new System.Windows.Forms.Label();
            this.changePINtext = new System.Windows.Forms.Label();
            this.newPIN1 = new System.Windows.Forms.TextBox();
            this.changePIN1Label = new System.Windows.Forms.Label();
            this.changePIN2Label = new System.Windows.Forms.Label();
            this.newPIN2 = new System.Windows.Forms.TextBox();
            this.invalidPINMessage = new System.Windows.Forms.Label();
            this.unequalPINMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::ATMClient.GUI.Properties.Resources.fbg_image;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.bankIcon);
            this.panel1.Controls.Add(this.bankName);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 115);
            this.panel1.TabIndex = 0;
            // 
            // bankIcon
            // 
            this.bankIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            // changePINtext
            // 
            this.changePINtext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changePINtext.AutoSize = true;
            this.changePINtext.BackColor = System.Drawing.Color.Transparent;
            this.changePINtext.Font = new System.Drawing.Font("Rockwell", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePINtext.Location = new System.Drawing.Point(372, 172);
            this.changePINtext.Name = "changePINtext";
            this.changePINtext.Size = new System.Drawing.Size(228, 42);
            this.changePINtext.TabIndex = 1;
            this.changePINtext.Text = "Change PIN";
            // 
            // newPIN1
            // 
            this.newPIN1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newPIN1.Location = new System.Drawing.Point(498, 275);
            this.newPIN1.MaxLength = 4;
            this.newPIN1.Name = "newPIN1";
            this.newPIN1.PasswordChar = '*';
            this.newPIN1.Size = new System.Drawing.Size(162, 23);
            this.newPIN1.TabIndex = 2;
            this.newPIN1.TextChanged += new System.EventHandler(this.newPIN1_TextChanged);
            // 
            // changePIN1Label
            // 
            this.changePIN1Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changePIN1Label.AutoSize = true;
            this.changePIN1Label.BackColor = System.Drawing.Color.Transparent;
            this.changePIN1Label.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePIN1Label.Location = new System.Drawing.Point(334, 276);
            this.changePIN1Label.Name = "changePIN1Label";
            this.changePIN1Label.Size = new System.Drawing.Size(140, 22);
            this.changePIN1Label.TabIndex = 3;
            this.changePIN1Label.Text = "Enter New PIN";
            this.changePIN1Label.Click += new System.EventHandler(this.changePIN1Label_Click);
            // 
            // changePIN2Label
            // 
            this.changePIN2Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changePIN2Label.AutoSize = true;
            this.changePIN2Label.BackColor = System.Drawing.Color.Transparent;
            this.changePIN2Label.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePIN2Label.Location = new System.Drawing.Point(314, 329);
            this.changePIN2Label.Name = "changePIN2Label";
            this.changePIN2Label.Size = new System.Drawing.Size(160, 22);
            this.changePIN2Label.TabIndex = 5;
            this.changePIN2Label.Text = "Repeat New PIN ";
            // 
            // newPIN2
            // 
            this.newPIN2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newPIN2.Location = new System.Drawing.Point(498, 330);
            this.newPIN2.MaxLength = 4;
            this.newPIN2.Name = "newPIN2";
            this.newPIN2.PasswordChar = '*';
            this.newPIN2.Size = new System.Drawing.Size(162, 23);
            this.newPIN2.TabIndex = 4;
            this.newPIN2.TextChanged += new System.EventHandler(this.newPIN2_TextChanged);
            // 
            // invalidPINMessage
            // 
            this.invalidPINMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.invalidPINMessage.BackColor = System.Drawing.Color.Transparent;
            this.invalidPINMessage.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidPINMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.invalidPINMessage.Image = global::ATMClient.GUI.Properties.Resources.SideText_image1;
            this.invalidPINMessage.Location = new System.Drawing.Point(571, 417);
            this.invalidPINMessage.Name = "invalidPINMessage";
            this.invalidPINMessage.Size = new System.Drawing.Size(435, 80);
            this.invalidPINMessage.TabIndex = 11;
            this.invalidPINMessage.Text = "Please only use the valid 0-9 digits";
            this.invalidPINMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.invalidPINMessage.Visible = false;
            // 
            // unequalPINMessage
            // 
            this.unequalPINMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unequalPINMessage.BackColor = System.Drawing.Color.Transparent;
            this.unequalPINMessage.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unequalPINMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.unequalPINMessage.Image = global::ATMClient.GUI.Properties.Resources.SideText_image1;
            this.unequalPINMessage.Location = new System.Drawing.Point(571, 417);
            this.unequalPINMessage.Name = "unequalPINMessage";
            this.unequalPINMessage.Size = new System.Drawing.Size(435, 80);
            this.unequalPINMessage.TabIndex = 12;
            this.unequalPINMessage.Text = "Please have PINs match";
            this.unequalPINMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unequalPINMessage.Visible = false;
            // 
            // changePIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ATMClient.GUI.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.unequalPINMessage);
            this.Controls.Add(this.invalidPINMessage);
            this.Controls.Add(this.changePIN2Label);
            this.Controls.Add(this.newPIN2);
            this.Controls.Add(this.changePIN1Label);
            this.Controls.Add(this.newPIN1);
            this.Controls.Add(this.changePINtext);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "changePIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "changePIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.changePIN_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Label bankName;
        private System.Windows.Forms.Label changePINtext;
        private System.Windows.Forms.TextBox newPIN1;
        private System.Windows.Forms.Label changePIN1Label;
        private System.Windows.Forms.Label changePIN2Label;
        private System.Windows.Forms.TextBox newPIN2;
        private System.Windows.Forms.Label invalidPINMessage;
        private System.Windows.Forms.Label unequalPINMessage;
    }
}