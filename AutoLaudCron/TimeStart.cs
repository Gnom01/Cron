using System;

namespace AutoLaudCron
{
    class TimerStart
    {
        public void OnTimedEvent()
        {
            httpWWWadress httpWWWadress = new httpWWWadress();
            ConnectionBD connection = new ConnectionBD();
            int timeMinute10 = 0;
            int timeHour = 0;
            timeHour = DateTime.Now.Hour;
            timeMinute10 = DateTime.Now.Minute;
            if(timeMinute10 == 02 || 
               timeMinute10 == 11 || 
               timeMinute10 == 20 || 
               timeMinute10 == 30 || 
               timeMinute10 == 40 || 
               timeMinute10 == 50)
            {
                connection.SendInfoBD5minCron();
            }
            if ((timeHour == 22 && timeMinute10 == 00) || 
                (timeHour == 10 && timeMinute10 == 00) || 
                (timeHour == 12 && timeMinute10 == 00) || 
                (timeHour == 14 && timeMinute10 == 00))
            {
                connection.SendInfoBDFullCron();
            }
        }
    }
}