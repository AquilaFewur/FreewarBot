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
   
    class AbilityTrainer
    {
        Timer t1 = new Timer();
        WebBrowser _wB;
        public AbilityTrainer(WebBrowser wb)
        {
            _wB = wb;
            t1.Interval = 1000;
            t1.Tick += new EventHandler(t1_Tick);
            t1.Start();
            if (Settings.trainAbility)
            {
                TrainAbility();
            }
        }         
        private void t1_Tick(object sender, EventArgs e)
        {
            if (Settings.trainAbility)
            {
                TrainAbility();
            }
        }
        public void TrainAbility()
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Cookie, Settings.Cookie);
                string quelltext = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/ability.php");
                if (!quelltext.Contains("Du trainierst gerade"))
                {
                    string quelxltext = wc.DownloadString("http://" + Settings._World + ".freewar.de/freewar/internal/ability.php?action=train&ability_id=" + Settings._ability);
                }
            }
            catch
            { }
        }
    }
}
