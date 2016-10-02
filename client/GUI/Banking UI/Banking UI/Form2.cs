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
            if (txtPIN.Text.Length == 4)
            {
                thePIN.Text = txtPIN.Text;
                txtPIN.Text = "";
                //disables text field making the user not able to input past 4th digit
                txtPIN.Enabled = false;
            }
            //Enables for future usage
            Enabled = true;
        }
        private void loginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
