namespace ATM
{
    partial class FingerAuthPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FingerAuthPage));
			this.BankName = new System.Windows.Forms.Label();
			this.bankIcon = new System.Windows.Forms.Label();
			this.thumbPrint = new System.Windows.Forms.Label();
			this.greatMessage = new System.Windows.Forms.Label();
			this.FingerScanMessage = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fbground = new System.Windows.Forms.Panel();
			this.DebugText = new System.Windows.Forms.Label();
			this.fbground.SuspendLayout();
			this.SuspendLayout();
			// 
			// BankName
			// 
			this.BankName.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.BankName.AutoSize = true;
			this.BankName.BackColor = System.Drawing.Color.Transparent;
			this.BankName.Font = new System.Drawing.Font("Rockwell", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BankName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.BankName.Location = new System.Drawing.Point(266, 12);
			this.BankName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BankName.Name = "BankName";
			this.BankName.Size = new System.Drawing.Size(146, 54);
			this.BankName.TabIndex = 2;
			this.BankName.Text = "HSBC";
			// 
			// bankIcon
			// 
			this.bankIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.bankIcon.AutoSize = true;
			this.bankIcon.BackColor = System.Drawing.Color.Transparent;
			this.bankIcon.Image = ((System.Drawing.Image)(resources.GetObject("bankIcon.Image")));
			this.bankIcon.Location = new System.Drawing.Point(398, 16);
			this.bankIcon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bankIcon.MinimumSize = new System.Drawing.Size(82, 49);
			this.bankIcon.Name = "bankIcon";
			this.bankIcon.Size = new System.Drawing.Size(82, 49);
			this.bankIcon.TabIndex = 4;
			// 
			// thumbPrint
			// 
			this.thumbPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.thumbPrint.BackColor = System.Drawing.Color.Transparent;
			this.thumbPrint.Image = global::ATMClient.GUI.Properties.Resources.ThumbPrint;
			this.thumbPrint.Location = new System.Drawing.Point(17, 143);
			this.thumbPrint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.thumbPrint.Name = "thumbPrint";
			this.thumbPrint.Size = new System.Drawing.Size(222, 184);
			this.thumbPrint.TabIndex = 5;
			// 
			// greatMessage
			// 
			this.greatMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.greatMessage.AutoSize = true;
			this.greatMessage.BackColor = System.Drawing.Color.Transparent;
			this.greatMessage.Font = new System.Drawing.Font("Rockwell", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.greatMessage.Location = new System.Drawing.Point(308, 134);
			this.greatMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.greatMessage.Name = "greatMessage";
			this.greatMessage.Size = new System.Drawing.Size(128, 42);
			this.greatMessage.TabIndex = 6;
			this.greatMessage.Text = "Great!";
			// 
			// FingerScanMessage
			// 
			this.FingerScanMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.FingerScanMessage.AutoSize = true;
			this.FingerScanMessage.BackColor = System.Drawing.Color.Transparent;
			this.FingerScanMessage.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FingerScanMessage.Location = new System.Drawing.Point(225, 230);
			this.FingerScanMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.FingerScanMessage.Name = "FingerScanMessage";
			this.FingerScanMessage.Size = new System.Drawing.Size(324, 19);
			this.FingerScanMessage.TabIndex = 7;
			this.FingerScanMessage.Text = "You must now verify your identity using the fingerprint scanner.";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.label1.Image = global::ATMClient.GUI.Properties.Resources.SideText_image1;
			this.label1.Location = new System.Drawing.Point(412, 324);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(326, 81);
			this.label1.TabIndex = 8;
			this.label1.Text = "\r\nClick here to begin.\r\n";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// fbground
			// 
			this.fbground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fbground.BackColor = System.Drawing.Color.Transparent;
			this.fbground.BackgroundImage = global::ATMClient.GUI.Properties.Resources.fbg_image;
			this.fbground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.fbground.Controls.Add(this.bankIcon);
			this.fbground.Controls.Add(this.BankName);
			this.fbground.Location = new System.Drawing.Point(0, 0);
			this.fbground.Margin = new System.Windows.Forms.Padding(2);
			this.fbground.Name = "fbground";
			this.fbground.Size = new System.Drawing.Size(742, 93);
			this.fbground.TabIndex = 10;
			// 
			// DebugText
			// 
			this.DebugText.AutoSize = true;
			this.DebugText.BackColor = System.Drawing.SystemColors.ControlDark;
			this.DebugText.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DebugText.Location = new System.Drawing.Point(39, 360);
			this.DebugText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.DebugText.Name = "DebugText";
			this.DebugText.Size = new System.Drawing.Size(0, 25);
			this.DebugText.TabIndex = 11;
			// 
			// FingerAuthPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(736, 449);
			this.Controls.Add(this.DebugText);
			this.Controls.Add(this.fbground);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.FingerScanMessage);
			this.Controls.Add(this.greatMessage);
			this.Controls.Add(this.thumbPrint);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FingerAuthPage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Finger Authentication";
			this.Load += new System.EventHandler(this.FingerAuthPage_Load);
			this.fbground.ResumeLayout(false);
			this.fbground.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BankName;
        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Label thumbPrint;
        private System.Windows.Forms.Label greatMessage;
        private System.Windows.Forms.Label FingerScanMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel fbground;
        private System.Windows.Forms.Label DebugText;
    }
}