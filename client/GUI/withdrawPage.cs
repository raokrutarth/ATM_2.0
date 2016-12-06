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
        private ATMClient atm;
        public withdrawPage(ATMClient atm)
        {
            this.atm = atm;
            withdraw = 0;
            InitializeComponent();
        }

        private void singleButton_Click(object sender, EventArgs e)
        {
            disable();
            withdraw++;
            update();
        }

        private void withdrawPage_Load(object sender, EventArgs e)
        {
            update();
        }
        
        private void update()
        {
            int now, delay;
            cashCount.Text = "$" + withdraw;
            now = (DateTime.Now).Minute * 1000;
            now += (DateTime.Now).Second * 10;
            now += (DateTime.Now).Millisecond/100;
            delay = now + 6;

            Console.Write("now:" + now + "\ndelay:" + delay);
            while ((delay - now) > 0 ) {
                now = (DateTime.Now).Minute * 1000;
                now += (DateTime.Now).Second * 10;
                now += (DateTime.Now).Millisecond/100;
                Console.Write(delay - now +"\n");
            }
            enable();
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

        private void disable()
        {
            singleButton.Enabled = false;
            fiveButton.Enabled = false;
            tenButton.Enabled = false;
            twentyButton.Enabled = false;
            fiftyButton.Enabled = false;
            hundredButton.Enabled = false;

        }
        private void enable()
        {
            singleButton.Enabled = true;
            fiveButton.Enabled = true;
            tenButton.Enabled = true;
            twentyButton.Enabled = true;
            fiftyButton.Enabled = true;
            hundredButton.Enabled = true;

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (withdraw != 0)
            {
                withdraw = 0;
                update();
            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            if (withdraw != 0 )
            {
                //Message msg = atm.serverConnection.SendData("makeWithdrawal", withdraw.ToString(), true);
                //if good then send it off, notify and set withdraw to $0
                //for now just close
                if (withdraw < 700)
                {
                    this.Close();
                } else
                {

                }
            } 
        }
    }
}
