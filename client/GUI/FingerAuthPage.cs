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
    public partial class FingerAuthPage : Form
    {
        public FingerAuthPage()
        {
            InitializeComponent();
        }

        private void moveOn_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
