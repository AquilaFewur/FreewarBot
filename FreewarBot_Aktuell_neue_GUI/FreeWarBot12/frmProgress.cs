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
    public partial class Fortschritte : Form
    {
        public Fortschritte()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Anfangserfahrung: " + Settings.StartXP;
                label2.Text = "Momentane Erfahrung: " + Player.XP;
                label3.Text = "Gesammelte Erfahrung: " + (Player.XP - Settings.StartXP).ToString();
                double Faktor = 3600 / (DateTime.Now - Settings.Starttime).Seconds;
                double value = ((Player.XP - Settings.StartXP) * Faktor);
               // label4.Text = value.ToString() + " XP/Stunde";
                //label5.Text = Convert.ToInt32(((DateTime.Now - Settings.Starttime).TotalHours)).ToString() + ":" + Convert.ToInt32(((DateTime.Now - Settings.Starttime).TotalMinutes)).ToString() + ":" +((DateTime.Now - Settings.Starttime).Seconds);
                label5.Text = "Uptime: " + (DateTime.Now - Settings.Starttime).ToString(@"h\h\:m\m\:s\s", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Fortschritte_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
