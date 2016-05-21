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

namespace Freewar
{
    class ClickCaptcha
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
                if (Cracked == true & webBrowser1.Document.Window.Frames[1].Document.Body.InnerHtml.Contains("randsec="))
                {
                    int xWeb = 12 + 17;
                    int yWeb = 12 + 132;
                    IntPtr handle = webBrowser1.Handle;
                    StringBuilder className = new StringBuilder(100);
                    while (className.ToString() != "Internet Explorer_Server")
                    {
                        handle = GetWindow(handle, 5);
                        GetClassName(handle, className, className.Capacity);
                    }
                    IntPtr lParam = (IntPtr)((Points[5].Y + yWeb << 16) | xWeb + Points[5].X);
                    IntPtr wParam = IntPtr.Zero;
                    const uint downCode = 0x201;
                    const uint upCode = 0x202;
                    SendMessage(handle, downCode, wParam, lParam);
                    SendMessage(handle, upCode, wParam, lParam);
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
