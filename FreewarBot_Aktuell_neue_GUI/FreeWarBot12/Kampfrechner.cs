using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Net;
namespace FreeWarBot12
{
    class Kampfrechner
    {
        List<string> NPC_Liste = new List<string>();
        WebBrowser wBWiki;
        public Kampfrechner()
        {
            //wBWiki = new WebBrowser();
            LoadNPCList();
        }
        private void LoadNPCList()
        {
            StreamReader objReader = new StreamReader(Application.StartupPath + "\\NPC.txt");
            string sLine = "";


            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    NPC_Liste.Add(sLine);
            }
            objReader.Close();
        }
        public int[] GetNPC(string Name)
        {
            int[] Stats = new int[2];
            for (int i = 0; i < NPC_Liste.Count; i++)
            {
                if(NPC_Liste[i].StartsWith(Name))
                {
                    string[] a = NPC_Liste[i].Split(';');
                    Stats[0] = Convert.ToInt32(a[1]);
                    Stats[1] = Convert.ToInt32(a[2]);
                    return Stats;
                }
            }
            Name = Name.Replace(" ", "_");
            Stats = LoadNPCfromWiki(Name);
            NPC_Liste.Add(Name + ";" + Stats[0] + ";" + Stats[1]);
            System.IO.StreamWriter file = new System.IO.StreamWriter("NPC.txt");
            for (int i = 0; i < NPC_Liste.Count; i++)
            {
                file.WriteLine(NPC_Liste[i]);
            }
            file.Close();
            return Stats;
        }
        public bool BerechneKampf(int AS, int AV, int ALP, string VName)
        {
            try
            {
                int[] npc = GetNPC(VName);
                double FaktorVerteidiger;
                if (AV >= npc[0])
                {
                    FaktorVerteidiger = ALP / (1); //1
                }
                else
                {
                    FaktorVerteidiger = ALP / (npc[0] - AV);
                }
                double FaktorAngreifer = npc[1] / (AS - 0);
                if ((((FaktorAngreifer < FaktorVerteidiger)) & ALP != 0 & ALP != 1) | ((FaktorAngreifer < FaktorVerteidiger) & ALP == 1)) //(FaktorAngreifer == FaktorVerteidiger) & ALP == 1 | (FaktorAngreifer - 1 == FaktorVerteidiger) & ALP == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }          
        private static int[] LoadNPCfromWiki(string Name)
        {
                WebClient wc = new WebClient();
                string s = wc.DownloadString("http://www.fwwiki.de/index.php/" + Name);
                string Angriffsstärke = s.Remove(0, s.IndexOf("Angriffsst")+17);
                int Stärke = Convert.ToInt32(Angriffsstärke.Substring(0, Angriffsstärke.IndexOf("<")));
                string Lebenspunkte = s.Remove(0, s.IndexOf("Lebenspunkte:</b>") + 18);
                int LP = Convert.ToInt32(Lebenspunkte.Substring(0, Lebenspunkte.IndexOf("<")));
                int[] Stats = new int[2];
                Stats[0] = Stärke;
                Stats[1] = LP;
            return Stats;
        }
    }
}
