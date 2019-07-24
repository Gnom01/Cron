using System;

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

         ///integration KUPBUTY///
        public string ButyKupAllHTTP()
        {
           ButyKupAll = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdkupbutyxmlimport/cron.php?update=1");
            if(ButyKupAll == "\"all\"")
            {
                Console.WriteLine("Kup buty wszystko ładue");
            }
            return ButyKupAll;
        }

        public string ButyKupAjaksHTTP()
        {
            ButyKupAjaks = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdkupbutyxmlimport/cron.php?ajax_import=-2");
            if (ButyKupAjaks == "")
            {
                Console.WriteLine("Kup buty AJAKS ładue");
            }
            return ButyKupAjaks;
        }

        public string ButyKupFst5MinHTTP()
        {
            ButyKupFst5Min = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdkupbutyxmlimport/cron.php?update=1&fast_update=1");
            if (ButyKupFst5Min == "")
            {
                Console.WriteLine("Kup buty AJAKS ładue");
            }
            return ButyKupFst5Min;
        }

        ///integration CZASNABUTY///
        public string CzasNaButyAllHTTP()
        {
                ButyCzasAll = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdczasnabutyxmlimport/cron.php?update=1");
            if (ButyCzasAll == "\"all\"")
            {
                Console.WriteLine("Czas na buty wszystko ładue ALL");
            }
            return ButyCzasAll;
        }

        public string CzasNaButyAjaksHTTP()
        {
            ButyCzasAjaks = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdczasnabutyxmlimport/cron.php?update=1");
            if (ButyCzasAjaks == "")
            {
                Console.WriteLine("Czas na buty Ajaks ładue");
            }
            else
            {

            }
            return ButyCzasAjaks;
        }

        public string CzasNaButyFst5MinHTTP()
        {
            ButyCzasFst5Min = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/pdczasnabutyxmlimport/cron.php?update=1&fast_update=1");
            if (ButyCzasFst5Min == "")
            {
                Console.WriteLine("Czas na buty Fst 5 Min");
            }
            return ButyCzasFst5Min;
        }

        ///integration PTAKMODA///
        public string ModaPtakFullHTTP()
        {
            ModaPtakFull = startLoaud.GetRequest(@"https://multibrend.pl/modules/x13import/cron.php");
            if(true)
            {

            }
            return ModaPtakFull;
        }

        public string ModaPtakUpdate5MinHTTP()
        {
            ModaPtakUpdate = startLoaud.GetRequest(@"https://multibrend.pl/modules/x13import/update.php");
            if (true)
            {

            }
            return ModaPtakUpdate;
        }

        ///integration PTAKMODA ALLEGRO///
        public string AllegroStartCronPtak()
        {
            ModaPtakAllegro = startLoaud.GetRequest(@"https://multibrend.pl/modules/x13allegro/sync.php?token=Nj60UDQf");
            return ModaPtakAllegro;
        }

        ///integration ALLEGRO BUTY///
        public string AllegroStartCronButy()
        {
            ButyAllegro = startLoaud.GetRequest(@"https://www.butyesklep.pl/sklep/modules/x13allegro/sync.php?token=itYak4S4");
            return  ButyAllegro;
        }
    }
}