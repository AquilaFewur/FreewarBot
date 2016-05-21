using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreeWarBot12
{
    public partial class frmProduktionen : Form
    {
        public frmProduktionen()
        {
            InitializeComponent();
            if (Settings.Lizenz != "Trail")
            {
              
                checkBox8.Checked = Settings.PickUpOil;
                checkBox9.Checked = Settings.PickUpSumpfgas;
                checkBox11.Checked = Settings.PickUpFederation;
            }
            else
            {
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
                checkBox11.Enabled = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PickUpOil = checkBox8.Checked;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PickUpSumpfgas = checkBox9.Checked;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PickUpFederation = checkBox11.Checked;
        }

        private void frmProduktionen_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings.CollectOil = Convert.ToInt32(textBox1.Text);
        }
    }
}
