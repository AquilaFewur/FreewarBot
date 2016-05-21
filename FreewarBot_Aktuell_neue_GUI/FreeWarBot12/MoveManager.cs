using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;

namespace FreeWarBot12
{
    public class MoveManager
    {
        static int PX;
        static int PY;
        GetSatus _getStats;
        int Zähler = 0;
        bool positionÜberprüfen = false;
        WebBrowser _wB;
        public MoveManager(WebBrowser wb, GetSatus getstats)
        {
            _getStats = getstats;
            _wB = wb;
        }
        public void Move()
        {
            try
            {
                if (positionÜberprüfen)
                {
                    if (PX != _getStats.px())
                    {
                        Paths._Actual.RemoveAt(0);
                        positionÜberprüfen = false;
                        Zähler = 0;
                    }
                    else if (PY != _getStats.py())
                    {
                        Paths._Actual.RemoveAt(0);
                        positionÜberprüfen = false;
                        Zähler = 0;
                    }
                    else
                    {
                        Zähler++;
                    }

                }
                if (Zähler > 5)
                {
                    Zähler = 0;
                    Paths._Actual = new List<string>();
                     positionÜberprüfen = true;
                }
                if (_getStats.go())
                {
                    try
                    {
                        if (Paths._Actual.Count != 0)
                        {
                            PX = _getStats.px();
                            PY = _getStats.py();
                            System.Threading.Thread.Sleep(100);
                            if (Paths._Actual[0].Substring(0, 2) == "gz")
                            {
                                UseGZK(Zauberkugel.Destination(Paths._Actual[0].Remove(0, 4)));
                            }
                            else if (Paths._Actual[0].Substring(0, 2) == "be")
                            {
                                HöhleBetreten();
                            }
                            else if (Paths._Actual[0] == "dem pfad in die berge folgen")
                            {
                                PfaddurchdieBergenehmen();
                            }
                            else
                            {
                                MoveTo(Paths._Actual[0]);
                            }
                            positionÜberprüfen = true;
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
        public void MoveTo(string direction)
        {
            //while (_wB.ReadyState != WebBrowserReadyState.Complete)
            //{
            //    System.Threading.Thread.Sleep(100);
            //}
            if (Paths._Actual[0] != null)
            {
                //wB.Document.Window.Frames[7].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/map.php?");
               // System.Threading.Thread.Sleep(1000);
             
               //  _wB.Document.Window.Frames[7].Navigate
                _wB.Document.Window.Frames[7].Document.InvokeScript(Settings._DerString, new object[] { direction });
            }
        }
        
        public void HöhleBetreten()
        {
            string s = _wB.Document.Window.Frames[1].Document.Body.InnerHtml;
            s = s.Remove(0, s.IndexOf("arrive_eval=oben") + 16);
            s = s.Substring(0, s.IndexOf(">") - 1);
            _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=oben" + s);
        }
        public void PfaddurchdieBergenehmen()
        {
            while (true)
            {
                _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?gehedurchdieberge=1");
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc.DownloadString("http://"+ Settings._World + ".freewar.de/freewar/internal/main.php");
                if (text.Contains("Du stehst vor einem seltsam zugeschliffenen Stein. Der Stein wirkt böse und dunkel. Ein mächtiger Serum-Geist steht dort und bietet hier anderen Serum-Geistern m"))
                {
                    break;
                }
               // System.Threading.Thread.Sleep(50);
            }
            _wB.Document.Window.Frames[8].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/menu.php?reload=true");
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
        public bool UseGZK(string place)
        {
            string id = "";
            if (IteminInventar("gepresste Zauberkugel"))
            {
                for (int i = 0; i < Settings._Items.Count; i++)
                {
                    if (Settings._Items[i]._name == "gepresste zauberkugel")
                    {
                        id = Settings._Items[i]._id;
                        break;
                    }
                }
                _wB.Document.Window.Frames[6].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + id);
                bool b = false;
                while (!b)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                    foreach (HtmlElement elem in _wB.Document.Window.Frames[6].Document.All)
                    {
                        if (elem.Name == "z_pos_id")              // Name des HTMLinputs
                        {
                            elem.OuterHtml = place;           // euer Benutzername 
                            b = true;
                            break;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1500);
                foreach (HtmlElement elem in _wB.Document.Window.Frames[6].Document.All)
                {

                    if (elem.GetAttribute("value") == "Noppen drücken")
                    {
                        elem.InvokeMember("Click");

                    }
                }
                return true;
            }
            return false;
        }
    }
}
