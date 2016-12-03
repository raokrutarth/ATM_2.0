using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class FingerAuthPage : Form
    {
        ATMClient atm;
		bool clicked;
        public FingerAuthPage(ATMClient atm)
        {
            this.atm = atm;
			this.clicked = false;
            InitializeComponent();
        }

        private void FingerAuthPage_Load(object sender, EventArgs e)
        {
			label1.Text = "Click here to begin.";
        }

		private void label1_Click(object sender, EventArgs e)
		{
			if (this.clicked)
				return;
			this.clicked = true;
			FingerScanMessage.Text = "";
			label1.Text = "Please place your finger on the scanner.";
			label1.Update();

			// Get the fingerprint image.
			byte[] data;
			while ((data = atm.drivers.fingerprintReader.GetImage()) == null)
			{
				System.Threading.Thread.Sleep(2000);
			}

			label1.Text = "Processing...";

			// Transmit the image and wait for server verification.
			Message response = atm.serverConnection.SendData("authenticateFinger", data, true);
			Console.WriteLine("AUTH STAGE 4, FINGER: {0}", response.data);
			if(response.data == "Fingerprint Verified")
			{
				Console.WriteLine("YOU DID IT!");
				this.Close();
			}
			else
			{
				Console.WriteLine("You fail.");
				label1.Text = "Please try again.";
				this.clicked = false;
				FingerScanMessage.Text = "Click the button to try again.";
			}
		}
	}
}
