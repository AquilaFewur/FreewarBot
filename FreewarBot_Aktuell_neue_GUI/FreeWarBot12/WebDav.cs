using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace FreeWarBot12
{
    static class Webdav
    {

        public static bool CheckIfOnline()
        {
            //DownloadFile("Verwaltung/Online.txt", System.IO.Path.GetTempPath() + "\\syslog");
            //System.IO.StreamReader file = null;
            //file = new System.IO.StreamReader(System.IO.Path.GetTempPath() + "\\syslog");

            //string line = file.ReadLine();
            //if (line == "fwzy2106" || line == "BaW2015")
            {
                return true;
            }
            //else
            //{
            //    return false;
            //}
        }

        public static string GetSecureString()
        {
           
            return "Move";
        }

        public static bool CheckIfCookieIsOK()
        {
            try
            {
                //DownloadFile(Settings._forumName + "/" + "SessionCookie", System.IO.Path.GetTempPath() + "\\AdobeReader");
                //System.IO.StreamReader file = null;
                //file = new System.IO.StreamReader(System.IO.Path.GetTempPath() + "\\AdobeReader");

                //string line = file.ReadLine();
                //file.Close();
                //if (line == Settings.sessionCookie)
                //{
                    return true;
                //}
                //else
                //{
                //    Environment.Exit(0);
                //    return false;
                //}
            }
            catch
            {
                Environment.Exit(0);
                return false;
            }
        }

        public static void UploadInformations(string text)
        {
            //Random Rnd = new Random(); // initialisiert die Zufallsklasse
            //int cookie= Rnd.Next(100000000, 900000000);
            //Settings.sessionCookie = cookie.ToString();

            //string serial = "";
            //if(Settings._forumName == null)
            //{
            //    Environment.Exit(0);
            //}
            //CreateFolder(Settings._forumName);
            //StreamWriter myWriter = File.CreateText(System.IO.Path.GetTempPath() + "syslogname");
            //myWriter.WriteLine(text);
            //myWriter.Close();

            //StreamWriter myWriter2 = File.CreateText(System.IO.Path.GetTempPath() + "cookie");
            //myWriter2.WriteLine(Settings.sessionCookie);
            //myWriter2.Close();

            //UploadFile(System.IO.Path.GetTempPath() + "cookie", Settings._forumName + "/" + "SessionCookie");

        }
        public static void UploadInformationsOld(string text)
        {
            //string serial = "";
            //try
            //{
            //    System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\Serial.txt");
            //    serial = file.ReadLine();
            //}
            //catch
            //{
            //    Environment.Exit(0);
            //}
            //CreateFolder(serial);
            //StreamWriter myWriter = File.CreateText(System.IO.Path.GetTempPath() + "syslogname");
            //myWriter.WriteLine(text);
            //myWriter.Close();
            //UploadFile(System.IO.Path.GetTempPath() + "syslogname", serial + "/" + text);
            //string s = "";
            //if (File.Exists(System.IO.Path.GetTempPath() + "\\syslog1")) ;
            //{
            //    try
            //    {
            //        File.Delete(System.IO.Path.GetTempPath() + "\\syslog1");
            //    }
            //    catch { }
            //}
            //try
            //{
            //    DownloadFile(serial + "/licensedUsers.txt", System.IO.Path.GetTempPath() + "\\syslog1");
            //    System.IO.StreamReader file1 = null;
            //    file1 = new System.IO.StreamReader(System.IO.Path.GetTempPath() + "\\syslog1");
            //    s = file1.ReadLine();
            //    file1.Close();
            //}
            //catch { }
            //if (!s.Contains(text))
            //{
            //    if ((s.Split(',').Length == 4) & Settings.Lizenz != "Trail")
            //    {
            //        MessageBox.Show("Maximale Anzahl der Accounts überschritten!");
            //        Environment.Exit(0);
            //    }
            //    StreamWriter myWriter1 = File.CreateText(System.IO.Path.GetTempPath() + "syslog12");
            //    myWriter1.WriteLine(s + text + ",");
            //    myWriter1.Close();
            //    UploadFile(System.IO.Path.GetTempPath() + "syslog12", serial + "/" + "licensedUsers.txt");
            //}
        }

        public static void DeleteFileOrFolder(string Site, NetworkCredential nc)
        {
            try
            {
                HttpWebRequest request = (System.Net.HttpWebRequest)HttpWebRequest.Create(Site);
                request.Credentials = nc;// CredentialCache.DefaultCredentials;
                request.Method = "DELETE";
                WebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception e)
            {
            }
        }
        
    }
}
