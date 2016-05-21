using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Freewar
{
    class GetSatus2
    {
        public static bool IsOnDrink(string Text)
        {
            if (Text.Contains("main.php?arrive_eval=drinkwater"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int Geld(string Text)
        {
            Text = Text.Remove(0, Text.LastIndexOf("Geld: </B>"));
            Text = Text.Substring(10, Text.IndexOf("<IMG") - 11);
            Text = Text.Replace(".", "");
            return (Convert.ToInt32(Text));
        }
        public static int Erfahrung(string Text)
        {
            Text = Text.Remove(0, Text.IndexOf("Erfahrung: ") + 11);
            Text = Text.Substring(0, Text.IndexOf(")"));
            return Convert.ToInt32(Text);
        }
        public static int MaxLP(string Text)
        {       
            Text = Text.Remove(0, Text.IndexOf("</B></SPAN>/") + 12);
            Text = Text.Substring(0, Text.IndexOf(")"));
            return Convert.ToInt32(Text);
        }
        public static int px(string Text)
        {
            Text = Text.Remove(0, Text.IndexOf("X") + 3);
            Text = Text.Substring(0, Text.IndexOf("Y")-1);
            return Convert.ToInt32(Text);
        }
        public static int py(string Text)
        {
            Text = Text.Remove(0, Text.IndexOf("Y") + 3);
            if (Text.Length < 5)
            {
                Text = Text.Substring(0, Text.Length);
            }
            else
            {
                Text = Text.Substring(0, Text.IndexOf("D")-1);
            }
            return Convert.ToInt32(Text);
        }
        public static bool SpeedOk(string Text)
        {
           
            if (Text.Contains("speedbad"))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public static bool go(string Text)
        {
            
            try
            {
                Text = Text.Remove(0, Text.IndexOf("in") + 3);
                Text = Text.Substring(0, Text.IndexOf("S") - 1);
                return false;
            }
            catch
            {
                return true;
            }
        }
        public static int CurrentLP(string Text)
        {
            if (Text.Contains("class=healthok><B>"))
            {

                string Text1 = Text.Remove(0, Text.IndexOf("class=healthok") + 18);
                Text1 = Text1.Substring(0, Text.IndexOf("B")-1);
                return Convert.ToInt32(Text1);
                
            }
            if (Text.Contains("class=healthmed><B>"))
            {

                string Text1 = Text.Remove(0, Text.IndexOf("class=healthmed") + 19);
                Text1 = Text1.Substring(0, Text.IndexOf("<")-1);
                return Convert.ToInt32(Text1);

            }
            if (Text.Contains("class=healthcritical><B>"))
            {

                string Text1 = Text.Remove(0, Text.IndexOf("class=healthcritical") + 24);
                Text1 = Text1.Substring(0, Text.IndexOf("B") - 2);
                return Convert.ToInt32(Text1);

            }
            return 0;

        }
    }
}
