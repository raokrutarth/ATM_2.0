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
    public partial class FingerAuthPage : Form
    {
        ATMClient atm;
        public FingerAuthPage(ATMClient atm)
        {
            this.atm = atm;
            InitializeComponent();
        }

        private void FingerAuthPage_Load(object sender, EventArgs e)
        {
            //Anthony's Code goes here
            //Code here will run as soon as this page is loaded so having a finger reader
            //listening and sending the data once read can go here
            //I can finish this once the finger part works
            //atm is the ATMClient object that connects to the server
            // example atm.serverConnection.SendData(...data...);


            //here is something to help you test?
            Boolean fingerRead = false;
            if (fingerRead)
            {
                DebugText.Text = "ReadFinger!";
            } else
            {
                DebugText.Text = "Error?";
            }
        }
    }
}
