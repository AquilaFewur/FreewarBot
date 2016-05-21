using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreeWarBot12
{
    class GetSatus
    {
        WebBrowser _wB;
        public GetSatus(WebBrowser wb)
        {
            _wB = wb;
        }
        public  bool IsOnDrink()
        {
            if (_wB.Document.Window.Frames[1].Document.Body.OuterHtml.Contains("main.php?arrive_eval=drinkwater"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  int Geld()
        {
            string Text = _wB.Document.Window.Frames[6].Document.Body.OuterHtml;
            Text = Text.Remove(0, Text.LastIndexOf("Geld: </B>"));
            Text = Text.Substring(10, Text.IndexOf("<IMG") - 11);
            Text = Text.Replace(".", "");
            Player.Money = Convert.ToInt32(Text);
            return Convert.ToInt32(Text);
        }
        public  int Erfahrung()
        {
            string Text = _wB.Document.Window.Frames[6].Document.Body.OuterHtml;
            Text = Text.Remove(0, Text.IndexOf("Erfahrung: ") + 11);
            if (Text.Contains("von 100"))
            {
                Text = Text.Substring(0, Text.IndexOf("von 100") - 1);
            }
            else
            {
                Text = Text.Substring(0, Text.IndexOf(")"));
            }
            Player.XP = Convert.ToInt32(Text);
            return Convert.ToInt32(Text);
        }
        public  int MaxLP()
        {
            string Text = _wB.Document.Window.Frames[6].Document.Body.OuterHtml;
            Text = Text.Remove(0, Text.IndexOf("</B></SPAN>/") + 12);
            Text = Text.Substring(0, Text.IndexOf(")"));
            Player.MaxLp = Convert.ToInt32(Text);
            return Convert.ToInt32(Text);
        }
        public  int Angriffsstärke()
        {
            string Text = _wB.Document.Window.Frames[6].Document.Body.OuterHtml;
            Text = Text.Remove(0, Text.IndexOf("Angriffsstärke") + 20);
            int StärkeoWaffe = Convert.ToInt32(Text.Substring(0, Text.IndexOf("<")));
            int Waffenstärke = 0;
            if(Text.Contains("durch Waffe"))
            {
                Text = Text.Remove(0, Text.IndexOf("valueincreased") + 16);
                Waffenstärke = Convert.ToInt32(Text.Substring(0,Text.IndexOf("</SPAN")));
            }
            Player.Angriffsstärke = StärkeoWaffe + Waffenstärke;
            return StärkeoWaffe + Waffenstärke;
        }
        public  int Verdeitigungsstärke()
        {
            string Text = _wB.Document.Window.Frames[6].Document.Body.OuterHtml;
            Text = Text.Remove(0, Text.IndexOf("Verteidigungsstärke") + 25);
            int VeroWaffe = Convert.ToInt32(Text.Substring(0, Text.IndexOf("<")));
            int Waffenver = 0;
            if (Text.Contains("valueincreased"))
            {
                Text = Text.Remove(0, Text.IndexOf("valueincreased") + 16);
                Waffenver = Convert.ToInt32(Text.Substring(0, Text.IndexOf("</SPAN")));
            }
            Player.Verdeitigungsstärke = Waffenver + VeroWaffe;
            return Waffenver + VeroWaffe;
        }
        public  int px()
        {
            string Text = _wB.Document.Window.Frames[7].Document.Body.OuterText;
            Text = Text.Remove(0, Text.IndexOf("X") + 3);
            Text = Text.Substring(0, Text.IndexOf("Y")-1);
            return Convert.ToInt32(Text);
        }
        public  int py()
        {
            string Text = _wB.Document.Window.Frames[7].Document.Body.OuterText;
            Text = Text.Remove(0, Text.IndexOf("Y:") + 3);
            if (Text.Length < 5)
            {
                Text = Text.Substring(0, Text.Length);
            }
            else
            {
                Text = Text.Substring(0, 5);
            }
            return Convert.ToInt32(Text);
        }
        public  bool SpeedOk()
        {
            string Text = _wB.Document.Window.Frames[6].Document.Body.OuterHtml;
            if (Text.Contains("speedbad"))
            {
                Player._speedok = false;
                return false;         
            }
            else
            {
                Player._speedok = true;
                return true;
            }
            
        }
        public  bool go()
        {           
            try
            {
                string Text = _wB.Document.Window.Frames[7].Document.Body.OuterText;
                Text = Text.Remove(0, Text.IndexOf("Du kannst in") + 3);
                Text = Text.Substring(0, Text.IndexOf("S") - 1);
                if (Text.Contains("1"))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        public  int CurrentLP()
        {
            string Text = _wB.Document.Window.Frames[6].Document.Body.OuterHtml;
            if (Text.Contains("class=healthok><B>"))
            {

                string Text1 = Text.Remove(0, Text.IndexOf("class=healthok") + 18);
                Text1 = Text1.Substring(0, Text.IndexOf("B")-1);
                Player.CurrentLP = Convert.ToInt32(Text1);
                return Convert.ToInt32(Text1);
                
            }
            if (Text.Contains("class=healthmed><B>"))
            {

                string Text1 = Text.Remove(0, Text.IndexOf("class=healthmed") + 19);
                Text1 = Text1.Substring(0, Text.IndexOf("<")-1);
                if (Text1 == "1")
                {
                    Text1 = "10";
                }
                Player.CurrentLP = Convert.ToInt32(Text1);
                return Convert.ToInt32(Text1);

            }
            if (Text.Contains("class=healthcritical><B>"))
            {

                string Text1 = Text.Remove(0, Text.IndexOf("class=healthcritical") + 24);
                Text1 = Text1.Substring(0, Text.IndexOf("B") - 2);
                Player.CurrentLP = Convert.ToInt32(Text1);
                return Convert.ToInt32(Text1);

            }
            return 0;
        }
    }
}
