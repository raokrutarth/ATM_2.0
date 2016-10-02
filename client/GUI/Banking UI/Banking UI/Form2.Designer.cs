namespace Banking_UI
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
            this.bankIcon = new System.Windows.Forms.Label();
            this.bankName = new System.Windows.Forms.Label();
            this.greetingText = new System.Windows.Forms.Label();
            this.messagePIN = new System.Windows.Forms.Label();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.thePIN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bankIcon
            // 
            this.bankIcon.AutoSize = true;
            this.bankIcon.BackColor = System.Drawing.Color.Transparent;
            this.bankIcon.Image = global::Banking_UI.Properties.Resources.HSVC_image1;
            this.bankIcon.Location = new System.Drawing.Point(419, 39);
            this.bankIcon.MinimumSize = new System.Drawing.Size(110, 60);
            this.bankIcon.Name = "bankIcon";
            this.bankIcon.Size = new System.Drawing.Size(110, 60);
            this.bankIcon.TabIndex = 3;
            // 
            // bankName
            // 
            this.bankName.AutoSize = true;
            this.bankName.BackColor = System.Drawing.Color.Transparent;
            this.bankName.Font = new System.Drawing.Font("Baskerville Old Face", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bankName.Location = new System.Drawing.Point(236, 34);
            this.bankName.Name = "bankName";
            this.bankName.Size = new System.Drawing.Size(194, 69);
            this.bankName.TabIndex = 2;
            this.bankName.Text = "HSBC";
            // 
            // greetingText
            // 
            this.greetingText.AutoSize = true;
            this.greetingText.BackColor = System.Drawing.Color.Transparent;
            this.greetingText.Font = new System.Drawing.Font("Arial Narrow", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greetingText.Location = new System.Drawing.Point(270, 237);
            this.greetingText.Name = "greetingText";
            this.greetingText.Size = new System.Drawing.Size(150, 42);
            this.greetingText.TabIndex = 4;
            this.greetingText.Text = "Hi Stacy !";
            // 
            // messagePIN
            // 
            this.messagePIN.AutoSize = true;
            this.messagePIN.BackColor = System.Drawing.Color.Transparent;
            this.messagePIN.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagePIN.Location = new System.Drawing.Point(208, 328);
            this.messagePIN.Name = "messagePIN";
            this.messagePIN.Size = new System.Drawing.Size(122, 22);
            this.messagePIN.TabIndex = 5;
            this.messagePIN.Text = "Please enter PIN";
            this.messagePIN.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(361, 328);
            this.txtPIN.MaxLength = 4;
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(118, 22);
            this.txtPIN.TabIndex = 6;
            this.txtPIN.TextChanged += new System.EventHandler(this.txtPIN_TextChanged);
            // 
            // thePIN
            // 
            this.thePIN.BackColor = System.Drawing.Color.Transparent;
            this.thePIN.Font = new System.Drawing.Font("Modern No. 20", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thePIN.Location = new System.Drawing.Point(270, 407);
            this.thePIN.Name = "thePIN";
            this.thePIN.Size = new System.Drawing.Size(160, 52);
            this.thePIN.TabIndex = 7;
            this.thePIN.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Banking_UI.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(728, 510);
            this.Controls.Add(this.thePIN);
            this.Controls.Add(this.txtPIN);
            this.Controls.Add(this.messagePIN);
            this.Controls.Add(this.greetingText);
            this.Controls.Add(this.bankIcon);
            this.Controls.Add(this.bankName);
            this.DoubleBuffered = true;
            this.Name = "loginPage";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.loginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bankIcon;
        private System.Windows.Forms.Label bankName;
        private System.Windows.Forms.Label greetingText;
        private System.Windows.Forms.Label messagePIN;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.Label thePIN;
    }
}