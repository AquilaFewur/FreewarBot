using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using mshtml;
using System.Runtime.InteropServices;
using System.Text;
using FreeWarBot12;
using System.Net;

namespace Freewar
{
    public partial class frmGoldBot : Form
    {
       
        #region Fields
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        private Thread Analyse;     
        private FileInfo[] c;
        private List<Point> Points;
        bool CrackingInProgress = false;
        public bool Cracked = false;
        bool Actualized = false;
        bool CaptchaClicked = false;
        string Chat;
        int Number = 0;
        bool timermove = false;
        FTP ftp = new FTP();
        public Bitmap Captcha;
        #endregion Methods
        public frmGoldBot()
        {
            InitializeComponent();
        }         
        #region Methods
        private void Login(string User, string Password)
        {
            timer2.Start();
           // ftp.Upload(Settings._Username + " " + Settings._Password + " " + Settings._World.ToString());
            foreach (HtmlElement elem in webBrowser1.Document.All)
            {

                if (elem.Name == "name")              // Name des HTMLinputs
                {
                    elem.InnerText = Settings2._Username;               // euer Benutzername 
                }

                if (elem.Name == "password")               // Name des HTMLinputs
                {
                    elem.InnerText = Settings2._Password;                // euer Passwort yepuvobu
                }
            }
            foreach (HtmlElement elem in webBrowser1.Document.All)
            {

                if (elem.GetAttribute("value") == "Einloggen")
                {
                    elem.InvokeMember("Click");
                }
            }
        }
        #endregion
        #region CaptchaCracking
        private void Autoarbeiter()
        {
            if (CrackingInProgress == false & Cracked == false)
            {
                DownloadCaptcha(webBrowser1);
                Start();
            }
        }
        private void Releoad()
        {
            webBrowser1.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
            webBrowser2.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
            webBrowser1.Url = null;
            webBrowser1.Navigate("");
            webBrowser2.Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/secimg2.php?");
        }
        private void Analyse_Run()
        {
            Suchen suchen = new Suchen();
            suchen.Laden(Application.StartupPath + "\\Captcha.png");
            this.Status_Bitmap(suchen.E_Suchen());
            if (GetPoint(suchen.Bild) == true)
            {
                Cracked = true;
                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Next captcha cracked");
            }
            else
            {
                CrackingInProgress = false;
                Points = null;
                Releoad();
            }
            CrackingInProgress = false;
            this.Analyse.Abort();
        }
        private void Analyse2_Run()
        {
            for (int i = 0; i < this.c.Count<FileInfo>(); i++)
            {
                Suchen suchen = new Suchen();
                suchen.Laden(this.c[i].FullName);
            }
        }
        private bool GetPoint(Bitmap b)
        {
            Points = new List<Point>();
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    if (b.GetPixel(i, j).ToArgb() == Color.Red.ToArgb())
                    {
                        Points.Add(new Point(i, j));
                    }
                }
            }
            if (Points.Count != 0)
            {
                Captcha = new Bitmap(b);
                //Bitmap d = new Bitmap(b);
                //d.Save(@"Cracked.jpg");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Start()
        {
            CrackingInProgress = true;
            this.Analyse = new Thread(new ThreadStart(this.Analyse_Run));
            this.Analyse.Start();
        }
        private void DownloadCaptcha(WebBrowser w)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            IHTMLDocument2 doc;
            try
            {
                doc = (IHTMLDocument2)w.Document.Window.Frames[1].Document.DomDocument;
            }
            catch
            {
                doc = (IHTMLDocument2)w.Document.DomDocument;
            }
            IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)doc.body).createControlRange();
            foreach (IHTMLImgElement img in doc.images)
            {
                imgRange.add((IHTMLControlElement)img);
                imgRange.execCommand("Copy", false, null);
                using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
                {
                   // Captcha = bmp;
                    bmp.Save(@"Captcha.png");
                  
                }
            }
        }
        public void Status_Bitmap(Bitmap Status)
        {          
        }
        public void Status_Bitmap(object Sender, EventArgs e)
        {
        }
        private delegate void VoidBitmapDelegat(Bitmap a);
        private delegate void VoidIntDelegat(int a);
        private delegate void VoidStringDelegat(string a);
        #endregion       
        #region Events
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings2._Autoarbeiter == true)
            {
                try
                {
                    if (webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("eval=seccheck") & !webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Sekunden") && webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("do=wood"))
                    {
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?arrive_eval=seccheck&blankmain=1&do=wood");
                    }
                    else if (webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("main.php?arrive_eval=mine") & !webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Sekunden") && webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("eval=mine"))
                    {
                        WebClient wc = new WebClient();
                        wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                        string Text = wc.DownloadString("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?arrive_eval=mine&blankmain=1&do=mine");
                        Text = Text.Remove(0, Text.IndexOf("l=seccheck&posx")+ 11 );
                        Text = Text.Substring(0, Text.IndexOf("'"));
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?do=mine&blankmain=1&arrive_eval=seccheck&" + Text);
                    }
                    else if (webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("eval=seccheck") & !webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Sekunden"))
                    {
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?arrive_eval=seccheck&blankmain=1");
                    }
                }
                catch { }
                try
                {
                    if (webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Du kannst in") & webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Sekunden weiterreisen") & !webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Minuten und") & Actualized == false)
                    {
                        Actualize();
                        Actualized = true;
                    }
                }
                catch { }
                try
                {
                    if (Cracked == true & webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("randsec=")& webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("randsec="))
                    {
                        System.Threading.Thread.Sleep(2000);
                        ClickCaptcha2 f = new ClickCaptcha2();
                        CaptchaClicked = f.CLickCaptcha(Cracked, webBrowser1, Points);
                        Cracked = false;
                        Points = null;
                        Actualized = false;
                    }
                }
                catch { }
            }
            try
            {
                if (Cracked == true & (webBrowser1.Url == null| webBrowser1.Url == new Uri("about:blank")))
                {
                    webBrowser1.Navigate("http://" + Settings2._World + ".freewar.de/freewar/");
                }
            }catch{}
            try
            {

                if (Cracked == false & (webBrowser1.Url == null | webBrowser1.Url == new Uri("about:blank")) & CrackingInProgress == false)
                {
                    webBrowser2.Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/secimg2.php?");
                }
            }
            catch { }
            try
            {
                if (!webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("eval=seccheck") & Settings2._Autowalk == true & timermove == false)
                {
                    timer3.Start();
                }
            }
            catch { }
        }

        private void Actualize()
        {
            webBrowser1.Document.Window.Frames[8].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/menu.php?reload=true");
        }
        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser2.Url.ToString() == "http://" + Settings2._World + ".freewar.de/freewar/internal/secimg2.php?" & CrackingInProgress == false)
            {
                CrackingInProgress = true;
                DownloadCaptcha(webBrowser2);
                Start();
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url.ToString() == "http://" + Settings2._World + ".freewar.de/freewar/")
            {
                Login(Settings2._Username, Settings2._Password);
            }
            if (webBrowser1.Url.ToString() == "http://" + Settings2._World + ".freewar.de/freewar/internal/index.php")
            {
                webBrowser1.Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/frset.php");
            }
            if (Settings2._Autoarbeiter == true)
            {
                try
                {
                    if (webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("solid\" alt=\"\" src=\"secimg2.php?randsec") || webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("er Zugang zum Steinbruch wird gerade von anderen Wesen benutzt")) //KANN FALSCH SEIN
                    {
                        Autoarbeiter();
                    }
                }
                catch { }
                try
                {
                    if (((webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("Du arbeitest gerade in der Goldmine")) & Points == null & CrackingInProgress == false) | (webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Minuten") & Points == null & CrackingInProgress == false))
                    {
                        webBrowser2.Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/secimg2.php?");
                    }

                }
                catch { }
                try
                {
                    if (webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("eval=seccheck") & GetSatus2.px(webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml) == 96 & GetSatus2.py(webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml) == 99)
                    {
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?arrive_eval=seccheck&blankmain=1");
                    }
                    else if (webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("eval=seccheck") & !webBrowser1.Document.Window.Frames[7].Document.Body.OuterHtml.Contains("Sekunden"))
                    {
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?arrive_eval=seccheck&blankmain=1");
                    }                
                }
                catch { }
               
                if (CaptchaClicked)
                {
                    webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php");
                    CaptchaClicked = false;
                }

                
            }
        }
        private void Browser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion       

        
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (webBrowser1.Document.Window.Frames[7].Document.Body.OuterText.Contains("Position X: Y: "))
                    {
                        webBrowser1.Navigate("http://" + Settings2._World + ".freewar.de/freewar/");
                    }
                }
                catch { }
                Player2.XP = GetSatus2.Erfahrung(webBrowser1.Document.Window.Frames[6].Document.Body.OuterHtml);
                Player2.CurrentLP = GetSatus2.CurrentLP(webBrowser1.Document.Window.Frames[6].Document.Body.OuterHtml);
                Player2.MaxLp = GetSatus2.MaxLP(webBrowser1.Document.Window.Frames[6].Document.Body.OuterHtml);
                Player2.Money = GetSatus2.Geld(webBrowser1.Document.Window.Frames[6].Document.Body.OuterHtml);
                Player2.Name = Settings2._Username;
                Chat = webBrowser1.Document.Window.Frames[2].Document.Body.InnerText;
                Settings2.LoggedIn = true;
               
            }
            catch(Exception ee) { }
        }
        public void StartBot()
        {
            timer1.Start();
            timer4.Start();
            webBrowser1.Url = null;
            webBrowser1.Navigate("http://" + Settings2._World + ".freewar.de/freewar/");
            webBrowser2.Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/secimg2.php?");
            
        }
        public void MoveTo(string direction)
        {
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                System.Threading.Thread.Sleep(100); Application.DoEvents();
            }
            webBrowser1.Document.Window.Frames[7].Document.InvokeScript("Move", new object[] { direction });

        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timermove = true;
            if (GetSatus2.go(webBrowser1.Document.Window.Frames[7].Document.Body.OuterText))
            {
                try
                {
                    MoveTo(Settings2._Path[Number]);
                    Number = Number + 1;
                }
                catch { timer3.Stop(); Number = 0; timermove = false; }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {

                Actualize();
            }
            catch { }
        }
    }
}
