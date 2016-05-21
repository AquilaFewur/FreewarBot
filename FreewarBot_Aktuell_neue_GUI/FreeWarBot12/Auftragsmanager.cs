using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Web;
using System.Net;


namespace FreeWarBot12
{
    public class Auftragsmanager
    {
        public bool _Auftragfinished = false;
        string auftragstext = "";
        GetSatus _getStats;
        private WebBrowser _wB;
        PathFinder pathFinder = new PathFinder();
        int startxp = 0;
        public List<Auftrag> Aufträge = new List<Auftrag>();

        private void Loadaufträge()
        {
            string line;
            string name = "";
            string finish = "";
            bool peace = false;
            List<object> list = new List<object>();
            List<string> bank = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\Auftrag.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("name:"))
                {
                    name = line.Substring(5);
                }
                if (line.StartsWith("todo:"))
                {
                    line = line.Substring(5);
                    string[] direction = line.Split(';');
                    List<string> list1 = new List<string>(direction.Length);
                    list1.AddRange(direction);
                    list.Add(list1);
                }
                if (line.StartsWith("peace:"))
                {
                    peace = Convert.ToBoolean(line.Substring(6));
                }
                if (line.StartsWith("finish:"))
                {
                    finish = line.Substring(7);
                }

                if (line.StartsWith("end"))
                {
                    Aufträge.Add(new Auftrag(list, name, peace, finish));
                    list = new List<object>();
                    name = String.Empty;
                }

            }
            file.Close();
        }
        public Auftragsmanager(GetSatus getstats, WebBrowser wb)
        {
            _wB = wb;
            _getStats = getstats;
            Loadaufträge();

        }
        public void Auftragsexecuter(Auftrag auftrag)
        {
            WebClient wc1 = new WebClient();
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?showallmsgs=1");

            if (text.Contains(auftrag.Finish))
            {
                Auftragfinished();
            }
            else if (ChatText().Contains(auftrag.Finish))
            {
                Auftragfinished();
            }
            for(int i = 0; i < auftrag.Way.Count; i++)
            {
                if(auftrag.Way[0].StartsWith("goto"))
                {
                    string gotopos = auftrag.Way[0].Substring(0, 5);
                    string[] xy = gotopos.Split('|');
                    Settings.AuftragsPunkt = new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]));     
                }
                else if (auftrag.Way[0].StartsWith("kill"))
                {
                    string s = auftrag.Way[0].Remove(0, 5);
                    string killname = s.Substring(0, s.IndexOf("|"));
                    string pos = s.Remove(0, s.IndexOf("|") + 1);
                    string[] xy;
                    if (pos.Contains("|"))
                    {
                        xy = pos.Split('|');
                    }
                    else
                    {
                        //kommt noch, dynamisch
                        xy = pos.Split('|');
                    }

                    Settings.AuftragsPunkt = new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]));
                    if ((_getStats.px() == Convert.ToInt32(xy[0]) && _getStats.py() == Convert.ToInt32(xy[1])))
                    {

                        //killnpc
                        auftrag.Way.RemoveAt(0);
                    }
                }
                else if (auftrag.Way[0].StartsWith("drop"))
                {
                    string s = auftrag.Way[0].Remove(0, 5);
                    string dropname = s.Substring(0, s.IndexOf("|"));
                    string pos = s.Remove(0, s.IndexOf("|")+1);
                    string[] xy;
                    if (pos.Contains("|"))
                    {
                         xy = pos.Split('|');
                    }
                    else
                    {
                        //kommt noch, dynamisch
                         xy = pos.Split('|');
                    }
                        
                    Settings.AuftragsPunkt = new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]));
                   if ((_getStats.px() == Convert.ToInt32(xy[0]) && _getStats.py() == Convert.ToInt32(xy[1])))
                   {
                     
                     //dropitem
                       auftrag.Way.RemoveAt(0);
                   }
                }
            }
        }
        public void selectAuftrag(string text)
        {
            auftragstext = text;
            Settings.aktuellerAuftragstext = auftragstext;
            Auftragsexecuter(Aufträge[0]);
            for (int i = 0; i < Aufträge.Count; i++)
            {
                if (text.Contains(Aufträge[i].Name))
                {
                    Auftragsexecuter(Aufträge[i]);
                }

            }


            try
            {
                Point p = GetDestinationPosition(auftragstext);
            }
            catch { }
            if (text.Contains("Da wir auch weiterhin starke Mitarbeiter brauchen sind wir an deiner Förderung interessiert. Bei diesem Auftrag geht es deswegen um dich. Versuche mindestens"))
            {
                MehrErfahrung(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Im Nomadendorf in Mentoran ist eine schlimme Hungersnot ausgebrochen. Wir müssen den Leuten dort helfen. Die Leute von der Baru-Mühle in Torihn helfen uns aber dabei. Sie haben extra einen riesigen Sack Mehl für die Nomaden zurückgelegt. Gehe zur Baru-Mühle auf Position X: 110 Y: 93 und hol diesen Mehlsack dort ab. Bringe den Mehlsack dann erstmal zu uns, damit wir Brot daraus machen können."))
            {
                DieHungersnot1(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Wusstest du, dass wir hier im Keller des Auftragshauses einen riesigen Backofen haben? Damit haben wir aus dem Mehlsack nun 15 Brote hergestellt. 14 für uns und eines für die Nomaden. Hier ist es. Bringe dieses Brot den Nomaden im Nomadendorf in Mentoran. Und lass dich nicht durch die Luftspiegelungen verwirren, die es da in der Wüste immer mal wieder gibt. Mentoran ist großteils einfach ein trostloser, staubiger Ort."))
            {
                DieHungersnot2(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Das Casino des Nordens ist in den letzten Jahren immer weiter expandiert und größer geworden, zuletzt durch den Ableger Casino von Ferdolien. Genau dort mehren sich aber in letzter Zeit die Stimmen, welche den Betreibern Betrug vorwerfen. Wir sollen die Sache untersuchen. Dafür musst du dich als verdeckter Ermittler in das Casino von Ferdolien auf Position X: 100 Y: 94 begeben und dort eine Runde spielen. Beobachte das Spiel genau und teile uns danach mit, ob dir etwas Verdächtiges aufgefallen ist."))
            {
                BetrugimCasino(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Auf Position X: 74 Y: 85 wurden in letzter Zeit immer mehr Geisterschaben gesichtet, welche aus dieser Hütte dort strömen. Wir vermuten, dass sie irgendwo in dieser Hütte ihr Nest haben. Wenn sich diese Schaben zu sehr vermehren und über die Welt herfallen, könnte sich das zu einem ernsten Problem entwickeln. Wir müssen vorher eingreifen. Töte 5 von diesen Schaben."))
            {
                DasSchabenproblem(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("In der Schmiede von Buran herrscht derzeit ein Ölmangel. Besorge dir irgendwoher ein Ölfass und verkaufe es der Schmiede auf Position X: 85 Y: 90. Ohne dieses Öl wird die Schmiede ihren Betrieb sonst vorerst einstellen müssen."))
            {
                Ölmangel(); /*FERTIGGGGGGGGGGGGGGGG */ //ÖL MUSS IM INVENTAR SEIN
            }
            else if (text.Contains("Diesmal brauchen wir dich in Pensal. Dort kriechen immer wieder Flammenwürmer aus dem Boden, welche teilweise ein seltenes Flammenwurmsekret ausscheiden, wenn man sie tötet. Man sagt, mit diesem Sekret kann man eine Salbe herstellen, die einen vor Feuer schützt. Wir brauchen dieses Sekret. Pensal erreichst du am besten über die Position X: 54 Y: 113. Begib dich dort hin und töte diese Würmer bis du das Sekret hast. Bringe es uns möglichst bald vorbei."))
            {
                DasFlammenwurmsekret1(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Wir haben das Flammenwurmsekret, welches du uns gebracht hast, auf Hitzeresistenz getestet, aber Fehlanzeige. Das Zeug hält kein Feuer ab. Wie auch immer diese Würmer bei den Bränden von Pensal überleben, es liegt nicht an ihrem Sekret. Aber ganz sinnlos scheint das Zeug nicht zu sein, es lässt sich sehr gut als Gesichtscreme einsetzen. Nach der direkten Anwendung sieht man gleich schon 100 Jahre jünger aus und verhindert besonders bei Onlos hässliche Astbildung im Gesicht. Hier, bringe diese Gesichtscreme nach Urdanien auf Position X: 75 Y: 86. Dort lebt schon seit Ewigkeiten ein Mann mit seiner Onlo-Frau. Die beiden stellen das perfekte Testobjekt für die Gesichtscreme dar. Komme danach zu uns zurück und erstatte Bericht."))
            {
                DasFlammenwurmsekret2(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Im Dorf von Wilisien gibt es eine Frau, welche diese Schneemesser herstellt, die man sehr gut verwenden kann, um Schnee in essbare Häppchen zu zerschneiden. Aber auch zur Selbstverteidigung sind die Dinger nicht schlecht. Wir vom Auftragshaus haben solch ein Messer bestellt, um die Qualität zu testen. Hole es bitte in Wilisien auf Position X: 110 Y: 83 ab und bringe es uns"))
            {
                DasSchneemesser1(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Unser Auftraggeber will diesmal, dass wir jemanden vergiften. Um dies zu bewerkstelligen, müssen wir jedoch zuerst das Gift herstellen. Die beste Zutat dafür ist grüner Giftschleim, welcher sehr selten ist und im dunklen Sumpf von Sutranien manchmal vorkommt. Einer unserer Informanten hat bereits eine Position ausgepäht, auf der du grünen Giftschleim finden kannst. Hole den Giftschleim und bring ihn uns."))
            {
                DasGift1(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Um das Gift richtig effektiv zu machen, reicht der grüne Giftschleim, den du uns gebracht hast, nicht aus. Wir benötigen noch eine weiße Laubnelke, denn zusammen mit dem Schleim entfaltet diese Blume ein starkes Gift. Bring uns solch eine weiße Laubnelke. Normalerweise verkaufen sie die Dinger direkt in Ferdolien im Blumenpavillon."))
            {
                DasGift2(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Wir haben soeben einen Hilferuf von der Tollo-Hütte erhalten. Irgendein Monster frisst da drinnen angeblich Tolloscheine auf, bevor die Hütte sie verkaufen konnte. Wir denken du bist genau die richtige Person für dieses Problem. Den Eingang zur Tollo-Hütte findest du auf Position X: 97 Y: 96. Gehe am besten direkt in die Tollo-Hütte hinein und töte dieses garstige Monster. Aber denk daran, die Sache muss schnell geschehen, wir können deine Belohnung nur auszahlen, wenn du selbst dieses Monster getötet hast."))
            {
                /*FERTIGGGGGGGGGGGGGGGG */
            }

            else if (text.Contains("Wir haben ein seltenes Artefakt in Dranar gefunden. Leider fehlt die Hälfte, daher konnten wir es nicht vollständig entschlüsseln. Die Sache scheint jedoch sehr wichtig zu sein, denn der Teil, den wir entschlüsseln konnten, klingt geradezu gespenstisch. Es hat irgendwas mit der Zeit selbst oder dem Raum und dem Universum, in dem wir leben, zu tun. Weiterhin konnten wir einen Hinweis entziffern, dass das Artefakt ursprünglich in Azul abgelegt wurde. Wir denken, dass sich dort die andere Hälfte befindet. Reise nach Azul und suche die Gegend rund um die Position X: 104 Y 127 ab. Wenn du den Rest des Artefakts gefunden hast, bringe ihn zu uns. Die Belohnung für diesen Auftrag mag dir mickrig erscheinen, aber du sollst von uns das komplette Artefakt als Belohnung erhalten, denn wir sind nicht an dem Artefakt selbst, sondern nur an der Nachricht, die auf dem Artefakt steht, interessiert."))
            {
                DasArtefakt(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Diesen Auftrag haben wir direkt von einem der Tentakelwesen bekommen, konkret von einem Tentakelwesen namens Morg. Dieser Morg hat bei einer Durchreise durch Mentoran seinen goldenen Löffel verloren, den er jedoch unbedingt benötigt, um im Gasthaus zu arbeiten. Du hast von uns diese Wüstenschaufel hier erhalten, wenn es sein muss, grabe damit ganz Mentoran um, bis du diesen Löffel gefunden hast, und komme dann zurück zu uns."))
            {
                DerGoldeneLöffel1(); /*FERTIGGGGGGGGGGGGGGGG */
            }
            else if (text.Contains("Der goldene Löffel, den du in Mentoran gefunden hast, muss jetzt zu seinem Besitzer zurückgebracht werden. Bring den Löffel dem Tentakelwesen Morg im seltsamen Gasthaus auf"))
            {
                DerGoldeneLöffel2();
            }
            else if (text.Contains("In der Herberge am Vulkan kommen zur Stunde zwei wichtige Staatsgäste, ein Onlo und ein Abgesandter der Taruner, zusammen um über Möglichkeiten des Friedens zu reden. Die Gespräche laufen jedoch bisher schlecht. Hauptsächlich kann man dies wohl auf das Essen in der Herberge zurückführen, welches für Staatsmänner nicht würdig ist. Wir müssen hier dringend für Abhilfe sorgen. Für derart hohen Besuch gibt es eigentlich nur eine Speise, die sich anbietet: Gerösteter Schleimhautfisch. Zuerst müssen wir jedoch diesen Fisch fangen. Hier hast du eine Angel des Auftragshauses, gehe damit nach Linya, der einzige Ort an dem dieser Schleimhautfisch vorkommt. Um nach Linya zu kommen, kannst du das Boot nutzen welches von Position X: 118 Y: 106 aus nach Linya fährt. In Linya musst du die Bucht suchen und dort diese Angel auswerfen. Sobald du den Schleimhautfisch hast, bring ihn zurück zu uns."))
            {
                DieFischspeise1();
            }
            else if (text.Contains("Wir haben den Schleimhautfisch jetzt geröstet. Sieh nur wie toll er glänzt und glibbert. Bringe den Fisch jetzt in die Herberge am Vulkan auf Position X: 88 Y: 105. Diese Speise sollte die Friedensgespräche zwischen den Staatsgästen wieder in Schwung bringen."))
            {
                DieFischspeise2();
            }
            else if (text.Contains("Wir benötigen dringend die Handwerkshalle in der Stadt Laree ganz für uns, da wir ein paar Experimente mit dem Bau von völlig neuen Maschinen durchführen wollen. Dabei darf uns absolut niemand unterbrechen. Hier hast du etwas Absperrband, das sollte reichen. Begib dich zur Position X: 53 Y: 77 und bringe dort das Absperrband an, danach können wir in Ruhe unserer Arbeit nachgehen. Komme dann hier her zurück."))
            {
                DieHandwerkshalle();
            }
            else if (text.Contains("Wir müssen diesmal ein schwer verwundetes Wesen dieser Welt heilen. Wir denken, du bist dafür perfekt geeignet. Für diesen Auftrag hast du einen Heilzauber der Geistlosen erhalten. Verwende ihn, "))
            {
                HeilungderSchwachen();
            }
            else if (text.Contains(""))
            {

            }
            else if (text.Contains(""))
            {

            }
            else if (text.Contains(""))
            {

            }
            else if (text.Contains(""))
            {

            }
        }


        /*  
        
      private void ()
      {
        

        

          if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml == "")
          {
              Auftragfinished();
          }


          else if ((Paths._Actual == null || Paths._Actual.Count == 0))
          {
              Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(0,0)));
          }


                
          else if ((_getStats.px() == 100 & _getStats.py() == 100))
          {
               
          }
      }
      */

        // _wB.Document.Window.Frames[1].Navigate("http://" + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=einzahlen");     <<<Link klicken, zum Beispiel Geld einzahlen, angreifen, item nehmen

        private string ChatText()
        {
            WebClient wc1 = new WebClient();
            wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/chattext.php");
            return text;

        }

        public Point GetDestinationPosition(string text)
        {
            text = text.Remove(0, text.IndexOf("Position X:") + 12);
            string x = text.Substring(0, text.IndexOf("Y") - 1);
            text = text.Remove(0, text.IndexOf("Y") + 3);
            string y = text.Substring(0, text.IndexOf(" "));
            if (y.Contains("."))
            {
                y = y.Replace(".", "");
            }
            return new Point(Convert.ToInt32(x), Convert.ToInt32(y));


        }

        public void UseItemOnNPC(string npcname, string itemname)
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

                            if (name.ToLower() == npcname.ToLower())
                            {
                                WebClient wc1 = new WebClient();
                                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName(itemname)._id + "&act_npc_id=" + NPCID);
                            }


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
                            if (name.ToLower() == npcname.ToLower())
                            {
                                WebClient wc1 = new WebClient();
                                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName(itemname)._id + "&act_npc_id=" + NPCID);
                            }

                        }

                    }
                    catch
                    {

                    }
                }

            }

        }

        private void DieHungersnot1()
        {
            Settings._aktuellerAuftrag = "Die Hungersnot 1";
            WebClient wc1 = new WebClient();
            wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?showallmsgs=1");

            if (text.Contains("Als du an der Mühle ankommst, steht der Mehlsack schon für dich bereit. Die Mühle in Torihn ist dafür bekannt, öfter auch mal großzügig zu sein, wenn es um die Ärmsten dieser Welt geht."))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(110, 93)));
            }

        }

        private void DieHungersnot2()
        {
            WebClient wc1 = new WebClient();
            wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?showallmsgs=1");
            if (text.Contains("Als du im Nomadendorf ankommst, gibst du den Nomaden das Brot. Sie freuen sich und sehen in der Tat sehr hungrig aus. Als du das Brot jedoch einem der Nomaden gibst, verschwindet dieser in einem Zelt. Einige Zeit später kommt der Nomade wieder heraus und legt das Brot zu seinem Shop, um es weiterzuverkaufen. Langsam wird dir klar, woher das ganze Nomadenbrot eigentlich stammt. Du solltest jetzt besser zum Auftragshaus zurückkehren."))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(101, 116)));
            }

        }

        private void MehrErfahrung()
        {
            string s = auftragstext.Remove(0, auftragstext.IndexOf("Versuche mindestens ") + 23);
            s = s.Substring(0, s.IndexOf("</b>") - 1);
            int xp = Convert.ToInt32(s);

            if ((Player.XP >= xp))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.RandomWay(new Point(_getStats.px(), _getStats.py())));
            }

        }

        private void BetrugimCasino()
        {
            //Chattextbedingung
            if (ChatText().Contains("Du beobachtest das Spiel ganz genau, aber du kannst nichts erkennen, das auf Betrug hindeutet. Kehre zurück zum Auftragshaus, um die Mission abzuschliessen."))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(100, 94)));
            }

            else if ((_getStats.px() == 100 & _getStats.py() == 94))
            {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=casino2");
            }
        }

        private void DasSchabenproblem()
        {
            //Chattextbedingung
            if (ChatText().Contains("<b>5</b> Geisterschaben getötet"))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(74, 85)));
            }

        }

        private void Ölmangel()
        {
            //Chattextbedingung

            if (ChatText().Contains("Die Schmiede hat nun wieder genug Öl. Kehre zurück zum Auftragshaus um die Mission abzuschliessen."))
            {
                Auftragfinished();
            }

                //Bevor er zum Feld geht muss ein Ölfass im Inventar sein ( entweder Maha kaufen oder schon im Inventar haben )
            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(85, 90)));
            }

            else if ((_getStats.px() == 85 & _getStats.py() == 90))
            {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=brauen");
            }
        }

        private void DasFlammenwurmsekret1()
        {
            //Chattextbedingung
            //Auftrag nimmt das Item 'Flammenwurmsekret'
            if (ChatText().Contains("nimmt das Item '<b>Flammenwurmsekret</b>'"))
            {
                Auftragfinished();
            }


                //In Pensal jagen bis zum Sekret
            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                if ((_getStats.px() != 54 && _getStats.py() != 113))
                {
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(54, 113)));
                }
                else if ((_getStats.px() != 49 && _getStats.py() != 109))
                {
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(49, 109)));
                }
                else if ((_getStats.px() != 54 && _getStats.py() != 108))
                {
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(54, 108)));
                }


                // Pensal
            }
        }

        private void DasFlammenwurmsekret2()
        {
            /*Bei der Hütte angekommen gibst du dem Mann und seiner Onlo-Frau die Gesichtscreme. Die beiden schauen entzückt und essen die Creme. 
             Dann sprechen sie zu dir, fast wie aus einem Munde: "Besonders lecker ist diese Sauce ja nicht, aber wir sind froh über alles was hier hier so kriegen können.". Zeit für dich zurück zum Auftragshaus zu gehen.*/

            WebClient wc1 = new WebClient();
            wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?showallmsgs=1");
            if (text.Contains("Bei der Hütte angekommen gibst du dem Mann und seiner Onlo-Frau die Gesichtscreme. Die beiden schauen entzückt und essen die Creme. Dann sprechen sie zu dir"))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(75, 86)));
            }
        }

        private void DieHandwerkshalle()
        {


            //12 min Zeit

            WebClient wc1 = new WebClient();
            wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?showallmsgs=1");
            if (text.Contains("Die Handwerkshalle wurde mit gelbem Absperrband gegen das Betreten von Unbefugten gesichert. Auf dem Absperrband steht geschrieben:"))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(53, 77)));
            }



            else if ((_getStats.px() == 53 & _getStats.py() == 77))
            {
                WebClient wc2 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text2 = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("Absperrband")._id);
            }
        }


        private void DiemysteriösenPflanzensamen1()
        {
            if (ChatText().Contains("nimmt das Item '<b>kleiner Beutel mit Pflanzensamen</b>'"))
            {
                List<string> pfad = new List<string>();
                pfad.Add("downleft");
                pfad.Add("down");
                pfad.Add("down");
                pfad.Add("up");
                pfad.Add("left");
                pfad.Add("left");
                pfad.Add("up");
                pfad.Add("right");
                pfad.Add("right");
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?do=treppe");
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {

                if ((_getStats.px() == -19998 && _getStats.py() == -19996))
                {
                    List<string> pfad = new List<string>();
                    pfad.Add("leftup");
                    pfad.Add("right");
                    pfad.Add("right");
                    pfad.Add("up");
                    pfad.Add("left");
                    pfad.Add("left");
                    pfad.Add("up");
                    pfad.Add("right");
                    pfad.Add("right");
                    Paths._Actual.AddRange(pfad);

                }
                else if ((_getStats.px() != 111 && _getStats.py() != 96))
                {
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(111, 96)));

                }
                else if ((_getStats.px() == 111 && _getStats.py() == 96))
                {
                    WebClient wc1 = new WebClient();
                    wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?do=treppe");
                }
            }
        }

        private void DiemysteriösenPflanzensamen2()
        {
            Point p = GetDestinationPosition(auftragstext);

            if ((_getStats.px() == p.X & _getStats.py() == p.Y))
            {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("kleiner Beutel mit Pflanzensamen")._id);
                Auftragfinished();
            }
            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(p.X, p.Y)));
            }
        }

        private void DasSchneemesser1()
        {
            WebClient wc1 = new WebClient();
            wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?showallmsgs=1");
            if (text.Contains("Du läufst durch die vereisten Gassen von Wilisien und findest den Laden der Frau recht schnell. Sie hat bereits eines dieser Schneemesser für dich beiseite gelegt und gibt es dir."))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(110, 83)));
            }

        }


        //Schneemesser (M) (A: 2 | Als Waffe) anlegen und 5 NPC's töten

        private void DasSchneemesser2()
        {

            /* if (ChatText().Contains("nimmt das Item '<b>grüner Giftschleim</b>'"))
            {
                Auftragfinished();
            }*/

            //Chattext
            if (ChatText().Contains("Du hast <b>5</b> von 5 NPCs getötet. Kehre zurück zum Auftragshaus, um die Mission abzuschließen."))
            {
                Auftragfinished();
            }


            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("Schneemesser")._id);
                Paths._Actual.AddRange(pathFinder.RandomWay(new Point(_getStats.px(), _getStats.py())));
            }

        }

        private void DasGift1()
        {
            // grüner Giftschleim - Nehmen

            if (_wB.Document.Window.Frames[8].Document.Body.OuterHtml == "nimmt das Item 'grüner Giftschleim'")
            {
                Auftragfinished();
            }
            //down;down;down;right;up;up;up;right;down;down;down;right;up;up;up;up;right;down;down;down;down;

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {

                if ((_getStats.px() == 73 && _getStats.py() == 92))
                {
                    List<string> pfad = new List<string>();
                    pfad.Add("down");
                    pfad.Add("down");
                    pfad.Add("down");
                    pfad.Add("right");
                    pfad.Add("up");
                    pfad.Add("up");
                    pfad.Add("up");
                    pfad.Add("right");
                    pfad.Add("down");
                    pfad.Add("down");
                    pfad.Add("down");
                    pfad.Add("right");
                    pfad.Add("up");
                    pfad.Add("up");
                    pfad.Add("up");
                    pfad.Add("up");
                    pfad.Add("right");
                    pfad.Add("down");
                    pfad.Add("down");
                    pfad.Add("down");
                    pfad.Add("down");

                    Paths._Actual.AddRange(pfad);
                }
                else if ((_getStats.px() != 73 && _getStats.py() != 92))
                {
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(73, 92)));
                }

            }
        }

        private void DasGift2()
        {
            if (ChatText().Contains("kauft <b>weiße Laubnelke</b>"))
            {
                Auftragfinished();
            }


            else if ((_getStats.px() == 106 & _getStats.py() == 95))
            {

                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=shop&shopitem=311");


            }
            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(106, 95)));
            }





        }

        private void ProblembeimTollo()
        {
            if (ChatText().Contains("<b>Tolloschein-Fresser</b> ist tot, du hast deinen Auftrag erfüllt. Kehre zurück zum Auftragshaus um die Mission abzuschliessen."))
            {
                WebClient wc3 = new WebClient();
                wc3.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text2 = wc3.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=rausgehen");
                Auftragfinished();
            }

            else if ((_getStats.px() == 97 & _getStats.py() == 96))
            {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=betreten21021");

            }
            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(97, 96)));
            }
        }



        private void DerBriefbeschwerer()
        {

            if (ChatText().Contains("nimmt das Item '<b>Briefbeschwerer</b>'"))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.RandomWay(new Point(_getStats.px(), _getStats.py())));
            }

        }


        private void Urlaub1()
        {
            WebClient wc1 = new WebClient();
            wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
            string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?showallmsgs=1");
            if (text.Contains("Du sagst dem Fischer direkt, er solle alles stehen"))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(118, 106)));

            }

        }

        private void DasArtefakt()
        {
            if (ChatText().Contains("nimmt das Item '<b>zerbrochenes Artefakt</b>'"))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                if ((_getStats.px() == 104 && _getStats.py() == 127))
                {
                    List<string> pfad = new List<string>();
                    pfad.Add("right");
                    pfad.Add("right");
                    pfad.Add("right");
                    pfad.Add("downleft");
                    pfad.Add("left");
                    pfad.Add("left");
                    pfad.Add("left");
                    pfad.Add("leftup");
                    pfad.Add("right");
                    pfad.Add("up");
                    pfad.Add("right");
                    pfad.Add("right");
                    pfad.Add("right");
                    pfad.Add("up");
                    pfad.Add("left");
                    pfad.Add("left");
                    pfad.Add("left");
                    pfad.Add("upright");
                    pfad.Add("right");
                    pfad.Add("right");

                    Paths._Actual.AddRange(pfad);
                }
                else if ((_getStats.px() != 104 && _getStats.py() != 127))
                {
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(104, 127)));
                }

            }
        }

        private void DerGoldeneLöffel1()
        {

            if (ChatText().Contains("gräbt mit einer Wüstenschaufel im Sand und findet einen goldenen Löffel"))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {

                if ((_getStats.px() != 97 && _getStats.py() != 114))
                {
                    WebClient wc1 = new WebClient();
                    wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(97, 114)));
                    string text2 = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("Wüstenschaufel")._id);


                }

                if ((_getStats.px() != 97 && _getStats.py() != 115))
                {
                    WebClient wc1 = new WebClient();
                    wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                    Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(97, 115)));
                    string text2 = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("Wüstenschaufel")._id);
                }



            }

        }

        private void DerGoldeneLöffel2()
        {

            if (ChatText().Contains("wirft den Tentakelwesen einen goldenen Löffel zu."))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(86, 109)));

            }

        }

        private void DieFischspeise1()
        {

            if (ChatText().Contains("wirft eine Angel aus und fängt einen Schleimhautfisch"))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(132, 117)));
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=oben2192");
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(118, 106)));
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/main.php?arrive_eval=oben1849");
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(136, 117)));

            }

            if ((_getStats.px() == 136 && _getStats.py() == 117))
            {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text2 = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("Angel des Auftragshauses")._id);
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(137, 116)));
            }

            if ((_getStats.px() == 137 && _getStats.py() == 116))
            {
                WebClient wc1 = new WebClient();
                wc1.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string text2 = wc1.DownloadString("http://www." + Settings._World + ".freewar.de/freewar/internal/item.php?action=activate&act_item_id=" + GetItemfromName("Angel des Auftragshauses")._id);
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(136, 117)));


            }
        }

        private void DieFischspeise2()
        {

            if (ChatText().Contains("übergibt feierlich einen gerösteten Schleimhautfisch an die Herberge."))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), new Point(88, 105)));

            }

        }

        private void HeilungderSchwachen()
        {
            Settings._attack = false;
            Point p = GetDestinationPosition(auftragstext);
            if (ChatText().Contains("Du hast das Wesen deines Auftrages vollständig geheilt, kehre nun zum Haus der Aufträge zurück."))
            {
                Auftragfinished();
            }

            else if ((Paths._Actual == null || Paths._Actual.Count == 0))
            {
                Paths._Actual.AddRange(pathFinder.Directions(new Point(_getStats.px(), _getStats.py()), GetDestinationPosition(auftragstext)));


            }
            else if ((_getStats.px() == p.X && _getStats.py() == p.Y))
            {
                string npc = auftragstext.Remove(0, auftragstext.IndexOf("um das Wesen <b>") + 16);
                npc = npc.Substring(0, npc.IndexOf("</b"));
                UseItemOnNPC(npc, "heilzauber der geistlosen");
            }

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

        private void Auftragfinished()
        {
            _Auftragfinished = true;
        }
    }
}
