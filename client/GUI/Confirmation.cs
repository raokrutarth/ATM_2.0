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
    public partial class Confirmation : Form
    {
        ATMClient atm;
        public Confirmation(ATMClient atm)
        {
            this.atm = atm;
            InitializeComponent();
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            atm.user.logout();
            Close();
        }
    }
}
