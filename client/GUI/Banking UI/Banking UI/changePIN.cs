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
    public partial class changePIN : Form
    {
        public changePIN()
        {
            InitializeComponent();
        }

        private void changePIN1Label_Click(object sender, EventArgs e)
        {

        }

        private void newPIN1_TextChanged(object sender, EventArgs e)
        {
            invalidPINMessage.Visible = false;

            if (newPIN1.Text.Length == 4)
            {
                long a;
                if (!long.TryParse(newPIN1.Text, out a) || a < 0)
                {
                    newPIN1.Clear();
                    invalidPINMessage.Visible = true;
                    newPIN1.Enabled = false;
                    newPIN1.Enabled = true;
                    return;
                }

            }
        }

        private void changePIN_Load(object sender, EventArgs e)
        {

        }

        private void newPIN2_TextChanged(object sender, EventArgs e)
        {
            invalidPINMessage.Visible = false;
            unequalPINMessage.Visible = false;
            if (newPIN2.Text.Length == 4)
            {
                long a;
                if (!long.TryParse(newPIN2.Text, out a) || a < 0)
                {
                    newPIN2.Clear();
                    invalidPINMessage.Visible = true;
                    newPIN2.Enabled = false;
                    newPIN2.Enabled = true;
                    return;
                }

                if ( newPIN1.Text.Length == 4 )
                {
                    if (!newPIN1.Text.Equals(newPIN2.Text))
                    {
                        newPIN1.Clear();
                        newPIN2.Clear();
                        unequalPINMessage.Visible = true;
                        return;
                    }
                }
                Close();
            }
        }
    }
}
