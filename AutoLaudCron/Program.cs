namespace AutoLaudCron
{
    class Program
    {
        static void Main(string[] args)
        {
            httpWWWadress httpWW = new httpWWWadress();
            startLoaud start = new startLoaud();
            TimerStart timerStart = new TimerStart();
            while (true)
            {
                timerStart.OnTimedEvent();
            }
        }
    }
}