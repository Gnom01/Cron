using System;

namespace AutoLaudCron
{
    class TimerStart
    {
        public void OnTimedEvent()
        {
            httpWWWadress httpWWWadress = new httpWWWadress();
            int timeMinute10 = 0;
            int timeHour = 0;
            timeHour = DateTime.Now.Hour;
            timeMinute10 = DateTime.Now.Minute;
            if(timeMinute10 == 00 || timeMinute10 == 10 || timeMinute10 == 20 || timeMinute10 == 30 || timeMinute10 == 40 || timeMinute10 == 50)
            {
                httpWWWadress.ButyKupFst5MinHTTP();
                httpWWWadress.CzasNaButyFst5MinHTTP();
                httpWWWadress.ModaPtakUpdate5MinHTTP();
                httpWWWadress.AllegroStartCronPtak();
                httpWWWadress.AllegroStartCronButy();
            }
            if(timeHour == 22 || timeHour == 03|| timeHour == 06 || timeHour == 14)
            {
                httpWWWadress.ButyKupAjaksHTTP();
                httpWWWadress.ButyKupAllHTTP();
                httpWWWadress.CzasNaButyAjaksHTTP();
                httpWWWadress.CzasNaButyAllHTTP();
                httpWWWadress.ModaPtakFullHTTP();

            }
        }
    }
}
