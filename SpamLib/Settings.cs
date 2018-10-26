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
        public static int smtpPort = 25;

        public static string smtpErrorTittle = "Error!";

        public static string mailSentOk = "Почта отправлена успешно";
        public static string mailSentError = "Результат отправки почты";
        public static string mailBodyEmpty = "Письмо не заполнено (Пустое тело сообщения)";
        public static string mailNullMailTo = "Не выбран(ы) получатель(и)";
        public static string mailTitleError = "Ошибка параметров";

        public static string smtpServerNullLogin = "Не указан логин smtp сервера";
        public static string smtpServerNullPassword = "Укажите пароль smtp сервера";

    }

}
