﻿using System;
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
        ATMClient atm;

        public welcomePage(ATMClient atm)
        {
            this.atm = atm;
            InitializeComponent();
            
        }

        private void welcomePage_Load(object sender, EventArgs e)
        {

			//Card reader will listen here for actual account number.
			//TODO: Don't hardcode the account number
			MockID.Text = ATMClient.USER_ID;
		}


        private void MockID_TextChanged(object sender, EventArgs e)
        {
            //Make sure that the ID follows whatever protocol we want
            //some Boolean *Vaild* will be triggered

        }

        private void sendName_Click(object sender, EventArgs e)
        {
            if (MockID.Text.Length >= 1/*Boolean vaild*/)
            {
                if (!atm.serverConnection.isConnected())
                {
					atm.serverConnection.Connect();
                }

                if (atm.serverConnection.isConnected())
                { 

					// Interact with the server.
					Message response = atm.serverConnection.SendData("getName", MockID.Text, true);
					Console.WriteLine("AUTH STAGE 1, ACCOUNT: {0}", response.data);
					if (response.data == "Error client does not exist")
					{
					}
					else
					{
						atm.user.setName(response.data);
						this.Close();
					}
                }
              
            }
        }

        private void welcomeMessage_Click(object sender, EventArgs e)
        {

        }

      
    }
}
