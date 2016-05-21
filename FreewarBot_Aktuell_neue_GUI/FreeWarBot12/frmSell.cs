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
    public partial class frmSell : Form
    {
        List<string> _SellItems = new List<string>();
        public frmSell(List<string> sellitems)
        {
            _SellItems = sellitems;
            InitializeComponent();
            for (int i = 0; i < sellitems.Count; i++)
            {
                ListViewItem item = new ListViewItem(sellitems[i]);
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
            for (int i = 0; i < _SellItems.Count; i++)
            {
                if (listView1.SelectedItems[0].Text == _SellItems[i])
                {
                    _SellItems.RemoveAt(i);
                }
            }
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            Save();
        }

        private void Save()
        {
            StreamWriter myFile1 = new StreamWriter(Application.StartupPath + "\\Itemstosell.txt", false, System.Text.Encoding.Default);
            for (int i = 0; i < _SellItems.Count; i++)
            {
                myFile1.WriteLine(_SellItems[i]);
            }

            myFile1.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _SellItems.Add(textBox1.Text.ToLower());
            listView1.Items.Add(textBox1.Text.ToLower());
            Save();
        }
    }
}
