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
    public partial class MainMenu : Form
    {
        ATMClient atm;
        public MainMenu(ATMClient atm)
        {
            this.atm = atm;
            InitializeComponent();
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {

            Form form = new withdrawPage(atm);
            form.Size = this.Size;
            form.Location = new Point(0,0);/*new Size(700, 500);*/
            form.Show();

        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {

        }

        private void CheckBalBtn_Click(object sender, EventArgs e)
        {

        }

        private void AccSettingBtn_Click(object sender, EventArgs e)
        {

        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {

        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            Close();
           
        }

        private void changePINBtn_Click(object sender, EventArgs e)
        {
            Form form = new changePIN(atm);
            form.Size = this.Size;/*new Size(700, 500);*/
            form.Show();

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}