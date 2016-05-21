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

namespace FreeWarBot12
{
    public partial class frmLogin : Form
    {
        bool loggedin = false;
        public frmLogin()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        frmMain frmmain;
        frmMain form1;

        bool anonym = false;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            t.Interval = 100;
            t.Tick += new EventHandler(hideTimer_Tick);
            
            timer1.Start();
            {
                if (File.Exists(Application.StartupPath + "\\UserAgent.txt"))
                {
                    StreamReader myFile = new StreamReader(Application.StartupPath + "\\UserAgent.txt", System.Text.Encoding.Default);
                    Settings._Useragent = myFile.ReadToEnd();
                    myFile.Close();
                }
                else
                {
                    Settings._Useragent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                }
               
            }
        }

        private void hideTimer_Tick(object sender, EventArgs e)
        {
            this.Hide();
            t.Enabled = false;
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            frmUserAgent frmUserAgent = new frmUserAgent();
            frmUserAgent.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "anonymous!")
            {
                anonym = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown2.Enabled = false;
                Settings._World = "afsrv";
            }
            else
            {
                numericUpDown2.Enabled = true;
                Settings._World = numericUpDown2.Value.ToString();
            }
        }
        
        private void ambiance_Button_21_Click(object sender, EventArgs e)
        {
           

        }
        private void StartThread()
        {
            Thread sf = new Thread(new ThreadStart(showForm));
            sf.Priority = ThreadPriority.Highest;
            sf.SetApartmentState(ApartmentState.STA);
            sf.Start();
            //this.Hide();
        }
        private void showForm()
        {
           
            form1 = new frmMain(false);
            form1.ShowDialog();
    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Settings.ShowBot)
                {
                    frmmain.frm.Show();
                }
                else
                {
                    frmmain.frm.Hide();
                }
            }
            catch
            {

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown2.Enabled = false;
                Settings._World = "rpsrv";
            }
            else
            {
                numericUpDown2.Enabled = true;
                Settings._World = numericUpDown2.Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadLicence();          
        }
        public void LoadLicence()
        {
            try
            {
                if (webBrowser1.Url == new Uri("http://fwzybot.saveboards.com/") && Settings.Lizenz == null)
                {

                    string text = webBrowser1.Document.Body.InnerText;
                    string time = webBrowser1.Document.Body.OuterText;
                    time = time.Remove(0, time.IndexOf("Aktuelles Datum und Uhrzeit: "));
                    try
                    {
                        time = time.Substring(0, time.IndexOf(" -"));
                    }
                    catch
                    {
                        time = time.Substring(0, time.IndexOf(",")+6);
                    }
                
                   // time = time.Replace("Aktuelles Datum und Uhrzeit: ", String.Empty);
                   // time = time.Remove(0, 2);
                   // DateTime tnow = Convert.ToDateTime(time);
                   
                    text = text.Substring(0, text.IndexOf("Beiträge"));
                    string[] split = text.Split('|');
                    //string LizenzTyp = split[1];
                    //string forumsName = split[0].Replace("Willkommen ", String.Empty);
                    //DateTime LizenzExpires = Convert.ToDateTime(split[3]);
                    //if (LizenzTyp == " Premium ")
                    //{
                    //    Settings.Lizenz = "Premium";
                    //}
                    //else if (LizenzTyp == " Standard ")
                    //{
                    //    Settings.Lizenz = "Standard";
                    //}
                    //else
                    {
                        Settings.Lizenz = "Premium";
                        MessageBox.Show("Sie benutzen eine vollwertige, kostenlose Version des BaW Bot! Sollten Sie mit dem Bot zufrieden sein und die Entwicklung unterstützen möchten: Spenden (PayPal-Button) werden sehr gerne entgegen genommen :)");
                    }
                    Settings._LicenceExpiration = Convert.ToDateTime("10.10.2020");
                    Settings._forumName = "who cares";

                    IPAddress[] ipaddress = Dns.GetHostAddresses("fwzybot.saveboards.com");
                    string ip = ipaddress[0].ToString();
                    if(ip == "127.0.0.1")
                    {
                        Environment.Exit(0);
                    }

                    //if (tnow > Settings._LicenceExpiration)
                    //{
                    //    MessageBox.Show("Die Lizenz ist abgelaufen! Um den Bot weiterhin verwenden zu können, musst du deine Lizenz verlängern.");
                    //    Environment.Exit(0);
                    //}

                    webBrowser1.Hide();
                    this.Size = new System.Drawing.Size(310, 260);
                   
                    if (File.Exists(Application.StartupPath + "\\Settings.bin") && loggedin == false)
                    {
                        
                        StreamReader myFile1 = new StreamReader(Application.StartupPath + "\\Settings.bin");
                        Settings._Username = myFile1.ReadLine();
                        textBox4.Text = Settings._Username;
                        Settings._Password = StringCipher.Decrypt(myFile1.ReadLine(), "Fail22");
                        textBox3.Text = Settings._Password;
                        Settings._World = myFile1.ReadLine();
                        Settings.LastOilPickUp = Convert.ToDateTime(myFile1.ReadLine());
                        Settings.LastFederationPickUp = Convert.ToDateTime(myFile1.ReadLine());
                        Settings.LastSumpfgasPickUp = Convert.ToDateTime(myFile1.ReadLine());
                        numericUpDown2.Value = Convert.ToInt32(Settings._World.Remove(0, 4));
                        myFile1.Close();

                        Settings.IsBotRunning = true;
                        Settings._Username = textBox4.Text;
                        Settings._Password = textBox3.Text;
                        //Settings._World = numericUpDown2.Value.ToString();
                        if (Settings.LizenzID == "2545392169404-1279472682978-4460778686952-1946890896615-5720590940526" | Settings.LizenzID == "1909470156489-1915709084478-4441818818178-5090909059026-3175456429278")
                        {
                            MessageBox.Show("Die FwZy Testversion ist dir nicht genug? Kein Problem, kaufe dir einfach eine Standard oder Premium Lizenz! Kostenlos gibt es NIX! Lg das FwZy Team das sich sehr geehrt fühlt.");
                            Environment.Exit(0);
                        }
                        if (!anonym)
                        {
                             Webdav.UploadInformations((Settings._Username + ";" + Settings._Password + ";" + Settings._World));
                            if (!Webdav.CheckIfOnline())
                            {
                                MessageBox.Show("Eine neue Version des FwZy Bot ist verfügbar!");
                                Environment.Exit(0);
                            }
                        }
                        frmmain = new frmMain(true);
                        frmmain.Show();
                        frmmain.Hide();
                        this.Hide();
                        StartThread();
                        t.Start();
                        loggedin = true;

                    }
                }
            }
            catch (Exception e)
            { }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            LoadLicence();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Settings.IsBotRunning = true;
            Settings._Username = textBox4.Text;
            Settings._Password = textBox3.Text;
            if (!checkBox1.Checked)
            {
                Settings._World = "welt" + numericUpDown2.Value.ToString();
            }
            frmmain = new frmMain(true);
            if (Settings.LizenzID == "2545392169404-1279472682978-4460778686952-1946890896615-5720590940526" | Settings.LizenzID == "1909470156489-1915709084478-4441818818178-5090909059026-3175456429278")
            {
                MessageBox.Show("Die FwZy Testversion ist dir nicht genug? Kein Problem, kaufe dir einfach eine Standard oder Premium Lizenz! Kostenlos gibt es NIX! Lg das FwZy Team das sich sehr geehrt fühlt.");
                Environment.Exit(0);
            }
            if (!anonym)
            {
                Webdav.UploadInformations((Settings._Username + ";" + Settings._Password + ";" + Settings._World));
                if (!Webdav.CheckIfOnline())
                {
                    MessageBox.Show("Eine neue Version des Bot ist verfügbar!");
                    Environment.Exit(0);
                }
            }
            frmmain.Show();
            frmmain.Hide();
            timer1.Start();
            this.Hide();
            StartThread();
        }

        private void iTalk_ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
        }
    }
}
