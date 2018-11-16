using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.Migrations;

namespace SpamLib.Data
{
    public partial class SpamDB
    {
        //static SpamDB() => Database.SetInitializer(new SpamDBInitializer());
        //static SpamDB() => Database.SetInitializer<SpamDB>(new CreateDatabaseIfNotExists<SpamDBInitializer>());
    }


    public class SpamDBInitializer : DropCreateDatabaseAlways<SpamDB>
    {
        protected override void Seed(SpamDB context) {

            base.Seed(context);

            if (!context.Emails.Any())
            {
                context.Emails.AddOrUpdate(
                    new Email { Title="Письмо 1", Body="Текст 1" },
                    new Email { Title = "Письмо 2", Body = "Текст 2" },
                    new Email { Title = "Письмо 3", Body = "Текст 3" },
                    new Email { Title = "Письмо 4", Body = "Текст 4" }
                    );
                context.SaveChanges();
            }

            if (!context.Recipients.Any())
            {
                context.Recipients.AddOrUpdate(
                    new Recipient { Name = "Иванов", Email = "ivanov@mail.ru" },
                    new Recipient { Name = "Петров", Email = "petrov@mail.ru" },
                    new Recipient { Name = "Васечкин", Email = "vasechkin@mail.ru" },
                    new Recipient { Name = "Сидоров", Email = "sidorov@mail.ru" }
                    );
                context.SaveChanges();
            }


            if (!context.Senders.Any())
            {
                context.Senders.AddOrUpdate(
                    new Sender { Name = "Отправитель1", Email = "sender1@mail.ru", Login = "sender1", Password = "pass1" },
                    new Sender { Name = "Отправитель2", Email = "sender2@mail.ru", Login = "sender2", Password = "pass2" },
                    new Sender { Name = "Отправитель3", Email = "sender3@mail.ru", Login = "sender3", Password = "pass3" },
                    new Sender { Name = "Отправитель4", Email = "sender4@mail.ru", Login = "sender4", Password = "pass4" }
                    );
                context.SaveChanges();
            }

            if (!context.Servers.Any())
            {
                context.Servers.AddOrUpdate(
                    new Server { Name = "Yandex", Address="smtp.yandex.ru", Port=25, UseSSL=true, Login="a.lakoshko" },
                    new Server { Name = "Mail", Address = "smtp.mail.ru", Port = 25, UseSSL = true, Login = "al@tmone.ru" },
                    new Server { Name = "Gmail", Address = "smtp.gmail.ru", Port = 25, UseSSL = true, Login = "alakoshko" }
                    );
                context.SaveChanges();
            }

            if (!context.MailingLists.Any())
            {
                context.MailingLists.AddOrUpdate(
                    new MailingList { Name = "List 1", Recipients = context.Recipients.ToArray() }
                    );
                context.SaveChanges();
            }

            if (!context.ScheduledTasks.Any())
            {
                context.ScheduledTasks.AddOrUpdate(
                    new ScheduledTask {
                        Name = "Первая задача",
                        Emails = context.Emails.OrderBy(e => e.Id).Take(3).ToArray(),
                        Time = DateTime.Now.Subtract(TimeSpan.FromMinutes(30)),
                        Senders = context.Senders.First(),
                        Servers = context.Servers.First()
                    },
                    new ScheduledTask
                    {
                        Name = "Вторая задача",
                        Emails = context.Emails.OrderBy(e => e.Id).Take(3).ToArray(),
                        Time = DateTime.Now.Add(TimeSpan.FromMinutes(30)),
                        Senders = context.Senders.First(),
                        Servers = context.Servers.First()
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
