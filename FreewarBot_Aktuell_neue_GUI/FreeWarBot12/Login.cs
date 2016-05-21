using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreeWarBot12
{
    class Login
    {
        public static void StartLogin(string User, string Password, WebBrowser wB)
        {        
            foreach (HtmlElement elem in wB.Document.All)
            {

                if (elem.Name == "name")              // Name des HTMLinputs
                {
                    elem.InnerText = Settings._Username;               // euer Benutzername 
                }

                if (elem.Name == "password")               // Name des HTMLinputs
                {
                    elem.InnerText = Settings._Password;                // euer Passwort yepuvobu
                }
            }
            foreach (HtmlElement elem in wB.Document.All)
            {

                if (elem.GetAttribute("value") == "Einloggen")
                {
                    elem.InvokeMember("Click");
                }
            }
        }
    }
}
