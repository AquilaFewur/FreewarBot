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
using FreeWarBot12;

namespace Freewar
{
    class ClickCaptcha2
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        public bool CLickCaptcha(bool Cracked, WebBrowser webBrowser1, List<Point> Points)
        {
            try
            {
                if (Cracked == true & webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("randsec=") & FreeWarBot12.Settings.IsBotRunning)
                {
                    if (!webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("do=wood") && !webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("do=mine"))
                    {
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?" + Points[5].X.ToString() + "," + Points[5].Y.ToString());
                    }

                    else if(webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("do=wood"))
                    {
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?&do=wood&cpt=" + Points[5].X.ToString() + "," + Points[5].Y.ToString());
                    }
                    else
                    {
                        string s = webBrowser1.Document.Window.Frames[1].Url.ToString();
                        s = s.Remove(0, s.IndexOf("posx"));
                        webBrowser1.Document.Window.Frames[1].Navigate("http://" + Settings2._World + ".freewar.de/freewar/internal/main.php?blankmain=1&do=mine&" + s + "&cpt=" + Points[5].X.ToString() + "," + Points[5].Y.ToString());
                       
                    }

                
                    Settings.Action.Add(DateTime.Now.ToShortTimeString() + " " + "Click Captcha at: " + Points[5].X.ToString() + ", " + Points[5].Y.ToString());
                    Settings.CaptchaCounter = Settings.CaptchaCounter + 1;
                    Cracked = false;
                    Points = null;
                    return true;

                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
