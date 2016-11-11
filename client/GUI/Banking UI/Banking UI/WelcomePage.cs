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

    }
}
