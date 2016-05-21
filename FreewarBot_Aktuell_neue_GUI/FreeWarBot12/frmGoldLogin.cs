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
        frmGoldMain frm;
        public frmGoldLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings2._Username = textBox4.Text;
            Settings2._Password = textBox3.Text;
            Settings2._World = numericUpDown2.Value.ToString();
            frm = new frmGoldMain(Settings2._Username, Settings2._Password, Settings2._World);
            
            this.Hide();
        }
    }
}
