using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;

namespace FreeWarBot12
{
    class Actions
    {
        private WebBrowser _wB;
       
        List<string> wiederID = new List<string>();
        //frmKampfrechner frm = new frmKampfrechner();
        Kampfrechner kmpfrechner = new Kampfrechner();
        
        GetSatus getStats;
        public Actions(WebBrowser wB, GetSatus get)
        {
            getStats = get;
            _wB = wB;
            //frm.Show();
        }

        public void Attack()
        {   
            try
            {
                string quelltext = _wB.Document.Window.Frames[1].Document.Body.InnerHtml;
                List<NPC> _NPC = new List<NPC>();
                for (int i = 0; i < 1; )
                {
                    if (quelltext.Contains("listusersrow"))
                    {
                        try
                        {
                            string name;
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("listusersrow"));
                            quelltext = quelltext.Remove(0, 16);
                            if (quelltext.Substring(0, 40).Contains("vAlign=top><A"))
                            {
                                name = quelltext.Remove(0, quelltext.IndexOf("vAlign=top><B>") + 14);
                                name = name.Substring(0, name.IndexOf("</B>")-1);
                            }
                            else
                            {
                                name = quelltext.Substring(0, quelltext.IndexOf("</B>") - 1);
                            }
                            if (name == "Schatzsucher")
                            {
                                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Put money to ground: " + name);
                                PutMoneyToGround(100);
                                System.Threading.Thread.Sleep(500);
                                
                            }
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("class=fastattack href=") + 23);
                            string link = "";
                            if (quelltext.Contains("\">Schnellangriff"))
                            {
                                link = quelltext.Substring(0, quelltext.IndexOf("\">Schnellangriff"));
                                string CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                string NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.Length);
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                quelltext = quelltext.Remove(0, quelltext.IndexOf("Angriffsstärke: ") + 16);
                                int staerke = Convert.ToInt32(quelltext.Substring(0, quelltext.IndexOf(".")));
                                _NPC.Add(new NPC(name, "http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpc&checkid=" + CheckID + "&act_npc_id=" + NPCID, staerke));
                            }
                            else
                            {
                                link = quelltext.Substring(0, quelltext.IndexOf("Angreifen</A>"));
                                string CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                string NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.IndexOf("\""));
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                quelltext = quelltext.Remove(0, quelltext.IndexOf("Angriffsstärke: ") + 16);
                                int staerke = Convert.ToInt32(quelltext.Substring(0, quelltext.IndexOf(".")));
                                WebClient wc = new WebClient();
                                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                                link = wc.DownloadString("http://"+ Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpcmenu&checkid=" + CheckID+"&act_npc_id=" + NPCID);
                                CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.IndexOf("&"));
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                _NPC.Add(new NPC(name, "http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpc&checkid=" + CheckID + "&act_npc_id=" + NPCID, staerke));
                            }
                          
                            
                        }
                        catch(Exception e) { }
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 0; i < _NPC.Count; i++)
                {
                    try
                    {
                    
                     WebClient wc = new WebClient();
                     wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                     string Text = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php");
                     string Text1 = "";
                     Text = Text.Replace("healthcritical\" title=\"Verräter", string.Empty);
                     if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthok\""))
                     {

                        Text1 = Text.Remove(0, Text.IndexOf("class=\"healthok\"") + 20);
                        Text1 = Text1.Substring(0, Text1.IndexOf("<"));

                     }

                     if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthmed\""))
                    {

                        Text1 = Text.Remove(0, Text.IndexOf("class=\"healthmed\"") + 21);
                        Text1 = Text1.Substring(0, Text1.IndexOf("<"));

                    }

                     if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthcritical\""))
                    {

                         Text1 = Text.Remove(0, Text.IndexOf("class=\"healthcritical\"") + 26);
                         Text1 = Text1.Substring(0, Text1.IndexOf("<"));
                    }
                     if (!wiederID.Contains(_NPC[i].Link))
                     {
                         if (kmpfrechner.BerechneKampf(getStats.Angriffsstärke(), getStats.Verdeitigungsstärke(), Convert.ToInt32(Text1), _NPC[i].Name))
                         {
                             if (!Settings._Avoid_NPC.Contains(_NPC[i].Name.ToLower()))
                             {
                                 Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Attack: " + _NPC[i].Name);
                                 _wB.Document.Window.Frames[1].Navigate(_NPC[i].Link);

                                 System.Threading.Thread.Sleep(500);
                                 _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                             }
                         }
                         else
                         {
                             Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "NPC too strong: " + _NPC[i].Name);
                             wiederID.Add(_NPC[i].Link);
                             _NPC.RemoveAt(i);

                         }

                     }    
                    }
                    catch { }
                }
            }
            catch { }
        }
 
        public void Verjagen()
        {
            try
            {
                string quelltext = _wB.Document.Window.Frames[1].Document.Body.InnerHtml;
                List<NPC> _NPC = new List<NPC>();
                for (int i = 0; i < 1; )
                {
                    if (quelltext.Contains("listusersrow"))
                    {
                        try
                        {
                            string name;
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("listusersrow"));
                            quelltext = quelltext.Remove(0, 16);
                            if (quelltext.Substring(0, 40).Contains("vAlign=top><A"))
                            {
                                name = quelltext.Remove(0, quelltext.IndexOf("vAlign=top><B>") + 14);
                                name = name.Substring(0, name.IndexOf("</B>") - 1);
                            }
                            else
                            {
                                name = quelltext.Substring(0, quelltext.IndexOf("</B>") - 1);
                            }
                            if (name == "Schatzsucher")
                            {
                                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Put money to ground: " + name);
                                PutMoneyToGround(100);
                                System.Threading.Thread.Sleep(500);

                            }
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("class=fastchase") + 23);
                            string link = "";
                            if (quelltext.Contains("\">Verjagen"))
                            {
                                link = quelltext.Substring(0, quelltext.IndexOf("\">Verjagen"));
                                string CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                string NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.Length);
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                quelltext = quelltext.Remove(0, quelltext.IndexOf("Angriffsstärke: ") + 16);
                                int staerke = Convert.ToInt32(quelltext.Substring(0, quelltext.IndexOf(".")));
                                _NPC.Add(new NPC(name, "http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=chasenpc&checkid=" + CheckID + "&act_npc_id=" + NPCID, staerke));
                            }
                            else
                            {
                                link = quelltext.Substring(0, quelltext.IndexOf("Angreifen</A>"));
                                string CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                string NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.IndexOf("\""));
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                quelltext = quelltext.Remove(0, quelltext.IndexOf("Angriffsstärke: ") + 16);
                                int staerke = Convert.ToInt32(quelltext.Substring(0, quelltext.IndexOf(".")));
                                WebClient wc = new WebClient();
                                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                                link = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpcmenu&checkid=" + CheckID + "&act_npc_id=" + NPCID);
                                CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.IndexOf("&"));
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                _NPC.Add(new NPC(name, "http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=chasenpc&checkid=" + CheckID + "&act_npc_id=" + NPCID, staerke));
                            }
                        }
                        catch (Exception e) { }
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 0; i < _NPC.Count; i++)
                {
                    try
                    {

                        WebClient wc = new WebClient();
                        wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                        string Text = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php");
                        string Text1 = "";
                        Text = Text.Replace("healthcritical\" title=\"Verräter", string.Empty);
                        if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthok\""))
                        {

                            Text1 = Text.Remove(0, Text.IndexOf("class=\"healthok\"") + 20);
                            Text1 = Text1.Substring(0, Text1.IndexOf("<"));

                        }

                        if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthmed\""))
                        {

                            Text1 = Text.Remove(0, Text.IndexOf("class=\"healthmed\"") + 21);
                            Text1 = Text1.Substring(0, Text1.IndexOf("<"));

                        }

                        if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthcritical\""))
                        {

                            Text1 = Text.Remove(0, Text.IndexOf("class=\"healthcritical\"") + 26);
                            Text1 = Text1.Substring(0, Text1.IndexOf("<"));
                        }
                        if (!wiederID.Contains(_NPC[i].Link))
                        {
                            if (kmpfrechner.BerechneKampf(getStats.Angriffsstärke(), getStats.Verdeitigungsstärke(), Convert.ToInt32(Text1), _NPC[i].Name))
                            {
                                if (_NPC[i].Name.ToLower() != "alter mann" & _NPC[i].Name.ToLower() != "geist der ")
                                {
                                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Attack: " + _NPC[i].Name);
                                    _wB.Document.Window.Frames[1].Navigate(_NPC[i].Link);

                                    System.Threading.Thread.Sleep(500);
                                    _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");
                                }
                            }
                            else
                            {
                                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "NPC too strong: " + _NPC[i].Name);
                                wiederID.Add(_NPC[i].Link);
                                _NPC.RemoveAt(i);

                            }

                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
   
        public void PutMoneyToGround(int money)
        {
            if (getStats.Geld() >= money)
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string s = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=moneydrop1");
                s = s.Remove(0, s.IndexOf("2&checkid") + 10);
                s = s.Substring(0, s.IndexOf("\""));

                var encoding = new ASCIIEncoding();
                var postData = "moneytodrop=" + money.ToString();
                byte[] data = encoding.GetBytes(postData);
                var myRequest =
                   (HttpWebRequest)WebRequest.Create("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=moneydrop2&checkid=" + s);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                myRequest.CookieContainer = new CookieContainer();
                myRequest.CookieContainer.SetCookies(new Uri("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=moneydrop2&checkid=" + s), Settings.Cookie);
                myRequest.Referer = "http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=moneydrop1";
                var newStream = myRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                var response = myRequest.GetResponse();
                var responseStream = response.GetResponseStream();
                var responseReader = new StreamReader(responseStream);
                responseReader.ReadToEnd();
                _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php");

            }
        }
        public void AttackPlayer()
        {
            try
            {
                string quelltext = _wB.Document.Window.Frames[1].Document.Body.InnerHtml;
                List<NPC> _NPC = new List<NPC>();
                for (int i = 0; i < 1; )
                {
                    if (quelltext.Contains("listusersrow"))
                    {
                        try
                        {
                            string name = "";
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("listusersrow"));
                            quelltext = quelltext.Remove(0, 16);
                           string stri = quelltext.Substring(0, quelltext.IndexOf("XP:")+ 15);
                           string id = stri.Remove(0, stri.IndexOf("id=")+3);
                            id = id.Substring(0, id.IndexOf("\""));
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("class=fastattack href=") + 23);
                            string xp = stri.Remove(0, stri.IndexOf("XP:") + 4);
                            xp = xp.Substring(0, xp.IndexOf("(<") - 1);
                            Item sichtdeslebens = GetItemfromName("sicht des lebens");
                            Item sichtderstäke = GetItemfromName("Sicht der Stärke");
                            if (sichtdeslebens != null) //& //sichtderstäke != null)
                            {
                                WebClient wc = new WebClient();
                                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                                string s = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id="+sichtdeslebens._id+"&z_user_id="+id);
                                s = s.Remove(0, s.IndexOf("Lebenspunkte: </b>") + 18);
                                string gegnerlp = s.Substring(0, s.IndexOf("/"));
                            }


                            string link = "";
                            if (quelltext.Contains("\">Schnellangriff"))
                            {
                                link = quelltext.Substring(0, quelltext.IndexOf("\">Schnellangriff"));
                                string CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                string NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.Length);
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                quelltext = quelltext.Remove(0, quelltext.IndexOf("Angriffsstärke: ") + 16);
                                int staerke = Convert.ToInt32(quelltext.Substring(0, quelltext.IndexOf(".")));
                                _NPC.Add(new NPC(name, "http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpc&checkid=" + CheckID + "&act_npc_id=" + NPCID, staerke));
                            }
                            else
                            {
                                link = quelltext.Substring(0, quelltext.IndexOf("Angreifen</A>"));
                                string CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                string NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.IndexOf("\""));
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                                quelltext = quelltext.Remove(0, quelltext.IndexOf("Angriffsstärke: ") + 16);
                                int staerke = Convert.ToInt32(quelltext.Substring(0, quelltext.IndexOf(".")));
                                WebClient wc = new WebClient();
                                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                                link = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpcmenu&checkid=" + CheckID + "&act_npc_id=" + NPCID);
                                CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                                NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                                NPCID = NPCID.Substring(0, NPCID.IndexOf("&"));
                                CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));


                                _NPC.Add(new NPC(name, "http://" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpc&checkid=" + CheckID + "&act_npc_id=" + NPCID, staerke));
                            }


                        }
                        catch { }
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 0; i < _NPC.Count; i++)
                {
                    WebClient wc = new WebClient();
                    wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    string Text = wc.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php");
                    string Text1 = "";
                    Text = Text.Replace("healthcritical\" title=\"Verräter", string.Empty);
                    if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthok\""))
                    {

                        Text1 = Text.Remove(0, Text.IndexOf("class=\"healthok\"") + 20);
                        Text1 = Text1.Substring(0, Text1.IndexOf("<"));

                    }

                    if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthmed\""))
                    {

                        Text1 = Text.Remove(0, Text.IndexOf("class=\"healthmed\"") + 21);
                        Text1 = Text1.Substring(0, Text1.IndexOf("<"));

                    }

                    if (Text.Contains("Lebenspunkte: </b>(<span class=\"healthcritical\""))
                    {

                        Text1 = Text.Remove(0, Text.IndexOf("class=\"healthcritical\"") + 26);
                        Text1 = Text1.Substring(0, Text1.IndexOf("<"));
                    }
                    if (!wiederID.Contains(_NPC[i].Link))
                    {
                        if (kmpfrechner.BerechneKampf(getStats.Angriffsstärke(), getStats.Verdeitigungsstärke(), Convert.ToInt32(Text1), _NPC[i].Name))
                        {
                            _wB.Document.Window.Frames[1].Navigate(_NPC[i].Link);

                            System.Threading.Thread.Sleep(500);
                        }
                        else
                        {

                            wiederID.Add(_NPC[i].Link);
                            _NPC.RemoveAt(i);

                        }
                    }
                }
            }
            catch { }
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
        public void Drink(int LP)
        {
            try
            {
                if (getStats.IsOnDrink() && getStats.CurrentLP() <= Convert.ToInt32(LP))
                {
                    _wB.Document.Window.Frames[1].Navigate("http://"+ Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=drinkwater");
                    _wB.Document.Window.Frames[6].Navigate("http://"+ Settings._World +".freewar.de/freewar/internal/item.php");
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Heal LP");
                }
            }
            catch { }
        }
        public void DrinkBeer(int LP)
        {
            try
            {
                if (getStats.CurrentLP() <= Convert.ToInt32(LP) && getStats.Geld() < 30)
                {
                    if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("drinkbeer"))
                    {
                        _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=drinkbeer");
                        Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Heal LP with beer");
                    }
                }
            }
            catch { }
        }
        public void Take()
        {
            try
            {
                string quelltext = _wB.Document.Window.Frames[1].Document.Body.InnerHtml;
                for (int i = 0; i < 1; )
                {
                    if (quelltext.Contains("listplaceitemsrow"))
                    {
                        try
                        {
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("listplaceitemsrow"));
                            quelltext = quelltext.Remove(0, 21);
                            string name = quelltext.Substring(0, quelltext.IndexOf("</B>") - 1);
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("item_id=") + 8);
                            string ID = quelltext.Substring(0, quelltext.IndexOf("Nehmen") - 2);
                            if (!name.StartsWith("starker Rückangriff"))
                            {
                                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Take: " + name);
                                if (!name.Contains("Goldmünzen"))
                                {
                                    _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?action=take&act_item_id=" + ID);
                                }
                                else
                                {
                                    _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?action=takemoney&act_item_id=" + ID);
                                }
                            }
                           
                             System.Threading.Thread.Sleep(499);
                        }
                        catch { }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch { }
        }
        public void Harvest()
        {
            try
            {
                string quelltext = _wB.Document.Window.Frames[1].Document.Body.InnerHtml;
               
                for (int i = 0; i < 1; )
                {
                    if (quelltext.Contains("plantrow") && quelltext.Contains("listplaceitemsrow"))
                    {
                        try
                        {
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("plantrow"));
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("listplaceitemsrow"));
                            quelltext = quelltext.Remove(0, 21);
                            string name = quelltext.Substring(0, quelltext.IndexOf("</B>") - 1);
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("item_id=") + 8);
                            string ID = quelltext.Substring(0, quelltext.IndexOf("\""));

                            WebClient wc = new WebClient();
                            wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                            string text = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?action=take&act_item_id=" + ID);
                            if (!text.Contains("eit Pflanzenkunde auf"))
                            {
                                Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Harvest: " + name);
                            }

                            System.Threading.Thread.Sleep(500);
                        }
                        catch { }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch { }
        }      
    }
}
