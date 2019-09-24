using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;

namespace AutoLaudCron
{
    class sendMessegeEmail
    {
        public void startSendMessegeEmail(string massegeTitle, string messegeError)
        {
            MailAddress from = new MailAddress("jenea01@yandex.ru", "CronStatus!");
            MailAddress to = new MailAddress("multibrend01@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = massegeTitle;
            m.Body = messegeError;
            m.SubjectEncoding = Encoding.UTF8;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("jenea01@yandex.ru", "jenea01scura");
            smtp.EnableSsl = true;
            try
            {
            smtp.Send(m);
            }
            catch
            {
                Console.WriteLine("Сообщение не отправлено,\nпроверьте правильность заполнения полей", "Ошибка отправки");
            }
        }
    }
}

