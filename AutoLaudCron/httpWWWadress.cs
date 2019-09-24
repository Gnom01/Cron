using System.Text.RegularExpressions;

namespace AutoLaudCron
{
     class httpWWWadress
     {
        private string ButyKupAll { get; set; }
        private string ButyKupAjaks { get; set; }
        private string ButyKupFst5Min { get; set; }
        private string ButyCzasAll { get; set; }
        private string ButyCzasAjaks { get; set; }
        private string ButyCzasFst5Min { get; set; }
        private string ModaPtakUpdate { get; set; }
        private string ModaPtakFull { get; set; }
        private string ButyAllegro { get; set; }
        private string ModaPtakAllegro { get; set; }
        startLoaud startLoaud = new startLoaud();
        sendMessegeEmail sendMessegeEmail = new sendMessegeEmail();

        ///integration KUPBUTY///
        public string ButyKupAllHTTP()
        {
            ButyKupAll = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdkupbutyxmlimport/cron.php?update=1");
            if (ButyKupAll != "\"all\"")
            {
                sendMessegeEmail.startSendMessegeEmail("ButyKupAll", ButyKupAll);
            }
            return ButyKupAll;
        }
        public string ButyKupAjaksHTTP()
        {
            ButyKupAjaks = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdkupbutyxmlimport/cron.php?ajax_import=-2");
            if (ButyKupAjaks != "")
            {
                sendMessegeEmail.startSendMessegeEmail("ButyKupAjaks", ButyKupAjaks);
            }
            return ButyKupAjaks;
        }

        public string ButyKupFst5MinHTTP()
        {
            ButyKupFst5Min = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdkupbutyxmlimport/cron.php?update=1&fast_update=1");
            int num;
            bool isNum = int.TryParse(ButyKupFst5Min, out num);
            if (!isNum)//namber
            {
                sendMessegeEmail.startSendMessegeEmail("ButyKupFst5Min", ButyKupFst5Min);
            }
            return ButyKupFst5Min;
        }

        ///integration CZASNABUTY///
        public string CzasNaButyAllHTTP()
        {
            ButyCzasAll = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdczasnabutyxmlimport/cron.php?update=1");
            if (ButyCzasAll != "\"all\"")
            {
                sendMessegeEmail.startSendMessegeEmail("ButyCzasAll", ButyCzasAll);
            }
            return ButyCzasAll;
        }

        public string CzasNaButyAjaksHTTP()
        {
            ButyCzasAjaks = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdczasnabutyxmlimport/cron.php?ajax_import=-2");
            if (ButyCzasAjaks != "")
            {
                sendMessegeEmail.startSendMessegeEmail("ButyCzasAjaks", ButyCzasAjaks);
            }
            return ButyCzasAjaks;
        }

        public string CzasNaButyFst5MinHTTP()
        {
            ButyCzasFst5Min = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdczasnabutyxmlimport/cron.php?update=1&fast_update=1");
            int num;
            bool isNum = int.TryParse(ButyCzasFst5Min, out num);
            if (!isNum)//namber
            {
                sendMessegeEmail.startSendMessegeEmail("ButyCzasFst5Min", ButyCzasFst5Min);
            }
            return ButyCzasFst5Min;
        }

        ///integration PTAKMODA///
        public string ModaPtakFullHTTP()
        {
            ModaPtakFull = startLoaud.GetRequest(@"https://multibrend.pl/modules/x13import/cron.php");
            if (ModaPtakFull == "MAX ONE INSTANCE!" || ModaPtakFull == null)
            {
                sendMessegeEmail.startSendMessegeEmail("ModaPtakFull", ModaPtakFull);
            }
            return ModaPtakFull;
        }

        public string ModaPtakUpdate5MinHTTP()
        {
            ModaPtakUpdate = startLoaud.GetRequest(@"https://multibrend.pl/modules/x13import/update.php");
            string messegTrue1 = ModaPtakUpdate;
            string messegTrue = @"SCRIPT COMPLETE - EXECUTE TIME: (.*?)";
            string[] result = Regex.Replace(messegTrue1, @" \s{1,10}", "|", RegexOptions.IgnorePatternWhitespace).Split('|');
            string[] result2 = Regex.Replace(messegTrue, @" \s{1,10}", "|", RegexOptions.IgnorePatternWhitespace).Split('|');

            if (result[0] != result2[0] || 
                result[1] != result2[1] || 
                result[2] != result2[2] || 
                result[3] != result2[3] ||
                result[4] != result2[4] ||
                result[5] != result2[5] )
            {
                sendMessegeEmail.startSendMessegeEmail("ModaPtakUpdate", ModaPtakUpdate);
            }
            return ModaPtakUpdate;
        }

        ///integration PTAKMODA ALLEGRO///
        public string AllegroStartCronPtak()
        {
            ModaPtakAllegro = startLoaud.GetRequest(@"https://multibrend.pl/modules/x13allegro/sync.php?token=Nj60UDQf");
            string messegTrue1 = ModaPtakAllegro;
            string messegTrue = "Konto (ID: 1) yana_yol";
            string[] result = Regex.Replace(messegTrue1, @" \s{1,10}", "|", RegexOptions.IgnorePatternWhitespace).Split('|');
            string[] result2 = Regex.Replace(messegTrue, @" \s{1,10}", " | ", RegexOptions.IgnorePatternWhitespace).Split('|');

            if (result[0] != result2[0] ||
                result[1] != result2[1] ||
                result[2] != result2[2] ||
                result[3] != result2[3] ) 
            {
                sendMessegeEmail.startSendMessegeEmail("ModaPtakAllegro", ModaPtakAllegro);
            }
                return ModaPtakAllegro;
        }

        ///integration ALLEGRO BUTY///
        public string AllegroStartCronButy()
        {
            ButyAllegro = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/x13allegro/sync.php?token=itYak4S4");
            string messegTrue1 = ButyAllegro;
            string messegTrue = "Konto (ID: 1) yana_yol";
            string[] result = Regex.Replace(messegTrue1, @" \s{1,10}", "|", RegexOptions.IgnorePatternWhitespace).Split('|');
            string[] result2 = Regex.Replace(messegTrue, @" \s{1,10}", " | ", RegexOptions.IgnorePatternWhitespace).Split('|');

            if (result[0] != result2[0] ||
                result[1] != result2[1] ||
                result[2] != result2[2] ||
                result[3] != result2[3])
            {
                sendMessegeEmail.startSendMessegeEmail("ButyAllegro", ButyAllegro);
            }
            return  ButyAllegro;
        }
    }
}