using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace FreeWarBot12
{
    public class PathFinder
    {
        System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();
        public List<Point> healList = new List<Point>();
        public List<Point> allPoints = new List<Point>();
        Random rnd = new Random();     
        public PathFinder()
        {
            healList.Add(new Point(84, 97));
            healList.Add(new Point(-584, -494));
            healList.Add(new Point(-348, -697));
            healList.Add(new Point(99, 115));
            healList.Add(new Point(506, 55));
            healList.Add(new Point(105, 106));
            healList.Add(new Point(96, 107));
            healList.Add(new Point(68, 109));
            healList.Add(new Point(100, 99));
            healList.Add(new Point(106, 90));
            healList.Add(new Point(110, 115));
            wb.Navigate(Application.StartupPath + "\\autoroute.html");
        }
        public void LoadPoints()
        {
            string line1 = "";
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + @"\AllPoints.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                line1 += line;
            }
            line1 = line1.Replace(" 1, ", "");
            line1 = line1.Replace("\"", "");
            line1 = line1.Replace(" ", "");

            string[] Points = line1.Split(':');
            for (int i = 0; i < Points.Length -1; i++)
            {
                string[] position = Points[i].Split('|');
                allPoints.Add(new Point(Convert.ToInt32(position[0]), Convert.ToInt32(position[1])));
            }
        }
        public List<string> RandomWay(Point start)
        {
            return Directions(start, allPoints[rnd.Next(0, allPoints.Count)]);
            
        }
        public List<string> RandomWayWithoutDiebeshöhle(Point start)
        {
            List<string> direction = DirectionsWithoutDiebeshoehle(start, allPoints[rnd.Next(0, allPoints.Count)]);
            return direction;
        }
        public List<string> ShortestWayToShop(Point start)
        {
            List<string> shortest = new List<string>();
            for (int i = 0; i < Settings.ShopList.Count; i++)
            {
                List<string> m = Directions(start, Settings.ShopList[i]);
                if (((shortest.Count > m.Count)|(shortest.Count == 0)) & m.Count != 0)
                {
                    shortest = m;
                }
            }
            return shortest;

        }
        public List<string> ShortestWayToHeal(Point start)
        {
            List<string> shortest = new List<string>();
            for (int i = 0; i < healList.Count; i++)
            {
                List<string> m = Directions(start, healList[i]);
                if (m == null)
                {
                    return new List<string>() ;
                }
                if (((shortest.Count > m.Count) | (shortest.Count == 0)) & m.Count != 0)
                {
                    shortest = m;
                }
            }
            return shortest;
        }
        public List<string> Directions(Point start, Point end)
        {
            try
            {
                
                object[] codeString = { start.X + "|" + start.Y, end.X + "|" + end.Y };
                string result = (string)wb.Document.InvokeScript("finde_weg", codeString);
                if (result.Contains("Länge: 0"))
                {
                    return null;
                }
                if (result != null)
                {
                    string Fußweg = result.Remove(0, result.IndexOf("reiner Fußweg"));
                    Fußweg = Fußweg.Remove(0, Fußweg.IndexOf("Weg: Start->") + 12);
                    Fußweg = Fußweg.Replace(">", String.Empty);
                    Fußweg = Fußweg.Substring(0, Fußweg.IndexOf("<br"));
                    char[] fußweg = Fußweg.ToCharArray();
                    char before = 'a';
                    for (int i = 0; i < fußweg.Length; i++)
                    {
                        if (fußweg[i] == before & before == '-')
                        {
                            fußweg[i] = '!';
                        }
                        else if (fußweg[i] == '-' & before == '|')
                        {
                            fußweg[i] = '!';
                        }
                        else if (fußweg[i] == '-' & i == 0)
                        {
                            fußweg[i] = '!';
                        }
                        before = fußweg[i];
                    }
                    Fußweg = new string(fußweg);
                    string[] coords = Fußweg.Split('-');
                    List<string> Coords = coords.ToList();
             
                    List<Point> coordsPoint = new List<Point>();

                        for (int i = 0; i < Coords.Count; i++)
                        {
                        
                            if (Coords[i].ToString().Contains("Vom Fluss fortgespült"))
                            {
                               break;

                            }
                            if (Coords[i].ToString().Contains("betreten"))
                            {
                                coordsPoint.Add(new Point(0, 0));

                            }
                            else if (Coords[i].ToString().Contains("verlassen"))
                            {
                                coordsPoint.Add(new Point(0, 0));

                            }
                            else if (Coords[i].ToString().Contains("Dem Pfad in die Berge folgen"))
                            {
                                coordsPoint.Add(new Point(-1, -1));
                            }
                            else
                            {
                                Coords[i] = Coords[i].Replace("!", "-");
                                string[] s = Coords[i].Split('|');
                                coordsPoint.Add(new Point(Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
                            }
                        }
                    
                    for (int i = 0; i < coordsPoint.Count; i++)
                    {
                        if (coordsPoint[i].X == 0 & coordsPoint[i].Y == 0)
                        {
                            start = coordsPoint[i + 1];
                            Coords.RemoveAt(i + 1);
                            coordsPoint.RemoveAt(i + 1);
                            Coords[i] = "be";
                            
                        }
                        else if (coordsPoint[i].X == -1 & coordsPoint[i].Y == -1)
                        {
                            start = coordsPoint[i + 1];
                            Coords.RemoveAt(i + 1);
                            coordsPoint.RemoveAt(i + 1);
                            Coords[i] = "dem pfad in die berge folgen";

                        }
                        else if (coordsPoint[i].X == start.X & coordsPoint[i].Y < start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "up";
                        }
                        else if (coordsPoint[i].X == start.X & coordsPoint[i].Y > start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "down";
                        }
                        else if (coordsPoint[i].X < start.X & coordsPoint[i].Y == start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "left";
                        }
                        else if (coordsPoint[i].X > start.X & coordsPoint[i].Y == start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "right";
                        }
                        else if (coordsPoint[i].X > start.X & coordsPoint[i].Y > start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "downright";
                        }
                        else if (coordsPoint[i].X > start.X & coordsPoint[i].Y < start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "upright";
                        }
                        else if (coordsPoint[i].X < start.X & coordsPoint[i].Y < start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "upleft";
                        }
                        else if (coordsPoint[i].X < start.X & coordsPoint[i].Y > start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "downleft";
                        }
                    }
                    return Coords;
                }
                else return new List<string>();
            }
            catch(Exception e) { return new List<string>(); }
        }
        public List<string> DirectionsWithoutDiebeshoehle(Point start, Point end)
        {
            try
            {
                restart:
                object[] codeString = { start.X + "|" + start.Y, end.X + "|" + end.Y };
                string result = (string)wb.Document.InvokeScript("finde_weg", codeString);
                if (result.Contains("Länge: 0"))
                {
                    return null;
                }
                if (result != null)
                {
                    string Fußweg = result.Remove(0, result.IndexOf("reiner Fußweg"));
                    Fußweg = Fußweg.Remove(0, Fußweg.IndexOf("Weg: Start->") + 12);
                    Fußweg = Fußweg.Replace(">", String.Empty);
                    Fußweg = Fußweg.Substring(0, Fußweg.IndexOf("<br"));
                    char[] fußweg = Fußweg.ToCharArray();
                    char before = 'a';
                    for (int i = 0; i < fußweg.Length; i++)
                    {
                        if (fußweg[i] == before & before == '-')
                        {
                            fußweg[i] = '!';
                        }
                        else if (fußweg[i] == '-' & before == '|')
                        {
                            fußweg[i] = '!';
                        }
                        else if (fußweg[i] == '-' & i == 0)
                        {
                            fußweg[i] = '!';
                        }
                        before = fußweg[i];
                    }
                    Fußweg = new string(fußweg);
                    string[] coords = Fußweg.Split('-');
                    List<string> Coords = coords.ToList();
                    if (coords.Contains("!934 | !552"))
                    {
                        goto restart;
                    }
                    List<Point> coordsPoint = new List<Point>();

                    for (int i = 0; i < Coords.Count; i++)
                    {

                        if (Coords[i].ToString().Contains("Vom Fluss fortgespült"))
                        {
                            break;

                        }
                        if (Coords[i].ToString().Contains("betreten"))
                        {
                            coordsPoint.Add(new Point(0, 0));

                        }
                        else if (Coords[i].ToString().Contains("verlassen"))
                        {
                            coordsPoint.Add(new Point(0, 0));

                        }
                        else if (Coords[i].ToString().Contains("Dem Pfad in die Berge folgen"))
                        {
                            coordsPoint.Add(new Point(-1, -1));
                        }
                        else
                        {
                            Coords[i] = Coords[i].Replace("!", "-");
                            string[] s = Coords[i].Split('|');
                            coordsPoint.Add(new Point(Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
                        }
                    }

                    for (int i = 0; i < coordsPoint.Count; i++)
                    {
                        if (coordsPoint[i].X == 0 & coordsPoint[i].Y == 0)
                        {
                            start = coordsPoint[i + 1];
                            Coords.RemoveAt(i + 1);
                            coordsPoint.RemoveAt(i + 1);
                            Coords[i] = "be";

                        }
                        else if (coordsPoint[i].X == -1 & coordsPoint[i].Y == -1)
                        {
                            start = coordsPoint[i + 1];
                            Coords.RemoveAt(i + 1);
                            coordsPoint.RemoveAt(i + 1);
                            Coords[i] = "dem pfad in die berge folgen";

                        }
                        else if (coordsPoint[i].X == start.X & coordsPoint[i].Y < start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "up";
                        }
                        else if (coordsPoint[i].X == start.X & coordsPoint[i].Y > start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "down";
                        }
                        else if (coordsPoint[i].X < start.X & coordsPoint[i].Y == start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "left";
                        }
                        else if (coordsPoint[i].X > start.X & coordsPoint[i].Y == start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "right";
                        }
                        else if (coordsPoint[i].X > start.X & coordsPoint[i].Y > start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "downright";
                        }
                        else if (coordsPoint[i].X > start.X & coordsPoint[i].Y < start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "upright";
                        }
                        else if (coordsPoint[i].X < start.X & coordsPoint[i].Y < start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "upleft";
                        }
                        else if (coordsPoint[i].X < start.X & coordsPoint[i].Y > start.Y)
                        {
                            start = coordsPoint[i];
                            Coords[i] = "downleft";
                        }
                    }
                    return Coords;
                }
                else return new List<string>();
            }
            catch (Exception e) { return new List<string>(); }
        }
    }
}

