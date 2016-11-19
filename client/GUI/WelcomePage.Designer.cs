namespace ATM
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendName = new System.Windows.Forms.Button();
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
            this.bankName.Location = new System.Drawing.Point(355, 15);
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
            this.bankIcon.Image = global::ATMClient.GUI.Properties.Resources.HSVC_image1;
            this.bankIcon.Location = new System.Drawing.Point(530, 20);
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
            this.cardIcon.BackColor = System.Drawing.Color.Transparent;
            this.cardIcon.Image = global::ATMClient.GUI.Properties.Resources.Card1;
            this.cardIcon.Location = new System.Drawing.Point(242, 320);
            this.cardIcon.MinimumSize = new System.Drawing.Size(100, 100);
            this.cardIcon.Name = "cardIcon";
            this.cardIcon.Size = new System.Drawing.Size(156, 100);
            this.cardIcon.TabIndex = 3;
            this.cardIcon.Click += new System.EventHandler(this.cardIcon_Click);
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
            this.moveOn.Location = new System.Drawing.Point(691, 198);
            this.moveOn.Name = "moveOn";
            this.moveOn.Size = new System.Drawing.Size(242, 326);
            this.moveOn.TabIndex = 5;
            this.moveOn.UseVisualStyleBackColor = false;
            this.moveOn.Click += new System.EventHandler(this.moveOn_Click);
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
            this.fbground.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(728, 474);
            this.textBox1.MinimumSize = new System.Drawing.Size(4, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(600, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "**Demo ID**";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // sendName
            // 
            this.sendName.BackColor = System.Drawing.Color.Transparent;
            this.sendName.BackgroundImage = global::ATMClient.GUI.Properties.Resources.fbg_image;
            this.sendName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendName.FlatAppearance.BorderSize = 0;
            this.sendName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.sendName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.sendName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendName.Location = new System.Drawing.Point(858, 470);
            this.sendName.Name = "sendName";
            this.sendName.Size = new System.Drawing.Size(75, 31);
            this.sendName.TabIndex = 9;
            this.sendName.Text = "Submit";
            this.sendName.UseVisualStyleBackColor = false;
            this.sendName.Click += new System.EventHandler(this.sendName_Click);
            // 
            // welcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ATMClient.GUI.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.sendName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendName;
    }
}

