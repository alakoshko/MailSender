using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public class Senders
    {
        public static readonly ObservableCollection<Sender> _Senders =
            new ObservableCollection<Sender>(
                new[] { new Sender{ Name="Ivanov", Email="i@m.ru", Password=PasswordEncoder.Encode("p1")},
                    new Sender{ Name="Petrov", Email="p@m.ru", Password=PasswordEncoder.Encode("p2")},
                    new Sender{ Name="Васечкин", Email="v@m.ru", Password=PasswordEncoder.Encode("p3")},
                    });

    }

    public class Sender
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
