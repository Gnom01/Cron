using System;
using System.Net;

namespace AutoLaudCron
{
    class startLoaud
    {
        private class WebClient : System.Net.WebClient
        {
            public int Timeout { get; set; }
            protected override WebRequest GetWebRequest(Uri adresWww)
            {
                WebRequest webRequest = base.GetWebRequest(adresWww);
                webRequest.Timeout = Timeout;
                ((HttpWebRequest)webRequest).ReadWriteTimeout = Timeout;
                return webRequest;
            }
        }
        public string GetRequest(string adresWww)
        {
            using (var webRequest = new WebClient())
            {
                webRequest.Timeout = 6000 * 60 * 1000;
                return webRequest.DownloadString(adresWww);
            }
        }
    }
}
