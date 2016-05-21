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
    public partial class frmUserAgent : Form
    {
        public frmUserAgent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter myFile = new StreamWriter("UserAgent.txt");
            myFile.Write( textBox1.Text);
            myFile.Close();
            Settings._Useragent = textBox1.Text;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUserAgent_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings._Useragent;
        }
    }
}
