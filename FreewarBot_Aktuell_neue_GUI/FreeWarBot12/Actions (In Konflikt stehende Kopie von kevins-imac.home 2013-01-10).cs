using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;

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
                            if (quelltext.Contains("vAlign=top><B>"))
                            {
                                name = quelltext.Remove(0, quelltext.IndexOf("vAlign=top><B>") + 14);
                                name = name.Substring(0, name.IndexOf("</B>")-1);
                            }
                            else
                            {
                                name = quelltext.Substring(0, quelltext.IndexOf("</B>") - 1);
                            }
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("class=fastattack href=") + 23);
                            string link = quelltext.Substring(0, quelltext.IndexOf("\">Schnellangriff"));
                            string CheckID = link.Remove(0, link.IndexOf("checkid=") + 8);
                            string NPCID = link.Remove(0, link.IndexOf("npc_id=") + 7);
                            NPCID = NPCID.Substring(0, NPCID.Length);
                            CheckID = CheckID.Substring(0, CheckID.IndexOf("&"));
                            quelltext = quelltext.Remove(0, quelltext.IndexOf("Angriffsstärke: ") + 16);
                            int staerke = Convert.ToInt32(quelltext.Substring(0, quelltext.IndexOf(".")));
                            _NPC.Add(new NPC(name, "http://welt" + Settings._World + ".freewar.de/freewar/internal/fight.php?action=attacknpc&checkid=" + CheckID + "&act_npc_id=" + NPCID, staerke));
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
                     wc.Headers.Add(HttpRequestHeader.Cookie, _wB.Document.Cookie);
                     string Text = wc.DownloadString("http://www.welt1.freewar.de/freewar/internal/item.php");
                     string Text1 = "";
                     Text = Text.Replace("healthcritical\" title=\"Verräter", string.Empty);
                     if (Text.Contains("class=\"healthok\""))
                     {

                        Text1 = Text.Remove(0, Text.IndexOf("class=\"healthok\"") + 20);
                        Text1 = Text1.Substring(0, Text1.IndexOf("<"));

                     }
                    
                    if (Text.Contains("class=\"healthmed\""))
                    {

                        Text1 = Text.Remove(0, Text.IndexOf("class=\"healthmed\"") + 21);
                        Text1 = Text1.Substring(0, Text1.IndexOf("<"));
                        if (Text1 == "1")
                        {
                           Text1 = "10";
                        }

                    }
                
                    if (Text.Contains("class=\"healthcritical\"" ))
                    {

                         Text1 = Text.Remove(0, Text.IndexOf("class=\"healthcritical\"") + 26);
                         Text1 = Text1.Substring(0, Text1.IndexOf("<"));
                    }
                    if (!wiederID.Contains(_NPC[i].Link))
                    {
                        if (kmpfrechner.BerechneKampf(getStats.Angriffsstärke(), getStats.Verdeitigungsstärke(), Convert.ToInt32(Text1),_NPC[i].Name))
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
        public void Drink(int LP)
        {
            try
            {
                if (getStats.IsOnDrink() & getStats.CurrentLP() <= Convert.ToInt32(LP))
                {
                    _wB.Document.Window.Frames[1].Navigate("http://welt"+ Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=drinkwater");
                    _wB.Document.Window.Frames[6].Navigate("http://welt"+ Settings._World +".freewar.de/freewar/internal/item.php");
                }
            }
            catch { }
        }
        public void DrinkBeer(int LP)
        {
            try
            {
                if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("drinkbeer") & getStats.CurrentLP() <= Convert.ToInt32(LP) & getStats.Geld() < 30)
                {
                    _wB.Document.Window.Frames[1].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=drinkbeer");
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
                                if (!name.Contains("Goldmünzen"))
                                {
                                    _wB.Document.Window.Frames[1].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/main.php?action=take&act_item_id=" + ID);
                                }
                                else
                                {
                                    _wB.Document.Window.Frames[1].Navigate("http://welt" + Settings._World + ".freewar.de/freewar/internal/main.php?action=takemoney&act_item_id=" + ID);
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
    }
}
