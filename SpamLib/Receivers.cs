using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public class MailReceivers
    {
        public ObservableCollection<Receiver> Receivers = new ObservableCollection<Receiver>(
            new[] {
                new Receiver{ Name="Ivanov", Email="i@m.ru"},
                new Receiver{ Name="Petrov", Email="p@m.ru"},
                new Receiver{ Name="Васечкин", Email="v@m.ru"},
                });
    }

    public class Receiver /*: Sender*/
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    
}
