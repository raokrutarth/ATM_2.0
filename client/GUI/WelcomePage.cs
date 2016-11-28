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
        //rverConnection serverConnection;
        Boolean dtaSend = false;
        //rrentUser user
        ATMClient atm;
        public welcomePage(ATMClient atm)
        {
            this.atm = atm;
            InitializeComponent();
            
        }

        private void welcomePage_Load(object sender, EventArgs e)
        {
            if (atm.serverConnection.Connect())
            {
                DemoText.Text = "Connected to Server";
            } else
            {
                DemoText.Text = "Connection Error";
            }
            /*Card reader will listen here and send directly to server*/
        }


        private void MockID_TextChanged(object sender, EventArgs e)
        {
            //Make sure that the ID follows whatever protocol we want
            //some Boolean *Vaild* will be triggered

        }

        private void sendName_Click(object sender, EventArgs e)
        {
            //This is where we will send the users name
            if (dtaSend)
            {
                Close();
            }
            if (MockID.Text.Length >= 1/*Boolean vaild*/)
            {
                if (atm.serverConnection == null)
                {

                }
                else
                {
                    if (true/*atm.serverConnection.Connect()*/) {
                        //Needs to have a type called AuthID for card ID
                        //Message msg = serverConnection.SendData("authenticateID", MockID.Text, true);
                        DemoText.Text = DemoText.Text + "\n Data Sent. (not true yet)";
                        //This needs to change
                        atm.user.setName(MockID.Text);
                        // Handle response, if correct close and move forward.
                        if (true/*correct resp. or nah*/)
                        {
                            atm.user.login();
                            dtaSend = true;
                        }
                    }
                    else
                    {
                        DemoText.Text = DemoText.Text + " Connection Issue.";
                    }
                }
            }
        }

    }
}
