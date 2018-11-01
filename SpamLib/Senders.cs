using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public class MailSenders
    {
        public static readonly ObservableCollection<Sender> Senders =
            new ObservableCollection<Sender>(
                new[] {
                    new Sender{ Name="Ivanov", Email="p@yandex.ru"},
                    new Sender{ Name="Petrov", Email="a@yandex.ru"},
                    new Sender{ Name="Васечкин", Email="s@yandex.ru"},
                    });

    }

    public class Sender
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString() => $"{Name} : {Email}";
    }

    
}
