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
    public partial class welcomePage : Form
    {
        public DialogResult OK { get; private set; }

        public welcomePage()
        {
            InitializeComponent();
        }

       
        private void moveOn_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void welcomePage_Load(object sender, EventArgs e)
        {

        }

        private void cardIcon_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Manage the text here
        }

        private void sendName_Click(object sender, EventArgs e)
        {
            //This is where we will send the users name
            if (textBox1.Text.Length >= 1)
            {
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
