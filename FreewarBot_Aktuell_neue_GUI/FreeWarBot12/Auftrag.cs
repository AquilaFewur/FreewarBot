using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FreeWarBot12
{
    public class Auftrag
    {
        public List<object> Ways = new List<object>();
        public string Name;
        public string Finish;
        public bool Peace;
        Random rnd = new Random();
        public  Point startPoint;

        public Auftrag(List<object> ways, string name, bool peace, string finish)
        {
            Peace = peace;
            Ways = ways;
            Name = name;
            Finish = finish;

        }
        public List<string> Way
        {
            get
            {
                return (List<string>)Ways[0];
            }
        } 
    }
}
