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

                    thePIN.Text = "";
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
						var photoPage = new PhotoAuth(atm);
						photoPage.Show();
					}
					else
					{
						txtPIN.Clear();
						WrongPINMessage.Visible = true;
						thePIN.Text = "";
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
    }
}
