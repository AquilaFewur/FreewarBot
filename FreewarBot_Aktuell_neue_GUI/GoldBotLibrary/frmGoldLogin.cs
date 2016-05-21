using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Freewar
{
    public partial class frmGoldLogin : Form
    {
        public frmGoldLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings._Username = textBox4.Text;
            Settings._Password = textBox3.Text;
            Settings._World = numericUpDown2.Value.ToString();
            frmGoldMain frm = new frmGoldMain();
            frm.Show();
            this.Hide();
        }
    }
}
