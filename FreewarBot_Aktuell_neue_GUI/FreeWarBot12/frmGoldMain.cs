using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Freewar
{
    public partial class frmGoldMain : Form
    {
        public frmGoldBot _frmGoldBot;
        public frmGoldMain(string Username, string Passwort, string Welt)
        {
            Settings2._Username = Username;
            Settings2._Password = Passwort;
            Settings2._World = Welt;
            Settings2._Autoarbeiter = true;
            _frmGoldBot = new frmGoldBot();
            _frmGoldBot.StartBot();
            InitializeComponent();
        }
        frmGoldBot frm;

        private void button1_Click(object sender, EventArgs e)
        {
            frm = new frmGoldBot();
            frm.StartBot();
            button1.Enabled = false;
            button1.Text = "Einloggen...";
            timer1.Start();
            frm.Show();

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Settings2._Autoarbeiter = true;
            }
            else
            {
                Settings2._Autoarbeiter = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings2.LoggedIn == false)
            {
                if (button1.Text == "Einloggen.  ")
                {
                    button1.Text = "Einloggen.. ";
                }
                else if (button1.Text == "Einloggen.. ")
                {
                    button1.Text = "Einloggen...";
                }
                else if (button1.Text == "Einloggen...")
                {
                    button1.Text = "Einloggen.  ";
                }
            }
            else
            {
                label1.Text = "Erfahrung: " + Player2.XP.ToString();
                label2.Text = "Geld: " + Player2.Money.ToString();
                label3.Text = "Lebenspunkte: " + Player2.CurrentLP + "/" + Player2.MaxLp;
                label4.Text = "Name: " + Player2.Name;
                button1.Text = "Logged in";
                button2.Show();
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            frm.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Settings2._Autowalk = true;
            }
            else
            {
                Settings2._Autowalk= false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadPath();
        }
        public void LoadPath()
        {
            StreamReader objReader = new StreamReader("Path.txt");
            string sLine = "";


            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Settings2._Path.Add(sLine);
            }
            objReader.Close();
        }

        private void frmGoldMain_Load(object sender, EventArgs e)
        {

        }
    }
}
