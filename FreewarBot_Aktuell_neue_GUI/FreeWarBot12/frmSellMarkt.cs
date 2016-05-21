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
    public partial class frmSellMaha : Form
    {
        List<string> _SellItems = new List<string>();
        public frmSellMaha(List<string> sellitems)
        {
            _SellItems = sellitems;
            InitializeComponent();
            for (int i = 0; i < sellitems.Count; i++)
            {
                ListViewItem item = new ListViewItem(sellitems[i].Split(';')[0]);
                item.SubItems.Add(sellitems[i].Split(';')[1]);
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
                if (listView1.SelectedItems[0].Text == _SellItems[i].Split(';')[0])
                {
                    _SellItems.RemoveAt(i);
                }
            }
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            Save();
        }

        private void Save()
        {
            StreamWriter myFile1 = new StreamWriter(Application.StartupPath + "\\Itemstomaha.txt", false, System.Text.Encoding.Default);
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
            _SellItems.Add(textBox1.Text.ToLower() + ";"+ textBox2.Text);
            ListViewItem item = new ListViewItem(textBox1.Text.ToLower());
            item.SubItems.Add(textBox2.Text);
            listView1.Items.Add(item);
            Save();
        }

        private void frmSell_Load(object sender, EventArgs e)
        {

        }
    }
}
