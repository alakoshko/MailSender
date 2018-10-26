using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Security;
using SpamLib;

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
            (_SmtpServer) = (smtpServer);
            
        }

        //public void SendMail(string Mail, string Name)
        public void SendMail(MailAddress emailFrom, List<MailAddress> emailTo, string emailSubject, string emailText)
        {
            //EmailFrom = emailFrom;
            //EmailTo = emailTo;
            //EmailSubject = emailSubject;
            //EmailText = emailText;

            
            foreach (var vMailTo in EmailTo)
                try
                {
                    using (var email = new MailMessage(EmailFrom, vMailTo) {
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
