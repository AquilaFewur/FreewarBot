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
        GetSatus getStats;
        Manager manager;
        PathFinder pathFinder = new PathFinder();
        public List<MapWays> Ways = new List<MapWays>();
        public frmBot()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public void StartBot()
        {
            Player.Name = Settings._Username;
            getStats = new GetSatus(webBrowser1);
            manager = new Manager(webBrowser1, getStats, pathFinder);
            pathFinder.LoadPoints();
            LoadAllFiles();
            
            webBrowser1.Navigate("http://welt" + Settings._World + ".freewar.de/freewar/");
            timer2.Start();
            timer3.Start();
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
            if (Settings.IsBotRunning)
            {
                manager.CheckStats();
            }
        }
        private bool SomethingToDo()
        {
            if ((getStats.px() == 92 & getStats.py() == 105) & (manager.SomethingToBankEinlagern()))
            {
                return true;
            }
            else if (getStats.px() == 92 & getStats.py() == 105 & getStats.Geld() > Settings.MaxMoney)
            {
                return true;
            }
            else return false;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Settings._Autowalk & Settings.IsBotRunning)
                {
                    manager._moveManager.Move();
                    if (Paths._Actual.Count == 0 & !SomethingToDo())
                    {
                        MapWays actual = GetActualWayObject(Settings._huntingArea);
                        if (getStats.Geld() > Settings.MaxMoney | manager.SomethingToBank())
                        {
                            if (!manager._moveManager.UseGZK(Zauberkugel.Bank))
                            {
                                Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(92, 105)));
                            }
                        }
                        else if (!getStats.SpeedOk() & manager.SomethingToMaha() & Settings._maha)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(96, 101)));
                        }
                        else if (!getStats.SpeedOk() & manager.SomethingtoSell() & Settings._sell)
                        {
                           Paths._Actual.AddRange(pathFinder.ShortestWayToShop(new Point(getStats.px(), getStats.py())));
                        }
                        else if (getStats.CurrentLP() <= Settings._minLP & getStats.Geld() >= 30)
                        {
                            Paths._Actual.AddRange(pathFinder.ShortestWayToHeal(new Point(getStats.px(), getStats.py())));
                        }
                        else if (getStats.CurrentLP() <= Settings._minLP & getStats.Geld() < 30)
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(93, 101)));
                        }
                        else if (Settings._huntingArea == "Random")
                        {
                            Paths._Actual.AddRange(pathFinder.RandomWay(new Point(getStats.px(), getStats.py())));
                        }
                        else if (actual.startPoint.X == getStats.px() & actual.startPoint.Y == getStats.py())
                        {
                            Paths._Actual.AddRange(actual.Way);
                        }
                        else
                        {
                            Paths._Actual.AddRange(pathFinder.Directions(new Point(getStats.px(), getStats.py()), actual.startPoint));
                        }
                    }
                }
            }
            catch { }
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
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\BankItems.txt", System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                manager.BankItems.Add(line.ToLower());
            }
        }
        private void LoadMahaItems()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\ItemsToMaha.txt", System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                manager.ItemsToMaha.Add(line.ToLower());
            }
        }
        private void LoadPermanentInv()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\PermanentInv.txt", System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                manager.PermanentInventar.Add(line.ToLower());
            }
        }
        private void LoadSellItems()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\ItemsToSell.txt", System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                manager.ItemsToSell.Add(line.ToLower());
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
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url.ToString() == "http://welt" + Settings._World + ".freewar.de/freewar/")
            {
                Login.StartLogin(Settings._Username, Settings._Password, webBrowser1);
            }
            if (webBrowser1.Url.ToString() == "http://welt" + Settings._World + ".freewar.de/freewar/internal/index.php")
            {
              
                webBrowser1.Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/frset.php");
            }
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
    }
}
