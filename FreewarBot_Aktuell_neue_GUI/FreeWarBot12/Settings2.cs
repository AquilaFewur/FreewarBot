using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Freewar
{
    static class Settings2
    {
        public static string _Username;
        public static string _Password;
        public static string _World;
        public static string _Useragent;
        public static bool trainAbility = false;
        public static string _ability;
        public static bool _Autoarbeiter = false;
        public static bool _StoreArrows = false;
        public static bool _ChangeArea = false;
        public static int ChangeTime = 30;
        public static bool _TranserMoney = false;
       
        public static int _TranferMoney = 10000;
        public static string _TransferReceiver = ""; 
        public static bool _Autowalk = false;
        public static string _huntingArea = "Random";
        public static bool LoggedIn = false;
        public static int MaxMoney = 2000;
        public static bool _attack = false;
        public static bool _playerkiller = false;
        public static bool _take = false;
        public static bool _sell = false;
        public static bool _maha = false;
        public static int _minLP = 0;
        public static List<Point> ShopList = new List<Point>();
        public static List<string> _Path = new List<string>();
        public static bool IsBotRunning = false;
        public static string Lizenz;
    }
}
