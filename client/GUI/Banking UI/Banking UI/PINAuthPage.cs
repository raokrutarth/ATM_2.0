using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_UI
{
    public partial class loginPage : Form
    {

        public loginPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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


                //This will be taken care of on the server side
                if (!txtPIN.Text.Equals("1000"))
                {
                    txtPIN.Clear();
                    WrongPINMessage.Visible = true;
                    thePIN.Text = "";
                    return;

                }
                //This is where we will send the PIN to the server
                //for now we will just close
                Close();
            }
            
        }
        private void moveOn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
