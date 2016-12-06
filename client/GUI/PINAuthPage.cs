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
    public partial class PinPage : Form
    {
        ATMClient atm;

        public PinPage(ATMClient atm)
        {
            this.atm = atm;
            InitializeComponent();
        }

        private void txtPIN_TextChanged(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            WrongPINMessage.Visible = false;

            if (txtPIN.Text.Length == 4)
            {
                long a;
                if (!long.TryParse(txtPIN.Text, out a) || a < 0)
                {
                    txtPIN.Clear();
                    ErrorMessage.Visible = true;
                    //Clear doesn't work?
                    return;
                }
                //disables text field making the user not able to input past 4th digit
                txtPIN.Enabled = false;
                //Enables for future usage
                txtPIN.Enabled = true;

                //This is where we will send the PIN to the server
                if (atm.serverConnection.isConnected())
                {
                    Message response = atm.serverConnection.SendData("authenticatePIN", txtPIN.Text, true);
					Console.WriteLine("AUTH STAGE 2, PIN: {0}", response.data);
					if (response.data == "PIN Verified")
					{
						//var photoPage = new PhotoAuth(atm);
						//photoPage.Show();
						//var fingerPage = new FingerAuthPage(atm);
						//fingerPage.Show();
						this.Close();
					}
					else
					{
						txtPIN.Clear();
						WrongPINMessage.Visible = true;
						return;
					}
                }

                Close();
                
            }
            
        }

        private void loginPage_Load(object sender, EventArgs e)
        {

            if (!(atm == null))
            {


                if (!(atm.user == null) && !(atm.user.getName() == null))
                {
                    greetingText.Text = greetingText.Text + " " + atm.user.getName()  + "!";
                }

                if (atm.serverConnection == null)
                {
                    greetingText.Text = "server connection is null";
                } else
                {
                    if (!atm.serverConnection.isConnected())
                    {
                        greetingText.Text = "not connected to the server";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            txtPIN.Text += "1";
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            txtPIN.Text += "2";
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            txtPIN.Text += "3";
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            txtPIN.Text += "4";
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            txtPIN.Text += "5";
            button5.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            txtPIN.Text += "6";
            button6.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            txtPIN.Text += "7";
            button7.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            txtPIN.Text += "8";
            button8.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Enabled = false;
            txtPIN.Text += "9";
            button9.Enabled = true;
        }
    }
}
