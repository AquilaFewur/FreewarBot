using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;


namespace FreeWarBot12
{
    public class Manager
    {
        WebBrowser _wB;
        Actions actions;
        GetSatus getStats;
        public bool AuftraginProgres = false;
        DateTime _last_Bank_Access = DateTime.Now;
        public string Auftragstext = "";
        public bool WayBankinProgress = false;
        public bool WayHealinProgress = false;
        public bool WayUeberweisenProgress = false;
        public List<string> ItemsToSell= new List<string>();
        public List<string> ItemsToMaha = new List<string>();
        public List<string> BankItems = new List<string>();
        public List<string> PermanentInventar = new List<string>();
        PathFinder pathFinder;
        AbilityTrainer _AbilityTrainer;
        public MoveManager _moveManager;
        public Auftragsmanager _auftragsmanager;
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        List<Item> itemstoequip = new List<Item>();
        DateTime _lastEquipment = DateTime.Now;

        //Cookie import
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
        const int INTERNET_COOKIE_HTTPONLY = 0x00002000;

        public Manager(WebBrowser wb, GetSatus get, PathFinder p, bool isworker)
        {

            if (isworker)
            {
                pathFinder = p;
                getStats = get;
                _wB = wb;
                actions = new Actions(wb, get);
                _AbilityTrainer = new AbilityTrainer(wb);
                _moveManager = new MoveManager(wb, get);
                _auftragsmanager = new Auftragsmanager(get, wb);
            }
        }

        public void CheckStats()
        {
            try
            {
          
                Settings.LoggedIn = true;
                LoadCookie();
                if (_wB.Document.Window.Frames[7].Document.Body.OuterText.Contains("Position X: Y: "))
                {
                    _wB.Navigate("http://" + Settings._World + ".freewar.de/freewar/");
                    Paths._Actual = new List<string>();
                }
                actions.Drink(Settings._minLP);
                actions.DrinkBeer(Settings._minLP);
                getStats.Erfahrung();
                getStats.MaxLP();
                OpenInv();
                LoadInventar();
              //  Sell();
                CheckWaffeAnoderAblegen();
                OpenBankEinzahlung();
                useHealItems();
                UseProtection();
                GetAuftrag();
                MakeAuftrag();
                if (Settings._playerkiller)
                {
                    actions.AttackPlayer();
                }
                if (Settings._attack)
                {
                    actions.Attack();
                }
                if (Settings.NPCVerjagen)
                {
                    actions.Verjagen();
                }
                if (Settings._take)
                {
                    actions.Take();
                }
                if (Settings.Harvest)
                {
                    actions.Harvest();
                }
                if ((_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Wieviel Gold willst du für das Item")) & Settings._sell)
                {
                    Sell();
                }
                else if (Settings._sell && !(getStats.px() == 96 & getStats.py() == 101) && (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("main.php?arrive_eval=verkaufen") | _wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Welches deiner Items möchtest du verkaufen?")))
                {
                    Sell();
                }
                if ((getStats.px() == 96 & getStats.py() == 101) && (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Item in der Markthalle kaufen")) && Settings._maha)
                {
                    SellMaha();
                }
                OpenBankLagerung();
                if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Goldmünzen auf dein Konto eingezahlt."))
                {
                    _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php");
                }
                if (WayBankinProgress == false && WayHealinProgress == false && SomethingToBank())
                {
                    Paths._Actual = pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(92, 105));
                    WayBankinProgress = true;
                }
                {
                    WayBankinProgress = false;
                }
                if (getStats.CurrentLP() <= Settings._minLP && WayHealinProgress == false && WayBankinProgress == false)
                {
                    if (getStats.CurrentLP() <= Settings._minLP & getStats.Geld() >= 30)
                    {
                        Paths._Actual = pathFinder.ShortestWayToHeal(new Point(getStats.px(), getStats.py()));
                    }
                    else if (getStats.CurrentLP() <= Settings._minLP & getStats.Geld() < 30)
                    {
                        Paths._Actual = pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(93, 101));
                    }
                    Paths._Actual = new List<string>();
                    WayHealinProgress = true;
                }
                if (getStats.CurrentLP() > Settings._minLP & WayHealinProgress == true)
                {
                    WayHealinProgress = false;
                }
                if ((getStats.px() == 92) & (getStats.py() == 89) & IsMoneyInBankHigher() & Settings._TranserMoney)
                {
                    Ueberweisen();
                    WayUeberweisenProgress = false;
                }
                if (Settings._TranserMoney && IsMoneyInBankHigher())
                {
                    if (Paths._Actual.Count != 16)
                    {
                        WayUeberweisenProgress = true;
                    }
                }
                if (_wB.Document.Window.Frames[1].Document.Body.OuterText.Contains("Du kannst nicht 0 Goldmünzen einzahlen."))
                {
                    _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php");
                }

                TakeOilOrSumpfgas();
                TakeFederation();
                PfeileInBeutel();
                GeisterfunkeninGeisterschild();
                if ((Settings._RepairWeapons && _wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Waffen reparieren")))
                {
                    RepairWeapon();
                }


            }
            catch { }

        }
        public static string GetGlobalCookies(string uri)
        {
            uint datasize = 1024;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (InternetGetCookieEx(uri, null, cookieData, ref datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero)
                && cookieData.Length > 0)
            {
                return cookieData.ToString().Replace(';', ',');
            }
            else
            {
                return null;
            }
        }
        public void LoadCookie()
        {
            if (Settings.Cookie == null)
            {
                Settings.Cookie = GetGlobalCookies(_wB.Document.Url.AbsoluteUri);
            }
        }
        public Item GetItemfromName(string name)
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if (Settings._Items[i]._name == name.ToLower())
                {
                    return Settings._Items[i];
                }
            }
            return null;
        }   
        public void SellMaha()
        {
           for (int i = 0; i < ItemsToMaha.Count; i++)
            {
                Random rnd = new Random();
                int Random = 0;
                if ((ItemsToMaha[i].Split(';')[0]) == "Ölfass")
                {
                    Random = rnd.Next(-2, 2);
                }
                Item item = GetItemfromName(ItemsToMaha[i].Split(';')[0]);
                 if ( item != null)            
                 {
                     var encoding = new ASCIIEncoding();
                     var postData = "money=" + (Convert.ToInt32(ItemsToMaha[i].Split(';')[1])+Random).ToString();
                     postData += ("&abgabe_item=" + item._id);
                     postData += ("&anz="+ item._amount);
                     byte[] data = encoding.GetBytes(postData);
                     var myRequest =
                        (HttpWebRequest)WebRequest.Create("http://"+ Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe3");
                     myRequest.Method = "POST";
                     myRequest.ContentType = "application/x-www-form-urlencoded";
                     myRequest.ContentLength = data.Length;
                     myRequest.CookieContainer = new CookieContainer();
                     myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe3"), Settings.Cookie);
                     myRequest.Referer = "http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe2&abgabe_item="+item._id+"&anz="+item._amount;
                     var newStream = myRequest.GetRequestStream();
                     newStream.Write(data, 0, data.Length);
                     newStream.Close();
                     var response = myRequest.GetResponse();
                     var responseStream = response.GetResponseStream();
                     var responseReader = new StreamReader(responseStream);
                     responseReader.ReadToEnd();
                     _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                     Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Sell " + item._amount.ToString() + "x " + item._name + "@Markthalle");
                     System.Threading.Thread.Sleep(1000);
                     _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");      
                     break;
                 }                   
            }          
        }
        public void Sell()
        {
            for (int i = 0; i < ItemsToSell.Count; i++)
            {
                 Item item = GetItemfromName(ItemsToSell[i]);
                 if ( item != null)  
                 {
                     WebClient wc = new WebClient();                  
                     wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                     string Text = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=sell&sell_item=" + item._id + "&anz=" + item._amount);
                     _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                     Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Sell" + item._amount.ToString() + "x " + item._name + "@Shop" );
                     System.Threading.Thread.Sleep(700);
                     break;
                 }                   
            }           
        }
        public void RepairWeapon()
        {
            if (Settings._RepairWeapons)
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string quelltext = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=repair");
                quelltext = quelltext.Remove(0, quelltext.IndexOf("Benutzbare Waffen:") + 5);

                for (int i = 0; i < 1; )
                {
                    if (quelltext.Contains("<a href=\"main.php?arrive_eval=dorepair"))
                    {
                        try
                        {
                            string Name = "";
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("sell_item=") + 10);
                            string ID = quelltext.Substring(0, quelltext.IndexOf("\""));
                            quelltext = quelltext.Remove(0, quelltext.IndexOf(">") + 1);
                            Name = quelltext.Substring(0, quelltext.IndexOf("reparieren") - 1);
                            string Zustand = quelltext.Remove(0, quelltext.IndexOf("Zustand") + 8);
                            Zustand = Zustand.Substring(0, Zustand.IndexOf("%"));
                            if (Convert.ToInt32(Zustand) <= Settings._RepairWeaponsValue)
                            {

                                WebClient wc1 = new WebClient();
                                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                                string Text = wc1.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=dorepair&fsell_item=" + ID);
                                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Repair: " + Name + "@ Shop");
                                System.Threading.Thread.Sleep(1100);
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public void Einlagern()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string quelltext = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe");
            List<Item> Itemss = new List<Item>();
            for (int i = 0; i < 1; )
            {
                if (quelltext.Contains("onmouseout="))
                {
                    try
                    {
                        quelltext = quelltext.Remove(0, quelltext.IndexOf("onmouseout=") + 23);
                        string Name = quelltext.Substring(0, quelltext.IndexOf("<") - 1).ToLower();
                        string anzID;
                        quelltext = quelltext.Remove(0, Name.Length);
                        quelltext = quelltext.Remove(0, quelltext.IndexOf("id") + 8);
                        anzID = quelltext.Substring(0, quelltext.IndexOf("\""));
                        for (int k = 0; k < Settings._Items.Count; k++)
                        {
                            if (!ItemsToMahaContains(Name) & !PermanentInventar.Contains(Name))
                            {
                                Itemss.Add(new Item(anzID, Name, GetItemfromName(Name.ToLower())._amount));
                            }                         
                        }
                    }
                    catch { }
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < Itemss.Count; i++)
            {
                if((DateTime.Now - _last_Bank_Access).Seconds >= 3)
                {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string Text = wc1.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe2&abgabe_item=" + Itemss[i]._id + "&anzahl=" + Itemss[i]._amount);
                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Store " + Itemss[i]._amount.ToString() + "x " +Itemss[i]._name + "@ BaW");
                _last_Bank_Access = DateTime.Now;
                }
                break;                               
            }
        }
        public void WaffeAnoderAblegen(Item item)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string quelltext = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + item._id);
        }
        public void CheckWaffeAnoderAblegen()
        {
            int x = Settings.PX;
            int y = Settings.PY;
            if ((x == 105 && y == 100) || (x == 108 && y == 96) || (x == 113 && y == 99) || (x == 112 && y == 97))
            {
                if ((DateTime.Now - _lastEquipment).Seconds > 13 && itemstoequip.Count == 0)
                {
                    WebClient wc = new WebClient();
                    wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    string quelltext = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php");
                    string text = quelltext;
                    List<Item> list = new List<Item>();
                    for (int i = 0; i < 10; )
                    {
                        if (text.Contains("itemequipped"))
                        {
                            text = text.Remove(0, text.IndexOf("itemequipped") + 14);
                            string name = text.Substring(0, text.IndexOf("<"));
                            list.Add(GetItemfromName(name.ToLower()));

                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        WaffeAnoderAblegen(list[i]);
                    }
                    itemstoequip = list;
                    _lastEquipment = DateTime.Now;
                }
                else if ((DateTime.Now - _lastEquipment).Seconds > 13 && itemstoequip.Count != 0)
                {
                    for (int i = 0; i < itemstoequip.Count; i++)
                    {
                        WaffeAnoderAblegen(itemstoequip[i]);
                    }
                    itemstoequip = new List<Item>();
                    _lastEquipment = DateTime.Now;
                }
            }
           
            
          
        }
        private bool ItemsToMahaContains(string Name)
        {
            for (int l = 0; l < ItemsToMaha.Count; l++)
            {
                if (ItemsToMaha[l].Split(';')[0] == Name.ToLower())
                {
                    return true;
                }         
            }
            return false;
        }
        public void Einzahlen()
        {
            if (!SomethingToBankEinlagern())
            {
                Random rnd = new Random();
                var encoding = new ASCIIEncoding();
                var postData = "money=" + (Player.Money - rnd.Next(100, 200)).ToString();
                postData += ("&Submit=Einzahlen");
                byte[] data = encoding.GetBytes(postData);
                var myRequest =
                   (HttpWebRequest)WebRequest.Create("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=einzahlen2");
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                myRequest.CookieContainer = new CookieContainer();
                myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe3"), Settings.Cookie);
                myRequest.Referer = "http://" + Settings._World + ".freewar.de/internal/main.php?arrive_eval=einzahlen";
                var newStream = myRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                var response = myRequest.GetResponse();
                var responseStream = response.GetResponseStream();
                var responseReader = new StreamReader(responseStream);
                responseReader.ReadToEnd();
                _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                Settings.Action.Add(DateTime.Now.ToShortTimeString() + "Geld eingezahlt @ BAW");

            }

            getStats.Geld();
        }
        public void GeisterfunkeninGeisterschild()
        {
            if (Settings._StoreArrows)
            {
                if (IteminInventar("geisterfunke") & IteminInventar("ausgebrannter geisterschild"))
                {
                    var encoding = new ASCIIEncoding();
                    var postData = "anz_to_put=" + GetItemfromName("geisterfunke")._amount;
                    byte[] data = encoding.GetBytes(postData);
                    var myRequest =
                       (HttpWebRequest)WebRequest.Create("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("ausgebrannter geisterschild")._id);
                    myRequest.Method = "POST";
                    myRequest.ContentType = "application/x-www-form-urlencoded";
                    myRequest.ContentLength = data.Length;
                    myRequest.CookieContainer = new CookieContainer();
                    myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("ausgebrannter geisterschild")._id), Settings.Cookie);
                    myRequest.Referer = "http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("ausgebrannter geisterschild")._id;
                    var newStream = myRequest.GetRequestStream();
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                    var response = myRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var responseReader = new StreamReader(responseStream);
                    responseReader.ReadToEnd();
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Store " + GetItemfromName("geisterfunke")._amount.ToString() +  "x Geisterfunken");
                }
                if (IteminInventar("seelenkapsel") & IteminInventar("tote Seelenklinge"))
                {
                    var encoding = new ASCIIEncoding();
                    var postData = "anz_to_put=" + GetItemfromName("seelenkapsel")._amount;
                    byte[] data = encoding.GetBytes(postData);
                    var myRequest =
                       (HttpWebRequest)WebRequest.Create("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("tote Seelenklinge")._id);
                    myRequest.Method = "POST";
                    myRequest.ContentType = "application/x-www-form-urlencoded";
                    myRequest.ContentLength = data.Length;
                    myRequest.CookieContainer = new CookieContainer();
                    myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("tote Seelenklinge")._id), Settings.Cookie);
                    myRequest.Referer = "http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("tote Seelenklinge")._id;
                    var newStream = myRequest.GetRequestStream();
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                    var response = myRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var responseReader = new StreamReader(responseStream);
                    responseReader.ReadToEnd();
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " +  "Store" + GetItemfromName("seelenkapsel")._amount.ToString() + "x Seelenkapsel");
                }
            }
        }
        private bool IteminInventar(string name)
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if (Settings._Items[i]._name == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }      
        private void OpenBankEinzahlung()
        {
           
             if (getStats.Geld() > Settings.MaxMoney && getStats.px() == 92 && getStats.py() == 105)
              {
                  Einzahlen();
              }
          
        }
        private void OpenSell()
        {

            if (SomethingtoSell() && _wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("main.php?arrive_eval=verkaufen"))
            {
                _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=verkaufen");
            }
        }     
        public void PfeileInBeutel()
        {
            if (Settings._StoreArrows)
            {
                if (IteminInventar("pfeil") & IteminInventar("pfeilbeutel"))
                {
                    var encoding = new ASCIIEncoding();
                    var postData = "anz_to_put=" + GetItemfromName("pfeil")._amount;
                    byte[] data = encoding.GetBytes(postData);
                    var myRequest =
                       (HttpWebRequest)WebRequest.Create("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("pfeilbeutel")._id);
                    myRequest.Method = "POST";
                    myRequest.ContentType = "application/x-www-form-urlencoded";
                    myRequest.ContentLength = data.Length;
                    myRequest.CookieContainer = new CookieContainer();
                    myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("pfeilbeutel")._id), Settings.Cookie);
                    myRequest.Referer = "http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("pfeilbeutel")._id;
                    var newStream = myRequest.GetRequestStream();
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                    var response = myRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var responseReader = new StreamReader(responseStream);
                    responseReader.ReadToEnd();
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Store Pfeil");
                }
                if (IteminInventar("wakrudpilz") & IteminInventar("wakrudbeutel"))
                {
                    var encoding = new ASCIIEncoding();
                    var postData = "anz_to_put=" + GetItemfromName("wakrudpilz")._amount;
                    byte[] data = encoding.GetBytes(postData);
                    var myRequest =
                       (HttpWebRequest)WebRequest.Create("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("wakrudbeutel")._id);
                    myRequest.Method = "POST";
                    myRequest.ContentType = "application/x-www-form-urlencoded";
                    myRequest.ContentLength = data.Length;
                    myRequest.CookieContainer = new CookieContainer();
                    myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("wakrudbeutel")._id), Settings.Cookie);
                    myRequest.Referer = "http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("wakrudbeutel")._id;
                    var newStream = myRequest.GetRequestStream();
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                    var response = myRequest.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var responseReader = new StreamReader(responseStream);
                    responseReader.ReadToEnd();
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Store Wakrudpilz");
                }
            }
        }
        public void GetAuftrag()
        {
            if (Settings._Auftraege)
            {
               if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("arrive_eval=getmission"))
               {
                   WebClient wc1 = new WebClient();
                   wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                   Auftragstext = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=getmission");
                   AuftraginProgres = true;
                   _auftragsmanager._Auftragfinished = false;
                   _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php");
               }
               else if(_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("main.php?finish=1") & AuftraginProgres == false)
               {
                   WebClient wc1 = new WebClient();
                   wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                   Auftragstext = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?finish=1");
                   _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php");
               }
                
            }
        }
        public void MakeAuftrag()
        {
            _auftragsmanager.selectAuftrag(Auftragstext);
            if(_auftragsmanager._Auftragfinished)
            { AuftraginProgres = false; }
        }
        private bool IsMoneyInBankHigher()
        {
            if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Dein Banklimit liegt bei"))
            {
                string s = _wB.Document.Window.Frames[1].Document.Body.OuterHtml;
                s = s.Remove(0, s.IndexOf("Du hast")+8);
                int money = Convert.ToInt32(s.Substring(0, s.IndexOf("G") - 1).Replace(".", ""));
                if (Settings._TranferMoney < money)
                {
                    return true;
                }
                else
                {
                   return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void useHealItems()
        {
            if (getStats.CurrentLP() <= Settings._minLP)
            {
                if (IteminInventar("gebratenes kaktusfleisch"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("gebratenes kaktusfleisch")._id);
                }
                else if (IteminInventar("furgorpilz"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("furgorpilz")._id);
                }
                else if (IteminInventar("saftiger apfel"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("saftiger apfel")._id);
                }
                else if (IteminInventar("blutwurm im salzmantel"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("blutwurm im salzmantel")._id);
                }
                else if (IteminInventar("buraner schlachtplatte"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("buraner schlachtplatte")._id);
                }
                else if (IteminInventar("feuereintopf"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("feuereintopf")._id);
                }
                else if (IteminInventar("fischsuppe"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("fischsuppe")._id);
                }
                else if (IteminInventar("garnierter kuhkopf"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("garnierter kuhkopf")._id);
                }
                else if (IteminInventar("gewebewurm im brot"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("gewebewurm im brot")._id);
                }
                else if (IteminInventar("hasenfell-zahnseide"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("hasenfell-zahnseide")._id);
                }
                else if (IteminInventar("klauenbartrein-burger"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("klauenbartrein-burger")._id);
                }
                else if (IteminInventar("larafsalat"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("larafsalat")._id);
                }
                else if (IteminInventar("lopaknuss-eis"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("lopaknuss-eis")._id);
                }
                else if (IteminInventar("phasenbrei"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("phasenbrei")._id);
                }
                else if (IteminInventar("pilzsuppe"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("pilzsuppe")._id);
                }
                else if (IteminInventar("rote korallengrütze"))
                {
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("rote korallengrütze")._id);
                }
                else 
                {
                    for (int i = 0; i < Settings._Heal_Items.Count; i++)
                    {
                        if (IteminInventar(Settings._Heal_Items[i].ToLower()))
                        {
                            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Use heal item");
                            _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName(Settings._Heal_Items[i].ToLower())._id);
                        }
                    }
                }
            }
        }    
        private void OpenBankLagerung()
        {
            if (getStats.px() == 92 && getStats.py() == 105)
            {
                Einlagern();
            }
        }
        private void OpenInv()
        {
             if (_wB.Document.Window.Frames[6].Document.Body.OuterHtml.Contains("item.php?action=openinv"))
            {
                _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=openinv");
            }
        }
        public bool SomethingToBank()
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if (BankItems.Contains(Settings._Items[i]._name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        public void UseProtection()
        {
            if (Settings.UseProtection)
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string Text = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php");
                if (!Text.Contains("title=\"Schutz"))
                {
                    Item i = GetItemfromName("schutz der händler");
                    if (i == null)
                    {
                        i = GetItemfromName("schutz der mächtigen Händler");
                    }
                    if (i == null)
                    {
                        i = GetItemfromName("schutzzauber");
                    }
                    if (i == null)
                    {
                        i = GetItemfromName("schwacher schutzzauber");
                    }
                    if (i == null)
                    {
                        i = GetItemfromName("starker schutzzauber");
                    }
                    if (i != null)
                    {

                        WebClient wc1 = new WebClient();
                        wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                        string Text1 = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + i._id);
                        _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                    }
                }
            }
        }
        public bool SomethingToBankEinlagern()
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if ((BankItems.Contains(Settings._Items[i]._name.ToLower())) | !ItemsToSell.Contains(Settings._Items[i]._name.ToLower()) & !PermanentInventar.Contains(Settings._Items[i]._name.ToLower()) & !ItemsToMahaContains(Settings._Items[i]._name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        public bool SomethingToMaha()
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if (ItemsToMahaContains(Settings._Items[i]._name))
                    {
                        return true;
                    }
                
            }
            return false;
        }
        public bool SomethingtoSell()
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if (ItemsToSell.Contains(Settings._Items[i]._name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        private void Ueberweisen()
        {
            var encoding = new ASCIIEncoding();
            var postData = "name=" + Settings._TransferReceiver;
            postData += ("&money=" + Settings._TranferMoney);
            postData += ("&verwendung=" + " ");
            byte[] data = encoding.GetBytes(postData);
            var myRequest =
               (HttpWebRequest)WebRequest.Create("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=spielen2&nomessage=ignore");
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            myRequest.CookieContainer = new CookieContainer();
            myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=spielen2&nomessage=ignore"), Settings.Cookie);
            myRequest.Referer = "http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=spielen";
            var newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            var response = myRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            var responseReader = new StreamReader(responseStream);
            responseReader.ReadToEnd();
            Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Transfer Money To: " + Settings._TransferReceiver);
        }
        private void TakeOilOrSumpfgas()
        {
            if (Settings.PickUpOil & (DateTime.Now - Settings.LastOilPickUp).Days >= 1)
            {
                if ((getStats.px() == 103 & getStats.py() == 117))
                {
                    Settings.LastOilPickUp = DateTime.Now;
                    WebClient wc = new WebClient();
                    wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    string quelltext = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php");
                    if (quelltext.Contains("arrive_eval=drink"))
                    {
                        string CheckID = quelltext.Remove(0, quelltext.IndexOf("checkid=") + 8);
                        CheckID = CheckID.Substring(0, CheckID.IndexOf("\""));
                        _wB.Document.Window.Frames[1].Navigate("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=drink&checkid=" + CheckID);
                        Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Pick up oil");

                    }
                }
            }
            if (Settings.PickUpSumpfgas & (DateTime.Now - Settings.LastSumpfgasPickUp).Days >= 1)
            {
                if ((getStats.px() == 76 & getStats.py() == 104))
                {
                    Settings.LastSumpfgasPickUp = DateTime.Now;
                    WebClient wc = new WebClient();
                    wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    string quelltext = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php");
                    if (quelltext.Contains("arrive_eval=drink"))
                    {
                        string CheckID = quelltext.Remove(0, quelltext.IndexOf("checkid=") + 8);
                        CheckID = CheckID.Substring(0, CheckID.IndexOf("\""));
                        _wB.Document.Window.Frames[1].Navigate("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=drink&checkid=" + CheckID);
                        Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Pick up gas");
                    }
                }
            }
        }
        private void TakeFederation()
        {
            if (Settings.PickUpFederation & (DateTime.Now - Settings.LastFederationPickUp).Days >= 1)
            {
                if ((getStats.px() == 87 & getStats.py() == 112))
                {
                    Settings.LastFederationPickUp = DateTime.Now;
                    WebClient wc = new WebClient();
                    wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    string quelltext = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php");
                    if (quelltext.Contains("arrive_eval=drink"))
                    {
                        _wB.Document.Window.Frames[1].Navigate("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=drinkwater");
                        Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Pick up federation");
                    }
                }
            }
        }
        public void Actualize()
        {
            try
            {
                _wB.Document.Window.Frames[8].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/menu.php?reload=true");
            }
            catch { }
        }
        private void LoadInventar()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string quelltext = wc.DownloadString("http://"+Settings._World +".freewar.de/freewar/internal/item.php");
            quelltext = quelltext.Replace("p.listitemrow", string.Empty);
            quelltext = quelltext.Remove(0, quelltext.LastIndexOf("listitemrow\" id=\"filterrow") + 7);
            Settings._Items = new List<Item>();
            for (int i = 0; i < 1; )
            {
                if (quelltext.Contains("listitemrow"))
                {
                    try
                    {
                        string amount = "1";
                        string name;
                         quelltext = quelltext.Remove(0, quelltext.IndexOf("listitemrow"));
                         if (quelltext.Substring(0, 50).Contains("itemamount"))
                         {
                             quelltext = quelltext.Remove(0, quelltext.IndexOf("itemamount") + 12);
                             amount = quelltext.Substring(0, quelltext.IndexOf("x"));
                             quelltext = quelltext.Remove(0, amount.Length + 12);
                             name = quelltext.Substring(0, quelltext.IndexOf("</b>"));
                         }
                         else if (quelltext.Substring(0, 45).Contains("itemequipped"))
                         {
                             name = quelltext.Remove(0, 40);
                             name = name.Substring(0, name.IndexOf("</"));
                         }
                         else
                         {
                             name = quelltext.Substring(16, quelltext.IndexOf("</b>") - 16);
                         }
                        quelltext = quelltext.Remove(0, quelltext.IndexOf("item_id=") + 8);
                        string ID = quelltext.Substring(0, quelltext.IndexOf("\""));
                        Settings._Items.Add(new Item(ID, name.ToLower(), amount));
                    }
                    catch { }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
