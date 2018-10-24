using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("a.lakoshko@yandex.ru");
            mail.To.Add("a.lakoshko@yande.ru");
            mail.Subject = "Hello world";
            mail.Body = "Привет";

            var client = new SmtpClient("smtp.yandex.ru", 58);
            client.Credentials = new NetworkCredential("user", "password");
            client.EnableSsl = true;

            //client.Send();



            Console.ReadLine();
        }
    }
}
