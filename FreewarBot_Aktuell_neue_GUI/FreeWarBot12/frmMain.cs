using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;
using Freewar;


namespace FreeWarBot12
{

    public partial class frmMain : Form
    {
        frmGoldMain frmGold;
        Thread frmGoldThread;
        string content = "";
        public bool isWorkerThread = false;


        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                mynotifyicon.Visible = true;
                mynotifyicon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            mynotifyicon.Visible = false;
        }



        public frmMain(bool isworkerthread)
        {
           
            isWorkerThread = isworkerthread;

            this.TopLevel = true;
            InitializeComponent();
        
            if (Settings.Lizenz == "Premium")
            {
                pictureBox26.Image = global::FreeWarBot12.Properties.Resources.premium;
            }
            if (Settings.Lizenz == "Standard")
            {
                pictureBox26.Image = global::FreeWarBot12.Properties.Resources.Standard;
            }
            if (Settings.Lizenz == "Premium+")
            {
                pictureBox26.Image = global::FreeWarBot12.Properties.Resources.auftrag;
            }

            if (isworkerthread)
            {
                Settings._DerString = Webdav.GetSecureString();
                timer5.Start();
                LoadAvoidNPC();
                LoadHealItems();
                this.Hide();
            }
            timer1.Start();
            WBTimer.Start();
            Settings.IsBotRunning = false;
            iTalk_Button_22.Text = "Start";
            if (Settings.Lizenz == "Trail")
            {
                // timer3.Start();
            }
            if (File.Exists(Application.StartupPath + "\\SettingsMain.bin"))
            {
                StreamReader myFile1 = new StreamReader(Application.StartupPath + "\\SettingsMain.bin");
                checkBox1.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox2.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox3.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox4.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox5.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox6.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox7.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox8.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox9.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox10.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox11.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox12.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBox13.Checked = Convert.ToBoolean(myFile1.ReadLine());
                comboBox1.Text = myFile1.ReadLine();
                comboBox2.Text = myFile1.ReadLine();
                comboBox3.Text = myFile1.ReadLine();
                comboBox4.Text = myFile1.ReadLine();
                comboBox5.Text = myFile1.ReadLine();
                comboBox6.Text = myFile1.ReadLine();
                comboBox7.Text = myFile1.ReadLine();
                textBox3.Text = myFile1.ReadLine();
                textBox4.Text = myFile1.ReadLine();
                cÜberweisen.Checked = Convert.ToBoolean(myFile1.ReadLine());
                checkBoxShop.Checked = Convert.ToBoolean(myFile1.ReadLine());
               // CaptchaCracker.Checked = Convert.ToBoolean(myFile1.ReadLine());
                bool b = Convert.ToBoolean(myFile1.ReadLine());
                myFile1.Close();
            }
            if (Settings.Lizenz == "Trail")
            {
                //itemsImInventarBehaltenToolStripMenuItem.Enabled = false;
                //bankitemsToolStripMenuItem.Enabled = false;
                //shopitemsToolStripMenuItem.Enabled = false;
                //markthalleVerkaufsitemsToolStripMenuItem.Enabled = false;
                label14.Visible = true;
                checkBox4.Checked = false;
                checkBox4.Enabled = false;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                checkBox7.Checked = false;
                checkBox7.Enabled = false;
                checkBox10.Checked = false;
                checkBox10.Enabled = false;
                checkBox15.Checked = false;
                checkBox15.Enabled = false;
                checkBox13.Checked = false;
                checkBox13.Enabled = false;
                checkBox8.Checked = false;
                checkBox8.Enabled = false;
                checkBox9.Checked = false;
                checkBox9.Enabled = false;
                checkBox11.Checked = false;
                checkBox16.Checked = false;
                checkBox16.Enabled = false;
                checkBox11.Enabled = false;
                cÜberweisen.Checked = false;
                cÜberweisen.Enabled = false;
                checkBoxShop.Checked = false;
                checkBoxShop.Enabled = false;
                checkBox12.Checked = false;
                checkBox12.Enabled = false;
                comboBox7.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                checkBox6.Checked = true;
                checkBox6.Enabled = false;
                comboBox4.Enabled = false;
                comboBox4.Text = "10";
                comboBox3.Enabled = false;
                comboBox5.Enabled = false;
                comboBox2.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button5.Enabled = false;
                checkBox14.Enabled = false;
            }
        
        }
        public frmBot frm;
        Random rnd = new Random();








        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                Settings._attack = true;
            }
            else
            {
                Settings._attack = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isWorkerThread)
            {
                label1.Text = "Erfahrung: " + Player.XP.ToString();
                label2.Text = "Geld: " + Player.Money.ToString();
                label3.Text = "Lebenspunkte: " + Player.CurrentLP + "/" + Player.MaxLp;
                label4.Text = "Name: " + Player.Name;
                ambiance_Label7.Text = Settings.CaptchaCounter.ToString();
                iTalk_ProgressBar1.Maximum = Player.MaxLp;

                try
                {
                    iTalk_ProgressBar1.Value = Player.CurrentLP;

                }
                catch { }
                try
                {



                    if (frmGold._frmGoldBot.Cracked)
                    {
                        Image a = frmGold._frmGoldBot.Captcha;
                        pictureBoxCaptcha.Image = a;
                        //a.Dispose();
                        //File.Delete(Application.StartupPath + "\\Cracked.jpg");
                    }

                }
                catch { Exception ex; }
                if (Settings.Action != null)
                {
                    for (int i = 0; i < Settings.Action.Count; i++)
                    {
                        listBox2.Items.Add(Settings.Action[i]);

                    }
                    Settings.Action = new List<string>();
                }



                listBox2.TopIndex = listBox2.Items.Count - 1;
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
                Settings._Autowalk = true;
            }
            else
            {
                Settings._Autowalk = false;
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
                    Settings._Path.Add(sLine);
            }
            objReader.Close();
        }

        public void LoadHealItems()
        {
            StreamReader objReader = new StreamReader("HealItems.txt");
            string sLine = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Settings._Heal_Items.Add(sLine.ToLower());
            }
            objReader.Close();
        }

        public void LoadAvoidNPC()
        {
            StreamReader objReader = new StreamReader("AvoidNPC.txt");
            string sLine = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Settings._Avoid_NPC.Add(sLine.ToLower());
            }
            objReader.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ShopsHinzufügen();
            StartBot();
            try
            {
                for (int i = 0; i < frm.Ways.Count; i++)
                {
                    comboBox1.Items.Add(frm.Ways[i].Name);
                }
            }
            catch { }
            groupBox3.Enabled = false;
            if ((Settings.LizenzID == "5072009720778-1903169570967-2526494707989-5683042292004-5714668915452") | (Settings.LizenzID == "4435453279341-1921816316952-3786869539089-1927930448052-1902981824163") | (Settings.LizenzID == "2545392169404-1279472682978-4460778686952-1946890896615-5720590940526") | (Settings.LizenzID == "3824546096763-4429467636678-1316767435326-3792857053104-1947208467078") | (Settings.LizenzID == "2545392169404-1279472682978-4460778686952-1946890896615-5720590940526") | (Settings.LizenzID == "5707868090526-5090593429467-3792915674604-4448183676426-3799344805263") | (Settings.LizenzID == "5701630460589-1316828532852-5097209682852-5065394701563-4441879909026") | (Settings.LizenzID == "5078305317141-1272666830652-3817993435263-5090844156804-5714231097204") || Settings.Lizenz == "Premium")
            {
                groupBox3.Enabled = true;
            }

        }
        private void StartBot()
        {
            if (frm != null)
            {
                frm.Dispose();
            }
            if (isWorkerThread)
            {
                frm = new frmBot(isWorkerThread);
                this.Hide();
                // frm.Show();
                // frm.Show();

                //   if (isWorkerThread)
                //  frm = new frmBot();
                // frm.StartBot();
                //  frm.Show();
            }
            else
            {
                frm = new frmBot(isWorkerThread);
            }
            this.Focus();

        }
        private static void ShopsHinzufügen()
        {
            Settings.ShopList.Add(new Point(90, 115));
            Settings.ShopList.Add(new Point(86, 107));
            Settings.ShopList.Add(new Point(77, 101));
            Settings.ShopList.Add(new Point(92, 108));
            Settings.ShopList.Add(new Point(87, 97));
            Settings.ShopList.Add(new Point(75, 86));
            Settings.ShopList.Add(new Point(501, 54));
            Settings.ShopList.Add(new Point(99, 99));
            Settings.ShopList.Add(new Point(106, 95));
            Settings.ShopList.Add(new Point(79, 110));
            Settings.ShopList.Add(new Point(105, 108));
            Settings.ShopList.Add(new Point(114, 114));
            Settings.ShopList.Add(new Point(91, 95));
            Settings.ShopList.Add(new Point(98, 111));
            Settings.ShopList.Add(new Point(71, 101));
            Settings.ShopList.Add(new Point(65, 112));
            Settings.ShopList.Add(new Point(126, 85));
            Settings.ShopList.Add(new Point(97, 101));
            Settings.ShopList.Add(new Point(86, 85));
            Settings.ShopList.Add(new Point(71, 90));
            Settings.ShopList.Add(new Point(84, 112));
            Settings.ShopList.Add(new Point(120, 115));
            Settings.ShopList.Add(new Point(112, 91));
            Settings.ShopList.Add(new Point(101, 116));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings._huntingArea = comboBox1.Text;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.MaxMoney = Convert.ToInt32(comboBox2.Text);
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                Settings._take = true;
            }
            else
            {
                Settings._take = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                Settings._sell = true;
            }
            else
            {
                Settings._sell = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxShop.Checked == true)
            {
                string[] s = comboBox3.Text.Substring(1, comboBox3.Text.IndexOf("]") - 1).Split('/');
                Settings.ShopList = new List<Point>();
                Settings.ShopList.Add(new Point(Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
            }
        }

        private void checkBoxShop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShop.Checked == true)
            {
                string[] s = comboBox3.Text.Substring(1, comboBox3.Text.IndexOf("]") - 1).Split('/');
                Settings.ShopList = new List<Point>();
                Settings.ShopList.Add(new Point(Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
            }
            else
            {
                ShopsHinzufügen();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Settings._ChangeArea)
            {
                comboBox1.Text = comboBox1.Items[rnd.Next(0, (comboBox1.Items.Count - 1))].ToString();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                Settings._ability = textBox1.Text;
                Settings.trainAbility = true;
            }
            else
            {
                Settings.trainAbility = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox6.Checked == true)
            {
                try
                {
                    Settings.ChangeTime = Convert.ToInt32(comboBox4.Text) * 1000 * 60;
                    timer2.Interval = Settings.ChangeTime;
                }
                catch { }
                Settings._ChangeArea = true;
                timer2.Start();
            }
            else
            {
                Settings._ChangeArea = false;
                timer2.Stop();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox7.Checked == true)
            {
                Settings._maha = true;

            }
            else
            {
                Settings._maha = false;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //if (button2.Text == "Bot-Fenster verbergen")
            //{
            //    button2.Text = "Bot-Fenster anzeigen";
            //    frm.Hide();
            //}
            //else
            //{
            //    button2.Text = "Bot-Fenster verbergen";
            //    frm.Show();
            //}
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (cÜberweisen.Checked == true)
            {
                Settings._TranferMoney = Convert.ToInt32(comboBox5.Text);
                Settings._TranserMoney = true;
                Settings._TransferReceiver = textBox2.Text;
            }
            else
            {
                Settings._TranserMoney = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings._TranferMoney = Convert.ToInt32(comboBox5.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Settings._TransferReceiver = textBox2.Text;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Settings._huntingArea = comboBox1.Text;
            Paths._Actual = new List<string>();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            Settings._minLP = Convert.ToInt32(numericUpDown1.Value);
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Settings.MaxMoney = Convert.ToInt32(comboBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings._ability = textBox1.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.ChangeTime = Convert.ToInt32(comboBox4.Text) * 1000 * 60;
            timer2.Interval = Settings.ChangeTime;
            Settings._ChangeArea = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Settings.IsBotRunning = false;
            MessageBox.Show("Die Trail-Zeit ist abgelaufen! Kaufen Sie sich eine FwZy Lizenz um den vollen Umfang nutzen zu können!");
            Environment.Exit(0);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                Settings._StoreArrows = true;
            }
            else
            {
                Settings._StoreArrows = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (CaptchaCracker.Checked == true)
            {
                frmGold = new frmGoldMain(Settings._Username, Settings._Password, Settings._World);
                Settings._AutoArbeiter = true;
            }
            else
            {
                frmGold = null;
                Settings._AutoArbeiter = false;
            }

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] s = comboBox6.Text.Substring(1, comboBox6.Text.IndexOf("]") - 1).Split('/');
            Settings.CaptchaCrackerPlace = new Point(Convert.ToInt32(s[0]), Convert.ToInt32(s[1]));
        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                Settings.PickUpOil = true;
            }
            else
            {
                Settings.PickUpOil = false;
            }
        }

        private void checkBox9_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                Settings.PickUpSumpfgas = true;
            }
            else
            {
                Settings.PickUpSumpfgas = false;
            }
        }

        private void checkBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                Settings.PickUpFederation = true;
            }
            else
            {
                Settings.PickUpFederation = false;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            Settings._huntingArea = comboBox1.Text;
            Paths._Actual = new List<string>();
        }

        private void checkBox8_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                Settings.PickUpOil = true;
            }
            else
            {
                Settings.PickUpOil = false;
            }
        }

        private void checkBox9_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                Settings.PickUpSumpfgas = true;
            }
            else
            {
                Settings.PickUpSumpfgas = false;
            }
        }

        private void checkBox11_CheckedChanged_2(object sender, EventArgs e)
        {
            //if (CaptchaCracker.Checked == true)
            //{
            //    frmGoldThread = new Thread(new ThreadStart(showForm));
            //    frmGoldThread.SetApartmentState(ApartmentState.STA);
            //    frmGoldThread.Start();
            //    Settings._AutoArbeiter = true;
            //}
            //else
            //{
            //    try
            //    {
            //        frmGoldThread.Abort();
            //        frmGold.Dispose();
            //    }
            //    catch
            //    {

            //    }
            //    Settings._AutoArbeiter = false;
            //}
            Paths._Actual = null;
            if (CaptchaCracker.Checked == true)
            {
                frmGold = new frmGoldMain(Settings._Username, Settings._Password, Settings._World);
                Settings._AutoArbeiter = true;
            }
            else
            {
                try
                {
                    frmGold.Dispose();
                }
                catch
                {

                }
                Settings._AutoArbeiter = false;
            }
        }
        private void showForm()
        {
            frmGold = new frmGoldMain(Settings._Username, Settings._Password, Settings._World);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            Settings._RepairWeapons = checkBox12.Checked;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings._RepairWeaponsValue = Convert.ToInt32(comboBox7.Text);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            StartBot();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSell frm1 = new frmSell(frm.manager.ItemsToSell);
            frm1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSellMaha frm1 = new frmSellMaha(frm.manager.ItemsToMaha);
            frm1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmBankItems frm1 = new frmBankItems(frm.manager.BankItems);
            frm1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmPermanentInv frm1 = new frmPermanentInv(frm.manager.PermanentInventar);
            frm1.Show();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            Settings.UseProtection = checkBox13.Checked;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void produktionenAbholenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduktionen frm = new frmProduktionen();
            frm.Show();
        }

        private void checkBox8_CheckedChanged_3(object sender, EventArgs e)
        {
            Settings.PickUpOil = checkBox8.Checked;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged_3(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                Settings.PickUpFederation = true;
            }
            else
            {
                Settings.PickUpFederation = false;
            }
        }

        private void shopitemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSell frm1 = new frmSell(frm.manager.ItemsToSell);
            frm1.Show();
        }

        private void markthalleVerkaufsitemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSellMaha frm1 = new frmSellMaha(frm.manager.ItemsToMaha);
            frm1.Show();
        }

        private void bankitemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBankItems frm1 = new frmBankItems(frm.manager.BankItems);
            frm1.Show();
        }

        private void itemsImInventarBehaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermanentInv frm1 = new frmPermanentInv(frm.manager.PermanentInventar);
            frm1.Show();
        }

        private void fortschrittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fortschritte frm = new Fortschritte();
            frm.Show();
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            Settings.trainAbility = checkBox5.Checked;
        }

        private void checkBoxShop_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxShop.Checked)
            {
                string[] s = comboBox3.Text.Substring(1, comboBox3.Text.IndexOf("]") - 1).Split('/');
                Settings.ShopList = new List<Point>();
                Settings.ShopList.Add(new Point(Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
            }
            else
            {
                ShopsHinzufügen();
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (checkBoxShop.Checked == true)
            {
                string[] s = comboBox3.Text.Substring(1, comboBox3.Text.IndexOf("]") - 1).Split('/');
                Settings.ShopList = new List<Point>();
                Settings.ShopList.Add(new Point(Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
            }

        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            Paths._Actual = null;
        }


        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            Settings._Auftraege = checkBox14.Checked;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Settings.aktuellerAuftragstext);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //   checkBox15.Checked = false;
                MessageBox.Show("Es kann nur AutoKill ODER AutoChase (Verjagen) aktiv sein!");

            }
            else
            {
                Settings.NPCVerjagen = checkBox15.Checked;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Settings._ability = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Settings._TransferReceiver = textBox4.Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frmSell frm1 = new frmSell(frm.manager.ItemsToSell);
            frm1.TopLevel = false;
            frm1.Parent = tabPage10;
            frm1.Location = new Point(205, 0);
            frm1.StartPosition = FormStartPosition.Manual;
            frm1.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            frmBankItems frm1 = new frmBankItems(frm.manager.BankItems);
            frm1.TopLevel = false;
            frm1.Parent = tabPage10;
            frm1.Location = new Point(205, 0);
            frm1.StartPosition = FormStartPosition.Manual;
            frm1.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            frmPermanentInv frm1 = new frmPermanentInv(frm.manager.PermanentInventar);
            frm1.TopLevel = false;
            frm1.Parent = tabPage10;
            frm1.Location = new Point(205, 0);
            frm1.StartPosition = FormStartPosition.Manual;
            frm1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmSellMaha frm1 = new frmSellMaha(frm.manager.ItemsToMaha);
            frm1.TopLevel = false;
            frm1.Parent = tabPage10;
            frm1.Location = new Point(205, 0);
            frm1.StartPosition = FormStartPosition.Manual;
            frm1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Fortschritte frm = new Fortschritte();
            frm.Show();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            try
            {
                if (iTalk_TabControl1.SelectedIndex == 2)
                {
                    Thread t = new Thread(LoadMap);
                    t.Start();
                    webBrowser3.Navigate("http://www." + Settings._World + ".freewar.de//freewar/internal/main.php");
                    //webBrowser3.Document.Cookie = Settings.Cookies;





                    webBrowser2.DocumentText = content;




                }
                else
                {
                    // webBrowser2.Url = null;
                    webBrowser3.Url = null;

                }
                if (iTalk_TabControl1.SelectedIndex == 2)
                {
                    if (webBrowser5.Url == null | (webBrowser5.Url.ToString() == "about:blank"))
                    {
                        webBrowser5.Navigate("http://www." + Settings._World + ".freewar.de/freewar/internal/chatform.php");
                    }

                    webBrowser4.Navigate("http://www." + Settings._World + ".freewar.de/freewar/internal/chattext.php");

                }
                else
                {
                    webBrowser5.Url = null;
                    webBrowser4.Url = null;
                }
            }
            catch { }

        }
        public void LoadMap()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            content = wc.DownloadString("https://fwtools.de/map/" + Settings.PX.ToString() + "/" + Settings.PY.ToString());
            content = content.Replace("<img src=\"http://welt1.freewar.de/freewar/images/map/zahl0.gif\" width=\"50\" height=\"50\">", "");
            content = content.Replace("<img src=\"http://welt1.freewar.de/freewar/images/map/user.gif\" width=\"50\" height=\"50\">", "");
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void ambiance_Button_21_Click(object sender, EventArgs e)
        {

        }

        private void ambiance_ThemeContainer1_Click(object sender, EventArgs e)
        {

        }

        private void ambiance_Button_22_Click(object sender, EventArgs e)
        {
            Process.Start("http://fwzybot.saveboards.com/chatbox/index.forum");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser2.Document.Body.Style = "zoom:67%";

        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                webBrowser3.Document.Body.Style = "zoom:75%";
            }
            catch
            { }
        }

        private void webBrowser4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser5_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void pictureBoxCaptcha_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser2.Document.Body.Style = "zoom:60%";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "Bot-Fenster verbergen")
            {

                button1.Text = "Bot-Fenster anzeigen";
                Settings.ShowBot = false;
            }
            else
            {
                MessageBox.Show("Es wird nicht empfohlen dieses Fenster zu öffnen, solange der Bot aktiv ist. Verwende stattdessen besser \"Bot überwachen\".");
                button1.Text = "Bot-Fenster verbergen";
                Settings.ShowBot = true;
            }

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs a)
        {

        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {

        }

        private void checkBox16_CheckedChanged_1(object sender, EventArgs a)
        {
            if (checkBox16.Checked == true)
            {
                Settings.Harvest = true;
            }
            else
            {
                Settings.Harvest = false;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs a)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.CollectOil = Convert.ToInt32(textBox5.Text);
            }
            catch
            {

            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            

        }

        private void mynotifyicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.isWorkerThread)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                mynotifyicon.Visible = false;
                this.Show();
            }
        }

        private void TrayIcon()
        {
            if (!isWorkerThread)
            {
                this.mynotifyicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                this.mynotifyicon.BalloonTipText = "Der Bot läuft nun im Hintergrund, Füße hochlegen und enstpannen!";
                this.mynotifyicon.BalloonTipTitle = "BaW - " + Settings._Username + " - " + Settings._World.ToString();
                this.mynotifyicon.Text = "dd";

                this.WindowState = FormWindowState.Minimized;
                mynotifyicon.Visible = true;
                mynotifyicon.Text = "BaW - " + Settings._Username + " - " + Settings._World.ToString();
                mynotifyicon.ShowBalloonTip(3000);
                this.ShowInTaskbar = true;
            }
        }

        private void checkBox17_CheckedChanged_1(object sender, EventArgs a)
        {
            Settings.usediebeshoehle = checkBox17.Checked;
        }

        private void timer5_Tick_1(object sender, EventArgs e)
        {
            //Session Cookie Check, wegen free Version auskommentiert!
           // Webdav.CheckIfCookieIsOK();
        }

        private void iTalk_ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            Process.Start("http://fwzybot.saveboards.com/chatbox/index.forum");
        }

        private void c_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_Button_22_Click(object sender, EventArgs e)
        {
            if (Settings.IsBotRunning == true)
            {
                Settings.IsBotRunning = false;
                iTalk_Button_22.Text = "Start";
            }
            else
            {
                Settings.IsBotRunning = true;
                iTalk_Button_22.Text = "Stop";
            }
        }

        private void iTalk_ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_Button_23_Click(object sender, EventArgs e)
        {
            Process.Start("http://fwzybot.saveboards.com/");
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            frmHealItems frm1 = new frmHealItems(Settings._Heal_Items);
            frm1.TopLevel = false;
            frm1.Parent = tabPage10;
            frm1.Location = new Point(205, 0);
            frm1.StartPosition = FormStartPosition.Manual;
            frm1.Show();
        }

        private void iTalk_Button_24_Click(object sender, EventArgs e)
        {
            Process.Start("http://paypal.me/BaW");
        }
    }    
}
