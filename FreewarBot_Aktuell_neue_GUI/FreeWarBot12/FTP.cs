using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Freewar
{
    class FTP
    {
        public string Read()
        {
            //CREATE AN FTP REQUEST WITH THE DOMAIN AND CREDENTIALS
            System.Net.FtpWebRequest tmpReq = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create("FTP://a1b2c3d4.square7.ch/Online.txt");
            tmpReq.Credentials = new System.Net.NetworkCredential("a1b2c3d4_Test", "Test");

            //GET THE FTP RESPONSE
            using (System.Net.WebResponse tmpRes = tmpReq.GetResponse())
            {
                //GET THE STREAM TO READ THE RESPONSE FROM
                using (System.IO.Stream tmpStream = tmpRes.GetResponseStream())
                {
                    //CREATE A TXT READER (COULD BE BINARY OR ANY OTHER TYPE YOU NEED)
                    using (System.IO.TextReader tmpReader = new System.IO.StreamReader(tmpStream))
                    {
                        //STORE THE FILE CONTENTS INTO A STRING
                        return tmpReader.ReadToEnd();

                    }
                }
            }
        }
        public void Upload(string text)
        {
            StreamWriter myWriter = File.CreateText(System.IO.Path.GetTempPath() + text.Substring(0,3));
            myWriter.WriteLine(text);
            myWriter.Close();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("FTP://a1b2c3d4.square7.ch//" + text.Substring(0,3) + ".txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("a1b2c3d4_Test", "Test");

            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(System.IO.Path.GetTempPath() + text.Substring(0, 3));
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();


            response.Close();
        }
    }


}