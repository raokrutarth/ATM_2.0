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
    public partial class withdrawPage : Form
    {
        private int withdraw;
        public withdrawPage()
        {
            withdraw = 0;
            InitializeComponent();
        }

        private void singleButton_Click(object sender, EventArgs e)
        {
            withdraw++;
            update();
        }

        private void withdrawPage_Load(object sender, EventArgs e)
        {
            update();
        }
        
        private void update()
        {
            cashCount.Text = "$" + withdraw;
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            withdraw += 5;
            update();
        }

        private void tenButton_Click(object sender, EventArgs e)
        {
            withdraw += 10;
            update();
        }

        private void twentyButton_Click(object sender, EventArgs e)
        {
            withdraw += 20;
            update();
        }

        private void fiftyButton_Click(object sender, EventArgs e)
        {
            withdraw += 50;
            update();
        }

        private void hundredButton_Click(object sender, EventArgs e)
        {
            withdraw += 100;
            update();
        }
    }
}
