using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreeWarBot12
{
    static class SerialChecker
    {
        static long newInt1;
        static long newInt;
        public static bool Check(string serial)
        {
            Settings.LizenzID = serial;
            try
            {
                string[] serials = serial.Split('-');
                if (serials.Length != 5)
                {
                    return false;
                }
                for (int i = 0; i < serials.Length; i++)
                {
                    for (int j = 0; j < serials.Length; j++)
                    {
                        if (j != i)
                        {
                            if (serials[j] == serials[i])
                            {
                                return false;
                            }
                        }
                    }

                }
                string[] a = new string[serials.Length];
                serials.CopyTo(a, 0);
                string[] sortetarray = SortArray(a);
                if ((serials[0] == sortetarray[0]) & (serials[1] == sortetarray[1]) & (serials[2] == sortetarray[2]) & (serials[3] == sortetarray[3]) & (serials[4] == sortetarray[4]))
                {
                    for (int i = 0; i < serials.Length; i++)
                    {
                        newInt = Convert.ToInt64(serials[i]) / 7;
                        string s = newInt.ToString();
                        if ((Convert.ToInt32(s[0].ToString()) + Convert.ToInt32(s[1].ToString()) == 9) & (Convert.ToInt32(s[2].ToString()) + Convert.ToInt32(s[3].ToString()) == 9) & (Convert.ToInt32(s[4].ToString()) + Convert.ToInt32(s[5].ToString()) == 9) & (Convert.ToInt32(s[6].ToString()) + Convert.ToInt32(s[7].ToString()) == 9) & (Convert.ToInt32(s[8].ToString()) + Convert.ToInt32(s[9].ToString()) == 9) & (Convert.ToInt32(s[10].ToString()) + Convert.ToInt32(s[11].ToString()) == 9) & (Convert.ToInt64(serials[i]) % 7 == 0))
                        {
                        }
                        else
                        {
                            
                            if (Convert.ToInt64(serials[i]) % 6 == 0)
                            {
                                newInt1 = Convert.ToInt64(serials[i]) / 6;
                                string s1 = newInt1.ToString();
                                if ((Convert.ToInt32(s1[0].ToString()) + Convert.ToInt32(s1[1].ToString()) == 9) & (Convert.ToInt32(s1[2].ToString()) + Convert.ToInt32(s1[3].ToString()) == 9) & (Convert.ToInt32(s1[4].ToString()) + Convert.ToInt32(s1[5].ToString()) == 9) & (Convert.ToInt32(s1[6].ToString()) + Convert.ToInt32(s1[7].ToString()) == 9) & (Convert.ToInt32(s1[8].ToString()) + Convert.ToInt32(s1[9].ToString()) == 9) & (Convert.ToInt32(s1[10].ToString()) + Convert.ToInt32(s1[11].ToString()) == 9))
                                {

                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                            if (i == 4)
                            {
                                if (Settings.LizenzID == "3818073796416-4368818203686-1101655112778-3261873817854-1128981267054")
                                {
                                Settings.Lizenz = "Trail";
                                MessageBox.Show("Sie benutzen eine Free Version von FwZy Bot! Diese Version ist sehr eingeschränkt und viele Features stehen in dieser Version nicht zur Verfügung. Um den vollen Umfang nutzen zu können, kaufen Sie sich eine Lizenz!");
                                return true;
                                }
                                else
                                {
                                    Settings.Lizenz= "Premium";
                                    return true;
                                }
                            }
                        }
                    }
                    Settings.Lizenz = "Standard";
                    return true;
                }
                else
                {
                    return false;
                }
            }
              
            catch (Exception e)
            {
                return false;
            }
        }
        private static string[] SortArray(string[] liste1)
        {
            string[] liste = liste1;
            int value = Convert.ToInt32(liste[0][1].ToString());
            bool PaarSortiert;

            //solange nicht alle paare bei jedem  Durchlauf     
            //sortiert sind, Alg. wiederholen. 
            //->BubbleSort verfahren

            do
            {

                PaarSortiert = true;

                for (int i = 1; i < liste.Length - 1; i++)
                {

                    if (Convert.ToInt32(liste[i][value]) > liste[i + 1][value])
                    {

                        //zahlen tauschen (nur ein Paar)

                        string temp = liste[i];

                        liste[i] = liste[i + 1];

                        liste[i + 1] = temp;

                        //nicht sortiert

                        PaarSortiert = false;

                    }

                }


            } while (!PaarSortiert);

            //Zurückgeben der sortieren Liste

            return liste;
        }
    }
}