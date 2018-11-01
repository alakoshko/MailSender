using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace MailServiceLib
{
    public class SmtpServers
    {
        public static readonly ObservableCollection<SmtpServer> Servers =
            new ObservableCollection<SmtpServer>(
                new[]
                {
                    new SmtpServer{ ServerName = "smtp.yandex.ru", ServerPort = 25, Login = "a.lakoshko" },
                    new SmtpServer{ ServerName = "smtp.gmail.com", ServerPort = 25, Login = "alakoshko" },
                    new SmtpServer{ ServerName = "smtp.nic.ru", ServerPort = 25 }
                });
    }

    public class SmtpServer
    {
        public string ServerName { get; set; }
        public int ServerPort { get; set; }

        public SecureString Password;
        public string Login;

        public override string ToString() => $"{ServerName}:{ServerPort}";

    }


}
