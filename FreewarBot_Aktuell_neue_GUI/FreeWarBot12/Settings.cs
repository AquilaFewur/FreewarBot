using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FreeWarBot12
{
    static class Settings
    {
        public static string _Username;
        public static string _Password;
        public static string _World;
        public static string _Useragent;
        public static bool trainAbility = false;
        public static bool _AutoArbeiter = false;
        public static string _ability;
        public static bool _StoreArrows = false;
        public static bool _ChangeArea = false;
        public static int ChangeTime = 30;
        public static bool _TranserMoney = false;
        public static int _TranferMoney = 10000;
        public static string _TransferReceiver = ""; 
        public static bool _Autowalk = false;
        public static bool _Auftraege = false;
        public static string _aktuellerAuftrag;
        public static string _huntingArea = "Random";
        public static string aktuellerAuftragstext;
        public static bool LoggedIn = false;
        public static bool usediebeshoehle = false;
        public static int MaxMoney = 2000;
        public static bool _attack = false;
        public static bool _playerkiller = false;
        public static bool _take = false;
        public static bool _RepairWeapons = false;
        public static int _RepairWeaponsValue = 80;
        public static bool _sell = false;
        public static bool _maha = false;
        public static int _minLP = 0;
        public static List<Point> ShopList = new List<Point>();
        public static List<string> _Path = new List<string>();
        public static List<string> _Avoid_NPC = new List<string>();
        public static List<string> _Heal_Items = new List<string>();
        public static List<Item>_Items = new List<Item>();
        public static bool IsBotRunning = false;
        public static Point CaptchaCrackerPlace = new Point(96, 99);
        public static string Lizenz;
        public static string LizenzID;
        public static DateTime LastOilPickUp = DateTime.MinValue;
        public static DateTime LastFederationPickUp = DateTime.MinValue;
        public static DateTime LastSumpfgasPickUp = DateTime.MinValue;
        public static DateTime Starttime;
        public static bool PickUpOil = false;
        public static bool PickUpFederation = false;
        public static bool PickUpSumpfgas = false;
        public static bool UseProtection = false;
        public static List<string> Action = new List<string>();
        public static int StartXP;
        public static int CollectOil = 24;
        public static bool NPCVerjagen = false;
       // public static string Cookies;
        //public static string MapDocumentText;
        public static int PX;
        public static int PY;
        public static int CaptchaCounter = 0;
        public static bool ShowBot = false;
        public static bool Harvest = false;
        public static string Cookie = null;
        public static DateTime _LicenceExpiration;
        public static Point AuftragsPunkt;
        public static string _forumName;
        public static string sessionCookie;
        public static string _DerString;
    }
}
