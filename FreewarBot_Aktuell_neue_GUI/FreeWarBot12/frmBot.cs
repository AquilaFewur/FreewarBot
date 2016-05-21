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
using System.Net;

namespace FreeWarBot12
{
    
    public partial class frmBot : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        //[DllImport("wininet.dll", SetLastError = true)]
        //private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        const int URLMON_OPTION_USERAGENT = 0x10000001;

     


        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string UrlName, string CookieName, string CookieData);

        public bool isWorkerThread = false;
        GetSatus getStats;
        public Manager manager;
        Thread CheckerThread;
        System.Threading.Timer timer;
        PathFinder pathFinder = new PathFinder();
        Thread t;


       
        public List<MapWays> Ways = new List<MapWays>();
       
        public frmBot(bool isworker)
        {
            isWorkerThread = isworker;
            InitializeComponent();
           
            StartBot();      
        }
        public void StartBot()
        {
            Player.Name = Settings._Username;

            if (isWorkerThread)
            {
                getStats = new GetSatus(webBrowser1);
                manager = new Manager(webBrowser1, getStats, pathFinder, isWorkerThread);
                pathFinder.LoadPoints();
                LoadAllFiles();
                if (Settings._World == "rpsrv")
                {
                      webBrowser1.Navigate("http://www.freewar.de/rpserver)"); 
                }
                else
                {
                webBrowser1.Navigate("http://" + Settings._World + ".freewar.de/freewar/");
                }
                timer1.Start();
                timer2.Start();
                timer3.Start();
            }
            else
            {
                manager = new Manager(webBrowser1, getStats, pathFinder,isWorkerThread);
                LoadAllFiles();
               // webBrowser1.Navigate("http://" + Settings._World + ".freewar.de/freewar/");
            }
        }

        private void LoadAllFiles()
        {
            Loadpaths();
            LoadSellItems();
            LoadPermanentInv();
            LoadBankItems();
            LoadMahaItems();
        }
        public void ChangeUserAgent(string Agent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
           
            if (Settings.IsBotRunning &&  isWorkerThread)
            {
                //try
                //{
                //    if (!(CheckerThread.ThreadState == ThreadState.Running))
                //    {
                //        CheckerThread = new Thread(manager.CheckStats);
                //        CheckerThread.SetApartmentState(ApartmentState.STA);
                //        CheckerThread.IsBackground = true;
                //        CheckerThread.Start();
                //    }
                //}
                //catch
                //{
                //    CheckerThread = new Thread(manager.CheckStats);
                //    CheckerThread.SetApartmentState(ApartmentState.STA);
                //    CheckerThread.IsBackground = true;
                //    CheckerThread.Start();
                //}
                manager.CheckStats();
            }     
        }
        private bool SomethingToDo()
        {
            if ((getStats.px() == 92 && getStats.py() == 105) && (manager.SomethingToBankEinlagern()))
            {
                return true;
            }
            else if (getStats.px() == 92 && getStats.py() == 105 && getStats.Geld() > Settings.MaxMoney)
            {
                return true;
            }
            else return false;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
               
                if (Settings._Autowalk & Settings.IsBotRunning & isWorkerThread)
                {
                    manager._moveManager.Move();

                    //gehört noch an die richtige position!!!!
                    //if ((Paths._Actual == null || Paths._Actual.Count == 0) && Settings._Auftraege)
                    //{
                    //    Paths._Actual = pathFinder.Directions(new Point(getStats.px(), getStats.py()), Settings.AuftragsPunkt);
                    //}
                    if ((Paths._Actual == null || Paths._Actual.Count == 0) & !SomethingToDo())
                    {
                        Paths._Actual = new List<string>();
                        MapWays actual = GetActualWayObject(Settings._huntingArea);
                        if(manager.WayUeberweisenProgress)
                        {
                            Paths._Actual = pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(92, 89));
                        }
                        else if (getStats.Geld() > Settings.MaxMoney | manager.SomethingToBank())
                        {
                            if (!(getStats.px() == 92 & getStats.py() == 105))
                            {
                                if (!manager._moveManager.UseGZK(Zauberkugel.Bank))
                                {
                                    Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(92, 105)));
                                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to bank");
                                }
                            }
                        }
                        else if (!getStats.SpeedOk() && manager.SomethingToBankEinlagern())
                        {
                           Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(92, 105)));
                           Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to bank");
                        }
                        else if (!getStats.SpeedOk() && manager.SomethingToMaha() & Settings._maha)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(96, 101)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to maha");
                        }
                        else if (!getStats.SpeedOk() && manager.SomethingtoSell() & Settings._sell)
                        {
                           Paths._Actual.AddRange(pathFinder.ShortestWayToShop(new Point(getStats.px(), getStats.py())));
                           Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to shop");
                        }
                        else if (getStats.CurrentLP() <= Settings._minLP && getStats.Geld() >= 30)
                        {
                            Paths._Actual.AddRange(pathFinder.ShortestWayToHeal(new Point(getStats.px(), getStats.py())));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to healpoint");
                        }
                        else if (getStats.CurrentLP() <= Settings._minLP && getStats.Geld() < 30)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(93, 101)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to healpoint (Gasthaus)");
                        }
                        else if (Settings.PickUpOil && (DateTime.Now - Settings.LastOilPickUp).Hours >= Settings.CollectOil)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(103, 117)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to oilpickup");
                        }
                        else if (Settings.PickUpFederation && (DateTime.Now - Settings.LastFederationPickUp).Days >= 1)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(87, 112)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to federationpickup");
                        }
                        else if (Settings.PickUpSumpfgas && (DateTime.Now - Settings.LastSumpfgasPickUp).Days >= 1)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(76, 104)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to gaspickup");
                        }
                        else if (Settings._Auftraege && manager.AuftraginProgres)
                        {
                            manager.MakeAuftrag();
                        }
                        else if (Settings._Auftraege)//gdgd
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(92, 99)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to Auftragshaus");
                        }
                        else if (Settings._AutoArbeiter)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), Settings.CaptchaCrackerPlace));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to captchacracking-point");
                        }
                        else if (Settings._huntingArea == "Random")
                        {
                            if(Settings.usediebeshoehle)
                            {
                                Paths._Actual.AddRange(pathFinder.RandomWay(new Point(getStats.px(), getStats.py())));
                            }
                            else
                            {
                                Paths._Actual.AddRange(pathFinder.RandomWayWithoutDiebeshöhle(new Point(getStats.px(), getStats.py())));
                            }
                        
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to next randompoint");
                        }
                        else if (actual.startPoint.X == getStats.px() & actual.startPoint.Y == getStats.py())
                        {
                            Paths._Actual.AddRange(actual.Way);
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move way @" + actual.Name);
                        }        
                        else
                        {
                            if (actual.Name != "StandAndWait")
                            {
                                Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), actual.startPoint));
                            }
                        }
                    }
                }
                if (Settings._Autowalk == false && isWorkerThread)
                {
                    if ((Paths._Actual == null || Paths._Actual.Count == 0))
                    {
                      if (Settings.PickUpOil & (DateTime.Now - Settings.LastOilPickUp).Days >= 1)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(103, 117)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to oilpickup");
                        }
                        else if (Settings.PickUpFederation && (DateTime.Now - Settings.LastFederationPickUp).Days >= 1)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(87, 112)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to federationpickup");
                        }
                        else if (Settings.PickUpSumpfgas && (DateTime.Now - Settings.LastSumpfgasPickUp).Days >= 1)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(76, 104)));
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Move to gaspickup");
                        }
                    }
                }
            }
            catch(Exception r) { }
        }
        private MapWays GetActualWayObject(string Name)
        {
            for (int i = 0; i < Ways.Count; i++)
            {
                if (Ways[i].Name == Name)
                {
                    return Ways[i];
                }
            }
            return null;
        }
        private void LoadBankItems()
        {
            if (Settings.Lizenz !=  "Trail")
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\BankItems.txt", System.Text.Encoding.Default);
                while ((line = file.ReadLine()) != null)
                {
                    manager.BankItems.Add(line.ToLower());
                }
                file.Close();
            }
        }
        private void LoadMahaItems()
        {
            if (Settings.Lizenz != "Trail")
            {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\ItemsToMaha.txt", System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                manager.ItemsToMaha.Add(line.ToLower());
            }
            file.Close();
            }
        }
        private void LoadPermanentInv()
        {
            if (Settings.Lizenz != "Trail")
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\PermanentInv.txt", System.Text.Encoding.Default);
                while ((line = file.ReadLine()) != null)
                {
                    manager.PermanentInventar.Add(line.ToLower());
                }
                file.Close();
            }
        }
        private void LoadSellItems()
        {
            if (Settings.Lizenz != "Trail")
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\ItemsToSell.txt", System.Text.Encoding.Default);
                while ((line = file.ReadLine()) != null)
                {
                    manager.ItemsToSell.Add(line.ToLower());
                }
                file.Close();
            }
        }
        private void Loadpaths()
        {
            string line;
            string name = "";
            List<object> list = new List<object>();
            List<string> bank = new List<string>();
            Point startPoint = new Point();
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\Paths.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("Gebiet:"))
                {
                    name = line.Substring(7);
                }
                if (line.Contains("Way:"))
                {
                    line = line.Substring(4);
                    string[] direction = line.Split(';');
                    List<string> list1 = new List<string>(direction.Length);
                    list1.AddRange(direction);
                    list.Add(list1);
                }
                if (line.Contains("Start:"))
                {
                    line = line.Substring(6);
                    string[] position = line.Split(';');
                    startPoint = new Point(Convert.ToInt32(position[0]), Convert.ToInt32(position[1]));
                }
                if (line.Contains("end"))
                {
                    Ways.Add(new MapWays(list, name, startPoint));
                    list = new List<object>();
                    name = String.Empty;
                    startPoint = new Point();
                }
                
            }
            file.Close();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url.ToString() == "http://" + Settings._World + ".freewar.de/freewar/")
            {
                Login.StartLogin(Settings._Username, Settings._Password, webBrowser1);
            }
            if (webBrowser1.Url.ToString() == "http://" + Settings._World + ".freewar.de/freewar/internal/index.php")
            {
              
                webBrowser1.Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/frset.php");
            } try
            {
            }
            catch { }
        }
        private void frmBot_Load(object sender, EventArgs e)
        {
            ChangeUserAgent(Settings._Useragent);
        }
        private void Browser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.whatsmyuseragent.com");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            manager.Actualize();
        }

        private void ambiance_Button_21_Click(object sender, EventArgs e)
        {
         
        }
    }
}
