using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FreeWarBot12
{
    public partial class frmSerial : Form
    {
        public frmSerial()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (SerialChecker.Check(textBox1.Text))
            {
                pictureBox1.BackgroundImage = Properties.Resources.accept;
                button1.Enabled = true;
            }
            else
            {
                pictureBox1.BackgroundImage = Properties.Resources.cancel;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter myFile = new StreamWriter("Serial.txt");
            myFile.Write(textBox1.Text);
            myFile.Close();
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void frmSerial_Load(object sender, EventArgs e)
        {

        }
    }
}
