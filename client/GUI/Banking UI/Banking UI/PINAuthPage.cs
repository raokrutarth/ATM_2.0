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
                if (txtPIN.Text.Equals("8080"))
                {
                    txtPIN.Clear();
                    WrongPINMessage.Visible = true;
                    //Clear doesn't work?
                    thePIN.Text = "";
                    return;
                }
                thePIN.Text = txtPIN.Text;
                txtPIN.Text = "";
                //disables text field making the user not able to input past 4th digit
                txtPIN.Enabled = false;
                //button to close page is now active
                
            moveOn.Visible = true;
            }
            //Enables for future usage
            txtPIN.Enabled = true;
            
        }
        private void moveOn_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
