using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FreeWarBot12
{
    public partial class frmHealItems : Form
    {
        List<string> _HealItems = new List<string>();
        public frmHealItems(List<string> healitems)
        {
            _HealItems = healitems;
            InitializeComponent();
            for (int i = 0; i < healitems.Count; i++)
            {
                ListViewItem item = new ListViewItem(healitems[i]);
                listView1.Items.AddRange(new ListViewItem[] { item });
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            ListViewItem item3 = new ListViewItem("Something3");
            listView1.Items.AddRange(new ListViewItem[] { item3 });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _HealItems.Count; i++)
            {
                if (listView1.SelectedItems[0].Text == _HealItems[i])
                {
                    _HealItems.RemoveAt(i);
                }
            }
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            Save();
        }

        private void Save()
        {
            StreamWriter myFile1 = new StreamWriter(Application.StartupPath + "\\HealItems.txt", false, System.Text.Encoding.Default);
            for (int i = 0; i < _HealItems.Count; i++)
            {
                myFile1.WriteLine(_HealItems[i]);
            }

            myFile1.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _HealItems.Add(textBox1.Text.ToLower());
            listView1.Items.Add(textBox1.Text.ToLower());
            Save();
        }

        private void ambiance_ThemeContainer1_Click(object sender, EventArgs e)
        {

        }
    }
}
