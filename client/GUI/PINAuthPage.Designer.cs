﻿namespace ATM
{
    partial class loginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginPage));
            this.bankIcon = new System.Windows.Forms.Label();
            this.greetingText = new System.Windows.Forms.Label();
            this.messagePIN = new System.Windows.Forms.Label();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.thePIN = new System.Windows.Forms.Label();
            this.bankName = new System.Windows.Forms.Label();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.WrongPINMessage = new System.Windows.Forms.Label();
            this.fbground = new System.Windows.Forms.Panel();
            this.fbground.SuspendLayout();
            this.SuspendLayout();
            // 
            // bankIcon
            // 
            this.bankIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bankIcon.AutoSize = true;
            this.bankIcon.BackColor = System.Drawing.Color.Transparent;
            this.bankIcon.Image = ((System.Drawing.Image)(resources.GetObject("bankIcon.Image")));
            this.bankIcon.Location = new System.Drawing.Point(530, 20);
            this.bankIcon.MinimumSize = new System.Drawing.Size(110, 60);
            this.bankIcon.Name = "bankIcon";
            this.bankIcon.Size = new System.Drawing.Size(110, 60);
            this.bankIcon.TabIndex = 3;
            // 
            // greetingText
            // 
            this.greetingText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.greetingText.AutoSize = true;
            this.greetingText.BackColor = System.Drawing.Color.Transparent;
            this.greetingText.Font = new System.Drawing.Font("Rockwell", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greetingText.Location = new System.Drawing.Point(382, 163);
            this.greetingText.Name = "greetingText";
            this.greetingText.Size = new System.Drawing.Size(225, 54);
            this.greetingText.TabIndex = 4;
            this.greetingText.Text = "Hi Stacy !";
            // 
            // messagePIN
            // 
            this.messagePIN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.messagePIN.AutoSize = true;
            this.messagePIN.BackColor = System.Drawing.Color.Transparent;
            this.messagePIN.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagePIN.Location = new System.Drawing.Point(299, 302);
            this.messagePIN.Name = "messagePIN";
            this.messagePIN.Size = new System.Drawing.Size(157, 22);
            this.messagePIN.TabIndex = 5;
            this.messagePIN.Text = "Please enter PIN";
            this.messagePIN.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPIN
            // 
            this.txtPIN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPIN.Location = new System.Drawing.Point(512, 304);
            this.txtPIN.MaxLength = 4;
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.PasswordChar = '*';
            this.txtPIN.Size = new System.Drawing.Size(118, 22);
            this.txtPIN.TabIndex = 6;
            this.txtPIN.TextChanged += new System.EventHandler(this.txtPIN_TextChanged);
            // 
            // thePIN
            // 
            this.thePIN.BackColor = System.Drawing.Color.Transparent;
            this.thePIN.Font = new System.Drawing.Font("Rockwell", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thePIN.Location = new System.Drawing.Point(681, 292);
            this.thePIN.Name = "thePIN";
            this.thePIN.Size = new System.Drawing.Size(160, 52);
            this.thePIN.TabIndex = 7;
            this.thePIN.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // ErrorMessage
            // 
            this.ErrorMessage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.ErrorMessage.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ErrorMessage.Image = global::ATMClient.GUI.Properties.Resources.SideText_image1;
            this.ErrorMessage.Location = new System.Drawing.Point(580, 405);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(435, 80);
            this.ErrorMessage.TabIndex = 9;
            this.ErrorMessage.Text = "\r\nPlease input 4 digits\r\n";
            this.ErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorMessage.Visible = false;
            // 
            // WrongPINMessage
            // 
            this.WrongPINMessage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WrongPINMessage.BackColor = System.Drawing.Color.Transparent;
            this.WrongPINMessage.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WrongPINMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.WrongPINMessage.Image = global::ATMClient.GUI.Properties.Resources.SideText_image1;
            this.WrongPINMessage.Location = new System.Drawing.Point(580, 405);
            this.WrongPINMessage.Name = "WrongPINMessage";
            this.WrongPINMessage.Size = new System.Drawing.Size(435, 80);
            this.WrongPINMessage.TabIndex = 10;
            this.WrongPINMessage.Text = "Please try again";
            this.WrongPINMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WrongPINMessage.Visible = false;
            // 
            // fbground
            // 
            this.fbground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbground.BackColor = System.Drawing.Color.Transparent;
            this.fbground.BackgroundImage = global::ATMClient.GUI.Properties.Resources.fbg_image;
            this.fbground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fbground.Controls.Add(this.bankIcon);
            this.fbground.Controls.Add(this.bankName);
            this.fbground.Location = new System.Drawing.Point(0, 0);
            this.fbground.Name = "fbground";
            this.fbground.Size = new System.Drawing.Size(990, 115);
            this.fbground.TabIndex = 11;
            // 
            // loginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ATMClient.GUI.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.fbground);
            this.Controls.Add(this.WrongPINMessage);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.thePIN);
            this.Controls.Add(this.txtPIN);
            this.Controls.Add(this.messagePIN);
            this.Controls.Add(this.greetingText);
            this.DoubleBuffered = true;
            this.Name = "loginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PIN Authentication";
            this.Load += new System.EventHandler(this.loginPage_Load);
            this.fbground.ResumeLayout(false);
            this.fbground.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Label greetingText;
        private System.Windows.Forms.Label messagePIN;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.Label thePIN;
        private System.Windows.Forms.Label bankName;
        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.Label WrongPINMessage;
        private System.Windows.Forms.Panel fbground;
    }
}