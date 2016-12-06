namespace ATM
{
    partial class withdrawPage
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
            this.bankIcon = new System.Windows.Forms.Label();
            this.bankName = new System.Windows.Forms.Label();
            this.fbground = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cashCount = new System.Windows.Forms.TextBox();
            this.singleButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.withdrawButton = new System.Windows.Forms.Button();
            this.hundredButton = new System.Windows.Forms.Button();
            this.fiftyButton = new System.Windows.Forms.Button();
            this.twentyButton = new System.Windows.Forms.Button();
            this.tenButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.fbground.SuspendLayout();
            this.SuspendLayout();
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
            this.fbground.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "How much would you like?";
            // 
            // cashCount
            // 
            this.cashCount.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashCount.Location = new System.Drawing.Point(277, 201);
            this.cashCount.Name = "cashCount";
            this.cashCount.ReadOnly = true;
            this.cashCount.Size = new System.Drawing.Size(387, 39);
            this.cashCount.TabIndex = 5;
            this.cashCount.Text = "$0";
            this.cashCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // singleButton
            // 
            this.singleButton.BackColor = System.Drawing.Color.Transparent;
            this.singleButton.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.singleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.singleButton.FlatAppearance.BorderSize = 0;
            this.singleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.singleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.singleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singleButton.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleButton.Location = new System.Drawing.Point(277, 267);
            this.singleButton.Name = "singleButton";
            this.singleButton.Size = new System.Drawing.Size(140, 50);
            this.singleButton.TabIndex = 6;
            this.singleButton.Text = "$1";
            this.singleButton.UseVisualStyleBackColor = false;
            this.singleButton.Click += new System.EventHandler(this.singleButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackgroundImage = global::ATMClient.Properties.Resources.cancel_button;
            this.clearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(713, 441);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(140, 50);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // withdrawButton
            // 
            this.withdrawButton.BackgroundImage = global::ATMClient.Properties.Resources.accept_button;
            this.withdrawButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.withdrawButton.FlatAppearance.BorderSize = 0;
            this.withdrawButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.withdrawButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withdrawButton.Location = new System.Drawing.Point(713, 270);
            this.withdrawButton.Name = "withdrawButton";
            this.withdrawButton.Size = new System.Drawing.Size(140, 50);
            this.withdrawButton.TabIndex = 8;
            this.withdrawButton.Text = "Withdraw";
            this.withdrawButton.UseVisualStyleBackColor = true;
            // 
            // hundredButton
            // 
            this.hundredButton.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.hundredButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hundredButton.FlatAppearance.BorderSize = 0;
            this.hundredButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hundredButton.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hundredButton.Location = new System.Drawing.Point(524, 441);
            this.hundredButton.Name = "hundredButton";
            this.hundredButton.Size = new System.Drawing.Size(140, 50);
            this.hundredButton.TabIndex = 9;
            this.hundredButton.Text = "$100";
            this.hundredButton.UseVisualStyleBackColor = true;
            this.hundredButton.Click += new System.EventHandler(this.hundredButton_Click);
            // 
            // fiftyButton
            // 
            this.fiftyButton.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.fiftyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fiftyButton.FlatAppearance.BorderSize = 0;
            this.fiftyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fiftyButton.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiftyButton.Location = new System.Drawing.Point(524, 357);
            this.fiftyButton.Name = "fiftyButton";
            this.fiftyButton.Size = new System.Drawing.Size(140, 50);
            this.fiftyButton.TabIndex = 10;
            this.fiftyButton.Text = "$50";
            this.fiftyButton.UseVisualStyleBackColor = true;
            this.fiftyButton.Click += new System.EventHandler(this.fiftyButton_Click);
            // 
            // twentyButton
            // 
            this.twentyButton.BackColor = System.Drawing.Color.Transparent;
            this.twentyButton.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.twentyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.twentyButton.FlatAppearance.BorderSize = 0;
            this.twentyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twentyButton.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twentyButton.Location = new System.Drawing.Point(524, 267);
            this.twentyButton.Name = "twentyButton";
            this.twentyButton.Size = new System.Drawing.Size(140, 50);
            this.twentyButton.TabIndex = 11;
            this.twentyButton.Text = "$20";
            this.twentyButton.UseVisualStyleBackColor = false;
            this.twentyButton.Click += new System.EventHandler(this.twentyButton_Click);
            // 
            // tenButton
            // 
            this.tenButton.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.tenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tenButton.FlatAppearance.BorderSize = 0;
            this.tenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenButton.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenButton.Location = new System.Drawing.Point(277, 441);
            this.tenButton.Name = "tenButton";
            this.tenButton.Size = new System.Drawing.Size(140, 50);
            this.tenButton.TabIndex = 12;
            this.tenButton.Text = "$10";
            this.tenButton.UseVisualStyleBackColor = true;
            this.tenButton.Click += new System.EventHandler(this.tenButton_Click);
            // 
            // fiveButton
            // 
            this.fiveButton.BackgroundImage = global::ATMClient.GUI.Properties.Resources.SideText_image;
            this.fiveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fiveButton.FlatAppearance.BorderSize = 0;
            this.fiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fiveButton.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveButton.Location = new System.Drawing.Point(277, 357);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(140, 50);
            this.fiveButton.TabIndex = 13;
            this.fiveButton.Text = "$5";
            this.fiveButton.UseVisualStyleBackColor = true;
            this.fiveButton.Click += new System.EventHandler(this.fiveButton_Click);
            // 
            // withdrawPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ATMClient.GUI.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.fiveButton);
            this.Controls.Add(this.tenButton);
            this.Controls.Add(this.twentyButton);
            this.Controls.Add(this.fiftyButton);
            this.Controls.Add(this.hundredButton);
            this.Controls.Add(this.withdrawButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.singleButton);
            this.Controls.Add(this.cashCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fbground);
            this.Name = "withdrawPage";
            this.Text = "withdrawPage";
            this.Load += new System.EventHandler(this.withdrawPage_Load);
            this.fbground.ResumeLayout(false);
            this.fbground.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Label bankName;
        private System.Windows.Forms.Panel fbground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cashCount;
        private System.Windows.Forms.Button singleButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button withdrawButton;
        private System.Windows.Forms.Button hundredButton;
        private System.Windows.Forms.Button fiftyButton;
        private System.Windows.Forms.Button twentyButton;
        private System.Windows.Forms.Button tenButton;
        private System.Windows.Forms.Button fiveButton;
    }
}