using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Security;
using SpamLib;
using System.Windows.Documents;
using System.Linq;

namespace MailSender
{
    public class MailService
    {
        public MailAddress EmailFrom;
        public List<MailAddress> EmailTo;
        public string EmailSubject;
        public string EmailBody;
        private SmtpServer _SmtpServer;

        public MailService(SmtpServer smtpServer)
        {
            _SmtpServer = smtpServer;
        }

        //не добавляю EMployesDB т.к. должен быть только список выбранных из DataGrid, пока не реализовано.
        //SendMails добавлено по методичке
        //public void SendMails(IQueryable<EmployesDB> employesDBs, MailAddress emailFrom, List<MailAddress> emailTo, string emailSubject, string emailText)
        public void SendMails(MailAddress emailFrom, MailAddressCollection emailTo, string emailSubject, string emailText)
        {
            (EmailSubject, EmailBody) = (emailSubject, emailText);

            foreach (var vMailTo in emailTo)
                SendMail(emailFrom, vMailTo, emailSubject, emailText);
        }
        
        private void SendMail(MailAddress emailFrom, MailAddress emailTo, string emailSubject, string emailText)
        {
            try
            {
                using (var email = new MailMessage(emailFrom, emailTo) {
                    Subject = EmailSubject,
                    Body = EmailBody,
                    IsBodyHtml = false
                })
                {
                    if (EmailBody == "" || EmailBody == null)
                    {
                        Trace.WriteLine(GlobalSettings.mailBodyEmpty);
                        throw new InvalidOperationException(GlobalSettings.mailTitleError, new Exception(GlobalSettings.mailBodyEmpty));
                    }

                    using (var client = new SmtpClient(_SmtpServer.ServerName, _SmtpServer.ServerPort) {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(_SmtpServer.Login, _SmtpServer.Password)
                    })
                    {
                        client.Send(email);
                    }
                }
            }
            catch (Exception error)
            {
                Trace.WriteLine(error.ToString());
                throw new InvalidOperationException(GlobalSettings.smtpErrorTittle, error);
            }
        }
    }
}
