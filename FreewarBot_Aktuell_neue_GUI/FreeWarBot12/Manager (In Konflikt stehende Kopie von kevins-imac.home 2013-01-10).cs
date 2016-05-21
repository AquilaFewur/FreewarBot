using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Web;
using System.Net;
using System.IO;


namespace FreeWarBot12
{
    class Manager
    {   
        WebBrowser _wB;
        Actions actions;
        GetSatus getStats;
        public bool WayBankinProgress = false;
        public bool WayHealinProgress = false;
        public List<string> ItemsToSell = new List<string>();
        public List<string> ItemsToMaha = new List<string>();
        public List<string> BankItems = new List<string>();
        public List<string> PermanentInventar = new List<string>();
        PathFinder pathFinder;
        AbilityTrainer _AbilityTrainer;
        public MoveManager _moveManager;
        Timer t1 = new Timer();
        public Manager(WebBrowser wb, GetSatus get, PathFinder p)
        {
            pathFinder = p;
            getStats = get;
            _wB = wb;
            actions = new Actions(wb, get);
            _AbilityTrainer = new AbilityTrainer(wb);
            _moveManager = new MoveManager(wb, get);
        }   
        public Item GetItemfromName(string name)
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if (Settings._Items[i]._name == name)
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
                Item item = GetItemfromName(ItemsToMaha[i].Split(';')[0]);
                 if ( item != null)  
                 {
                     var encoding = new ASCIIEncoding();
                     var postData = "money=" + ItemsToMaha[i].Split(';')[1];
                     postData += ("&abgabe_item=" + item._id);
                     postData += ("&anz="+ item._amount);
                     byte[] data = encoding.GetBytes(postData);
                     var myRequest =
                        (HttpWebRequest)WebRequest.Create("http://welt"+ Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe3");
                     myRequest.Method = "POST";
                     myRequest.ContentType = "application/x-www-form-urlencoded";
                     myRequest.ContentLength = data.Length;
                     myRequest.CookieContainer = new CookieContainer();
                     myRequest.CookieContainer.SetCookies(new Uri("http://welt" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe3"), _wB.Document.Cookie);
                     myRequest.Referer = "http://welt" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe2&abgabe_item="+item._id+"&anz="+item._amount;
                     var newStream = myRequest.GetRequestStream();
                     newStream.Write(data, 0, data.Length);
                     newStream.Close();
                     var response = myRequest.GetResponse();
                     var responseStream = response.GetResponseStream();
                     var responseReader = new StreamReader(responseStream);
                     responseReader.ReadToEnd();
                     _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php");
                     System.Threading.Thread.Sleep(500);
                     break;
                 }                   
            }
           _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php");            
        }
        public void Sell()
        {
            for (int i = 0; i < ItemsToSell.Count; i++)
            {
                 Item item = GetItemfromName(ItemsToSell[i]);
                 if ( item != null)  
                 {
                     WebClient wc = new WebClient();                  
                     wc.Headers.Add(HttpRequestHeader.Cookie, _wB.Document.Cookie);
                     string Text = wc.DownloadString("http://welt" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=sell&sell_item=" + item._id + "&anz=" + item._amount);
                     _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php");
                     System.Threading.Thread.Sleep(499);
                     break;
                 }                   
            }           
        }
        public void Einlagern()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Cookie, _wB.Document.Cookie);
            string quelltext = wc.DownloadString("http://welt1.freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe");
            List<Item> Itemss = new List<Item>();
            for (int i = 0; i < 1; )
            {
                if (quelltext.Contains("onmouseout="))
                {
                    try
                    {
                        quelltext = quelltext.Remove(0, quelltext.IndexOf("onmouseout=") + 23);
                        string Name = quelltext.Substring(0, quelltext.IndexOf("<") - 1).ToLower();
                        quelltext = quelltext.Remove(0, quelltext.IndexOf("id") + 8);
                        string anzID = quelltext.Substring(0, quelltext.IndexOf("\""));
                        for (int k = 0; k < Settings._Items.Count; k++)
                        {
                            if (!ItemsToMahaContains(Name) & !PermanentInventar.Contains(Name))
                            {
                                Itemss.Add(new Item(anzID, Name, Settings._Items[i]._amount));
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
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, _wB.Document.Cookie);
                string Text = wc1.DownloadString("http://welt1.freewar.de/freewar/internal/main.php?arrive_eval=itemabgabe2&abgabe_item=" + Itemss[i]._id + "&anzahl=" + Itemss[i]._amount);
                break;                               
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
            Random rnd =  new Random();
            foreach (HtmlElement elem in _wB.Document.Window.Frames[1].Document.All)
            {
                if (elem.Name == "money")
                {
                    elem.InnerText = (Player.Money - rnd.Next(Settings.MaxMoney / 10, Settings.MaxMoney / 8)).ToString();      // euer Benutzername              
                }        
            }
             foreach (HtmlElement elem in _wB.Document.Window.Frames[1].Document.All)
                {

                    if (elem.GetAttribute("value") == "Einzahlen")
                    {
                        elem.InvokeMember("Click");
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
            if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("main.php?arrive_eval=einzahlen") & Player.Money > Settings.MaxMoney)
            {
                _wB.Document.Window.Frames[1].Navigate("http://welt1.freewar.de/freewar/internal/main.php?arrive_eval=einzahlen");
            }
        }
        private void OpenSell()
        {

            if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("main.php?arrive_eval=verkaufen") & SomethingtoSell())
            {
                _wB.Document.Window.Frames[1].Navigate("http://welt1.freewar.de/freewar/internal/main.php?arrive_eval=verkaufen");
            }
        }
        public void CheckStats()
        {
            try
            {
                getStats.Erfahrung();
                if (_wB.Document.Window.Frames[7].Document.Body.OuterText.Contains("Position X: Y: "))
                {
                    _wB.Navigate("http://welt" + Settings._World + ".freewar.de/freewar/");
                    Paths._Actual = new List<string>();
                }
                Settings.LoggedIn = true;
                OpenInv();            
                LoadInventar();
                OpenBankEinzahlung();
                useHealItems();                     
                if (Settings._attack)
                {
                    actions.Attack();
                }
                if (Settings._take)
                {
                    actions.Take();
                }
                if ((_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Wieviel Gold willst du für das Item")))
                {
                    Sell();
                }
                else if ((_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("main.php?arrive_eval=verkaufen") | _wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Welches deiner Items möchtest du verkaufen?")) & !(getStats.px() == 96 & getStats.py() == 101))
                {
                    Sell();
                }
                if ((_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Item in der Markthalle kaufen")) & (getStats.px() == 96 & getStats.py() == 101))
                {
                    SellMaha();
                }
                if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Welchen Betrag möchtest du auf dein Konto einzahlen"))
                {
                    Einzahlen();
                }
                OpenBankLagerung();
                if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("Goldmünzen auf dein Konto eingezahlt."))
                {
                    _wB.Document.Window.Frames[1].Navigate("http://welt"+ Settings._World + ".freewar.de/freewar/internal/main.php");
                }
                if (SomethingToBank() & WayBankinProgress == false & WayHealinProgress == false)
                {
                    Paths._Actual = pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(92, 105));
                    WayBankinProgress = true;
                }
                else
                {
                    WayBankinProgress = false;
                }
                if (getStats.CurrentLP() <= Settings._minLP & WayHealinProgress == false & WayBankinProgress == false)
                {
                        if (getStats.CurrentLP() <= Settings._minLP & getStats.Geld() >= 30)
                        {
                            Paths._Actual = pathFinder.ShortestWayToHeal(new Point(getStats.px(), getStats.py()));
                        }
                        else if (getStats.CurrentLP() <= Settings._minLP & getStats.Geld() < 30)
                        {
                            Paths._Actual =pathFinder.Directions(new Point(getStats.px(), getStats.py()), new Point(93, 101));
                        }
                    Paths._Actual = new List<string>();
                    WayHealinProgress = true;
                }
                if (getStats.CurrentLP() > Settings._minLP & WayHealinProgress == true)
                {
                    WayHealinProgress = false;
                }            
                actions.Drink(Settings._minLP);
                actions.DrinkBeer(Settings._minLP);
            }
            catch { }
        }

        private void useHealItems()
        {
            if (IteminInventar("nolulawurzel") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("nolulawurzel")._id);
            }
            else if (IteminInventar("gebratenes kaktusfleisch") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("kaktusfleisch")._id);
            }
            else if (IteminInventar("furgorpilz") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("furgorpilz")._id);
            }
            else if (IteminInventar("saftiger apfel") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("saftiger apfel")._id);
            }
            else if (IteminInventar("blutwurm im salzmantel") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("blutwurm im salzmantel")._id);
            }
            else if (IteminInventar("buraner schlachtplatte") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("buraner schlachtplatte")._id);
            }
            else if (IteminInventar("feuereintopf") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("feuereintopf")._id);
            }
            else if (IteminInventar("fischsuppe") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("fischsuppe")._id);
            }
            else if (IteminInventar("garnierter kuhkopf") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("garnierter kuhkopf")._id);
            }
            else if (IteminInventar("gewebewurm im brot") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("gewebewurm im brot")._id);
            }
            else if (IteminInventar("hasenfell-zahnseide") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("hasenfell-zahnseide")._id);
            }
            else if (IteminInventar("klauenbartrein-burger") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("klauenbartrein-burger")._id);
            }
            else if (IteminInventar("larafsalat") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("larafsalat")._id);
            }
            else if (IteminInventar("lopaknuss-eis") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("lopaknuss-eis")._id);
            }
            else if (IteminInventar("phasenbrei") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("phasenbrei")._id);
            }
            else if (IteminInventar("pilzsuppe") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("pilzsuppe")._id);
            }
            else if (IteminInventar("rote korallengrütze") & getStats.CurrentLP() <= Settings._minLP)
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("rote korallengrütze")._id);
            }
        }    
        private void OpenBankLagerung()
        {
            if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("arrive_eval=itemabgabe"))
            {
                Einlagern();
            }
        }
        private void OpenInv()
        {
             if (_wB.Document.Window.Frames[6].Document.Body.OuterHtml.Contains("item.php?action=openinv"))
            {
                _wB.Document.Window.Frames[6].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/item.php?action=openinv");
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
        public bool SomethingToBankEinlagern()
        {
            for (int i = 0; i < Settings._Items.Count; i++)
            {
                if (BankItems.Contains(Settings._Items[i]._name.ToLower()) & !ItemsToSell.Contains(Settings._Items[i]._name.ToLower()) & PermanentInventar.Contains(Settings._Items[i]._name.ToLower()) & ItemsToMahaContains(Settings._Items[i]._name.ToLower()))
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
        private void LoadInventar()
        {
            string quelltext = _wB.Document.Window.Frames[6].Document.Body.InnerHtml;
            Settings._Items = new List<Item>();
            for (int i = 0; i < 1; )
            {
                if (quelltext.Contains("listitemrow"))
                {
                    try
                    {
                        string amount = "1";
                        quelltext = quelltext.Remove(0, quelltext.IndexOf("listitemrow")+15);
                        if (quelltext.Substring(0, 30).Contains("itemamount"))
                        {
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("itemamount>") + 11);
                            amount = quelltext.Substring(0, quelltext.IndexOf("x"));
                            quelltext = quelltext.Remove(0, amount.Length + 12);
                        }                    
                        string name = quelltext.Substring(0, quelltext.IndexOf("</B>"));
                        quelltext = quelltext.Remove(0, quelltext.IndexOf("item_id=") + 8);
                        string ID = quelltext.Substring(0, quelltext.IndexOf("\">"));
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
