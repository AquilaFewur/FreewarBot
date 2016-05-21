using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Freewar
{
    static class  Player
    {
        static int _XP;
        static  int _Money;
        static int _MaxLP;
        static int _CurrentLP;
        static string _Name;
        static DateTime _Federation;
        static DateTime _Oil;

        public static string Name
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
        public static DateTime Oil
        {
            get
            {
                return _Oil;
            }
            set
            {
                _Oil = value;
            }
        }
        public static DateTime Federation
        {
            get
            {
                return _Federation;
            }
            set
            {
                _Federation = value;
            }
        }
        public static int XP
        {
            get
            {
                return _XP;
            }
            set
            {
                _XP = value;
            }
        }
        public static int Money
        {
            get
            {
                return _Money;
            }
            set
            {
                _Money = value;
            }
        }
        public static int CurrentLP
        {
            get
            {
                return _CurrentLP;
            }
            set
            {
                _CurrentLP = value;
            }
        }
        public static int MaxLp
        {
            get
            {
                return _MaxLP;
            }
            set
            {
                _MaxLP = value;
            }
        }
    }
}
