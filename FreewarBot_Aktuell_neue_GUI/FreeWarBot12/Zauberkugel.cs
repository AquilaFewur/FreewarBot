using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeWarBot12
{
    class Zauberkugel
    {
        public static string Konlir = "<SELECT name=z_pos_id> <OPTION selected value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Anatubien = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION selected value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Bank = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION selected value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Reikan = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION selected value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string DasTalDerRuinen = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION selected value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string DasvergesseneTal = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION selected value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Mentoran = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION selected value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Narubia = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION selected value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Nawor = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION selected value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Buran = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION selected value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Sutranien = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION selected value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Hewien = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION selected value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Orewu = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION selected value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string DasCasinovonFerdolien = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION selected value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Kanobien = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION selected value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Terasi = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION selected value=1715>Terasi - Der Fluss</OPTION> <OPTION value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";
        public static string Lodradon = "<SELECT name=z_pos_id> <OPTION value=2>Konlir - Die immergrünen Wiesen</OPTION> <OPTION value=68>Anatubien - Der Wald der Akademie</OPTION> <OPTION value=73>Bank aller Wesen</OPTION> <OPTION value=87>Reikan - Die Trockenebene</OPTION> <OPTION value=110>Das Tal der Ruinen</OPTION> <OPTION value=169>Das vergessene Tal</OPTION> <OPTION value=290>Mentoran - Die Oase</OPTION> <OPTION value=387>Narubia - Die Nebelbank</OPTION> <OPTION value=437>Nawor - Die Kakteenebene</OPTION> <OPTION value=538>Buran - Der Westbereich</OPTION> <OPTION value=816>Sutranien - Die kühle Ebene</OPTION> <OPTION value=884>Hewien - Kantige Felsen</OPTION> <OPTION value=988>Orewu - Der Salzsee</OPTION> <OPTION value=1079>Das Casino von Ferdolien</OPTION> <OPTION value=1321>Kanobien - Der Wasserfall</OPTION> <OPTION value=1715>Terasi - Der Fluss</OPTION> <OPTION selected value=4304>Lodradon - Der organische Turm</OPTION></SELECT>";

        public static string Destination(string s)
        {
            s= s.ToLower();
            if (s == "konlir")
            {
                return Konlir;
            }
            if (s == "anatubien")
            {
                return Anatubien;
            }
            if (s == "bank")
            {
                return Bank;
            }
            if (s == "reikan")
            {
                return Reikan;
            }
            if (s == "dastalderruinen")
            {
                return DasTalDerRuinen;
            }
            if (s == "dasvergessenetal")
            {
                return DasvergesseneTal;
            }
            if (s == "mentoran")
            {
                return Mentoran;
            }
            if (s == "narubia")
            {
                return Narubia;
            }
            if (s == "nawor")
            {
                return Nawor;
            }
            if (s == "buran")
            {
                return Buran;
            }
            if (s == "sutranien")
            {
                return Sutranien;
            }
            if (s == "hewien")
            {
                return Hewien;
            }
            if (s == "orewu")
            {
                return Orewu;
            }
            if (s == "dascasinovonferdolien")
            {
                return DasCasinovonFerdolien;
            }
            if (s == "kanobien")
            {
                return Kanobien;
            }
            if (s == "terasi")
            {
                return Terasi;
            }
            if (s == "lodradon")
            {
                return Lodradon;
            }
            return null;
        }
    }
}
