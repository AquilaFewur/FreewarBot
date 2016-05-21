using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeWarBot12
{
    class NPC
    {
        string _Name;
        string _Link;
        int _Staerke;

        public NPC(string name, string link, int staerke)
        {
            _Name = name;
            _Link = link;
            _Staerke = staerke;
        }
       

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Link
        {
            get
            {
                return _Link;
            }
            set
            {
                _Link = value;
            }
        }
        public int Staerke
        {
            get
            {
                return _Staerke;
            }
            set
            {
                _Staerke = value;
            }
        }
    }
}
