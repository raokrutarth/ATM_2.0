namespace Banking_UI
{
    partial class welcomePage
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
            this.bankName = new System.Windows.Forms.Label();
            this.bankIcon = new System.Windows.Forms.Label();
            this.welcomeMessage = new System.Windows.Forms.Label();
            this.cardIcon = new System.Windows.Forms.Label();
            this.Insert_Message = new System.Windows.Forms.Label();
            this.moveOn = new System.Windows.Forms.Button();
            this.fbground = new System.Windows.Forms.Panel();
            this.fbground.SuspendLayout();
            this.SuspendLayout();
            // 
            // bankName
            // 
            this.bankName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bankName.AutoSize = true;
            this.bankName.BackColor = System.Drawing.Color.Transparent;
            this.bankName.Font = new System.Drawing.Font("Rockwell", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bankName.Location = new System.Drawing.Point(360, 27);
            this.bankName.Name = "bankName";
            this.bankName.Size = new System.Drawing.Size(184, 68);
            this.bankName.TabIndex = 0;
            this.bankName.Text = "HSBC";
            // 
            // bankIcon
            // 
            this.bankIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bankIcon.AutoSize = true;
            this.bankIcon.BackColor = System.Drawing.Color.Transparent;
            this.bankIcon.Image = global::Banking_UI.Properties.Resources.HSVC_image1;
            this.bankIcon.Location = new System.Drawing.Point(535, 35);
            this.bankIcon.MinimumSize = new System.Drawing.Size(110, 60);
            this.bankIcon.Name = "bankIcon";
            this.bankIcon.Size = new System.Drawing.Size(110, 60);
            this.bankIcon.TabIndex = 1;
            // 
            // welcomeMessage
            // 
            this.welcomeMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.welcomeMessage.AutoSize = true;
            this.welcomeMessage.BackColor = System.Drawing.Color.Transparent;
            this.welcomeMessage.Font = new System.Drawing.Font("Rockwell", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMessage.Location = new System.Drawing.Point(244, 163);
            this.welcomeMessage.Name = "welcomeMessage";
            this.welcomeMessage.Size = new System.Drawing.Size(484, 54);
            this.welcomeMessage.TabIndex = 2;
            this.welcomeMessage.Text = "Welcome to ATM 2.0";
            // 
            // cardIcon
            // 
            this.cardIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cardIcon.AutoSize = true;
            this.cardIcon.BackColor = System.Drawing.Color.Transparent;
            this.cardIcon.Image = global::Banking_UI.Properties.Resources.Card_image1;
            this.cardIcon.Location = new System.Drawing.Point(209, 267);
            this.cardIcon.MinimumSize = new System.Drawing.Size(200, 200);
            this.cardIcon.Name = "cardIcon";
            this.cardIcon.Size = new System.Drawing.Size(200, 200);
            this.cardIcon.TabIndex = 3;
            // 
            // Insert_Message
            // 
            this.Insert_Message.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Insert_Message.AutoSize = true;
            this.Insert_Message.BackColor = System.Drawing.Color.Transparent;
            this.Insert_Message.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_Message.Location = new System.Drawing.Point(404, 336);
            this.Insert_Message.Name = "Insert_Message";
            this.Insert_Message.Size = new System.Drawing.Size(270, 62);
            this.Insert_Message.TabIndex = 4;
            this.Insert_Message.Text = "Please insert card\r\nto begin transaction";
            // 
            // moveOn
            // 
            this.moveOn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moveOn.BackColor = System.Drawing.Color.Transparent;
            this.moveOn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.moveOn.FlatAppearance.BorderSize = 0;
            this.moveOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.moveOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.moveOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveOn.Location = new System.Drawing.Point(48, 24);
            this.moveOn.Name = "moveOn";
            this.moveOn.Size = new System.Drawing.Size(885, 500);
            this.moveOn.TabIndex = 5;
            this.moveOn.UseVisualStyleBackColor = false;
            this.moveOn.Click += new System.EventHandler(this.moveOn_Click);
            // 
            // fbground
            // 
            this.fbground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbground.BackColor = System.Drawing.Color.Transparent;
            this.fbground.BackgroundImage = global::Banking_UI.Properties.Resources.fbg_image;
            this.fbground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fbground.Controls.Add(this.bankIcon);
            this.fbground.Controls.Add(this.bankName);
            this.fbground.Location = new System.Drawing.Point(0, 0);
            this.fbground.Name = "fbground";
            this.fbground.Size = new System.Drawing.Size(992, 108);
            this.fbground.TabIndex = 6;
            // 
            // welcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Banking_UI.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.Insert_Message);
            this.Controls.Add(this.cardIcon);
            this.Controls.Add(this.welcomeMessage);
            this.Controls.Add(this.fbground);
            this.Controls.Add(this.moveOn);
            this.DoubleBuffered = true;
            this.Name = "welcomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.welcomePage_Load);
            this.fbground.ResumeLayout(false);
            this.fbground.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bankName;
        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Label welcomeMessage;
        private System.Windows.Forms.Label cardIcon;
        private System.Windows.Forms.Label Insert_Message;
        private System.Windows.Forms.Button moveOn;
        private System.Windows.Forms.Panel fbground;
    }
}

