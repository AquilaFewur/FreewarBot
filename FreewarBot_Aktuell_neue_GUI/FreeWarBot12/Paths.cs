using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeWarBot12
{
    class Paths
    {
        public static List<string> _Actual = new List<string>();

        public static List<string> Goldmiene = new List<string>()
        {
             "gzk-konlir","left", "left" , "left", "upleft", "left"
        };
        public static List<string> GoldsiebenNawor = new List<string>()
        {
             "gzk-nawor","up", "upleft" , "up", "up", "up"
        };
        public static List<string> Loranien = new List<string>()
        {
             "gzk-anatubien","downleft", "down" , "down", "down", "downright","down","down","down","downright","down","downleft","down","downleft","left"
        };
        public static List<string> Ingerium = new List<string>()
        {
             "gzk-hewien","down", "down" , "be2062", "upleft", "upleft","up","upleft"
        };
        public static List<string> unreinesIngerium = new List<string>()
        {
             "gzk-hewien","down", "down" , "be2062", "upleft", "upleft","up","up"
        };
        public static List<string> ToBankPlefir = new List<string>()
        {
             "gzk-hewien","down", "down" , "be2062", "upleft", "upleft","up","up"
        };
        public static List<string> Plefir = new List<string>()
        {
             "gzk-hewien","down", "down" , "be2062", "upleft", "upleft","up","up"
        };
    }
}
