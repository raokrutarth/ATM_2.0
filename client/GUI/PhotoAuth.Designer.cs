namespace ATM
{
    partial class PhotoAuth
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
            this.components = new System.ComponentModel.Container();
            this.bankName = new System.Windows.Forms.Label();
            this.bankIcon = new System.Windows.Forms.Label();
            this.fbground = new System.Windows.Forms.Panel();
            this.photoMSG = new System.Windows.Forms.Label();
            this.userImage = new System.Windows.Forms.PictureBox();
            this.takePic = new System.Windows.Forms.Button();
            this.listOfCams = new System.Windows.Forms.ComboBox();
            this.CountDown = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.Timer(this.components);
            this.fbground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
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
            this.bankName.TabIndex = 2;
            this.bankName.Text = "HSBC";
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
            this.fbground.TabIndex = 1;
            // 
            // photoMSG
            // 
            this.photoMSG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.photoMSG.AutoSize = true;
            this.photoMSG.BackColor = System.Drawing.Color.Transparent;
            this.photoMSG.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoMSG.Location = new System.Drawing.Point(12, 483);
            this.photoMSG.Name = "photoMSG";
            this.photoMSG.Size = new System.Drawing.Size(547, 37);
            this.photoMSG.TabIndex = 3;
            this.photoMSG.Text = "Please display face for recognition";
            // 
            // userImage
            // 
            this.userImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userImage.BackColor = System.Drawing.Color.Transparent;
            this.userImage.Location = new System.Drawing.Point(271, 137);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(369, 310);
            this.userImage.TabIndex = 4;
            this.userImage.TabStop = false;
            // 
            // takePic
            // 
            this.takePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.takePic.BackColor = System.Drawing.Color.Transparent;
            this.takePic.BackgroundImage = global::ATMClient.GUI.Properties.Resources.fbg_image;
            this.takePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.takePic.FlatAppearance.BorderSize = 0;
            this.takePic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.takePic.Location = new System.Drawing.Point(778, 430);
            this.takePic.Name = "takePic";
            this.takePic.Size = new System.Drawing.Size(152, 90);
            this.takePic.TabIndex = 5;
            this.takePic.Text = "Recognize Face";
            this.takePic.UseVisualStyleBackColor = false;
            this.takePic.Click += new System.EventHandler(this.takePic_Click);
            // 
            // listOfCams
            // 
            this.listOfCams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listOfCams.FormattingEnabled = true;
            this.listOfCams.Location = new System.Drawing.Point(24, 165);
            this.listOfCams.Name = "listOfCams";
            this.listOfCams.Size = new System.Drawing.Size(121, 24);
            this.listOfCams.TabIndex = 6;
            this.listOfCams.Visible = false;
            // 
            // CountDown
            // 
            this.CountDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CountDown.BackColor = System.Drawing.Color.Transparent;
            this.CountDown.Font = new System.Drawing.Font("Rockwell", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDown.Location = new System.Drawing.Point(721, 165);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(142, 211);
            this.CountDown.TabIndex = 7;
            // 
            // Count
            // 
            this.Count.Interval = 1000;
            this.Count.Tick += new System.EventHandler(this.Count_Tick);
            // 
            // PhotoAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ATMClient.GUI.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.CountDown);
            this.Controls.Add(this.listOfCams);
            this.Controls.Add(this.takePic);
            this.Controls.Add(this.userImage);
            this.Controls.Add(this.photoMSG);
            this.Controls.Add(this.fbground);
            this.Name = "PhotoAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoAuth";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PhotoAuth_Load);
            this.fbground.ResumeLayout(false);
            this.fbground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bankName;
        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Panel fbground;
        private System.Windows.Forms.Label photoMSG;
        private System.Windows.Forms.PictureBox userImage;
        private System.Windows.Forms.Button takePic;
        private System.Windows.Forms.ComboBox listOfCams;
        private System.Windows.Forms.Label CountDown;
        private System.Windows.Forms.Timer Count;
    }
}