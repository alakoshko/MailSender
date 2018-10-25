using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class GlobalSettings
    {
        public static string smtpHost = "smtp.yandex.ru";
        public static string smtpPort = "25";

        public static string smtpErrorTittle = "Error!";

        public static string mailSentOk = "Почта отправлена успешно";
        public static string mailSentError = "Результат отправки почты";
    }
    
}
