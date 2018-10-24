using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Security;

namespace MailSender
{
    public class EmailSendService
    {
        public MailAddress EmailFrom;
        public List<MailAddress> EmailTo;
        public string EmailSubject;
        public string EmailText;


        public EmailSendService(MailAddress emailFrom, List<MailAddress> emailTo, string emailSubject, string emailText)
        {
            EmailFrom = emailFrom;
            EmailTo = emailTo;
            EmailSubject = emailSubject;
            EmailText = emailText;
        }

        public int Send(string username, SecureString userpass)
        {
            foreach (var vMailTo in EmailTo)
                try
                {
                    using (var email = new MailMessage(EmailFrom, vMailTo))
                    {
                        email.Subject = EmailSubject;
                        email.Body = EmailText;

                        using (var client = new SmtpClient(GlobalSettings.smtpHost))
                        {
                            var user = username;
                            var password = userpass;
                            client.Credentials = new NetworkCredential(user, password);
                            client.EnableSsl = true;

                            client.Send(email);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, GlobalSettings.smtpErrorTittle, MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return -1;
                }
            return 0;
        }
    }
}
