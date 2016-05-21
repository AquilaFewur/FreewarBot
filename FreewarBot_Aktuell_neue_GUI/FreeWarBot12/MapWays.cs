using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FreeWarBot12
{
    public class MapWays
    {
        List<object> Ways = new List<object>();
        List<object> BankWays = new List<object>();
        public string Name;
        Random rnd = new Random();
        public  Point startPoint;

        public MapWays(List<object> ways, string name, Point start)
        {
            Ways = ways;
            Name = name;
            startPoint = start;
        }
        public List<string> Way
        {
            get
            {
                int i = rnd.Next(0,Ways.Count);
                return (List<string>)Ways[i];
            }
        }
        public List<string> BankWay
        {
            get
            {
                int i = rnd.Next(0, BankWays.Count) - 1;
                return (List<string>)BankWays[i];
            }
        }
        
    }
}
