using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailSender;
using SpamLib.Data;

namespace SpamLib
{
    public interface IDataAccessService
    {
        Task<ObservableCollection<ScheduledTask>> GetScheduledTasks();

        #region Получатели
        Task<ObservableCollection<Recipient>> GetRecipientsAsync();
        Task<bool> RemoveRecipientAsync(Recipient recipient);
        Task<bool> CreateRecipientsAsync(Recipient Recipients);
        Task<bool> UpdateRecipientsAsync(Recipient Recipients);
        bool UpdateRecipients(Recipient recipient);
        #endregion

        #region Письма
        Task<ObservableCollection<Email>> GetEmailsAsync();
        Task<bool> AddNewEmailAsync(Email email);
        Task<bool> RemoveEmailAsync(Email email);
        Task<bool> UpdateEmailsAsync(Email email);
        #endregion

        //ObservableCollection<Server> GetServers();
        Task<ObservableCollection<Server>> GetServersAsync();
        //ObservableCollection<Sender> GetSenders();
        Task<ObservableCollection<Sender>> GetSendersAsync();
        
        
    }

    public class DataAccessServiceFromDB : IDataAccessService
    {
        #region Получатели
        public ObservableCollection<Recipient> GetRecipients()
        {
            using (var db = new SpamDB())
                return new ObservableCollection<Recipient>(db.Recipients.ToArray());
        }

        public async Task<ObservableCollection<Recipient>> GetRecipientsAsync()
        {
            using (var db = new SpamDB())
                return new ObservableCollection<Recipient>(await db.Recipients.ToArrayAsync().ConfigureAwait(false));
        }

        public Guid CreateNewRecipientsDB(Recipient recipient)
        {
            using (var db = new SpamDB())
            {
                db.Recipients.Add(recipient);
                if (db.SaveChanges() > 0)
                    return recipient.Id;
            }
            return new Guid();
        }

        public async Task<bool> CreateRecipientsAsync(Recipient recipient)
        {
            //using (var db = new SpamDB())
            //{
            //    db.Recipients.Add(recipient);
            //    if (await db.SaveChangesAsync().ConfigureAwait(false) > 0)
            //        return recipient.Id;
            //}
            //return new Guid();

            using (var db = new SpamDB())
            {
                db.Recipients.Add(recipient);
                return await db.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> RemoveRecipientAsync(Recipient recipient)
        {
            using (var db = new SpamDB())
            {
                db.Recipients.Attach(recipient);

                db.Recipients.Remove(recipient);
                return await db.SaveChangesAsync() > 0;
            }
        }
        
        public async Task<bool> UpdateRecipientsAsync(Recipient recipient)
        {
            using (var db = new SpamDB())
            {
                Debug.WriteLine($"Вызван асинхронный метод сохранения Recipients");
                db.Recipients.Attach(recipient);
                db.Entry(recipient).State = EntityState.Modified;
                return await db.SaveChangesAsync() > 0;
            }
        }

        public bool UpdateRecipients(Recipient recipient)
        {
            using (var db = new SpamDB())
            {
                Debug.WriteLine($"Вызван метод сохранения Recipients");
                db.Recipients.Attach(recipient);

                db.Entry(recipient).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        #endregion

        public async Task<ObservableCollection<ScheduledTask>> GetScheduledTasks()
        {
            using (var db = new SpamDB())
            {
                return new ObservableCollection<ScheduledTask>(await db.ScheduledTasks
                    .Include(task => task.Emails)
                    .Include(task => task.MailingLists)
                    .Include(task => task.MailingLists.Recipients)
                    .Include(task => task.Senders)
                    .Include(task => task.Servers)
                    .ToArrayAsync()
                    .ConfigureAwait(false)
                    );
            }
        }

        public async Task<ObservableCollection<Email>> GetEmailsAsync()
        {
            using (var db = new SpamDB())
                return new ObservableCollection<Email>(await db.Emails
                    .Include(email => email.ScheduledTasks)
                    .ToArrayAsync());
        }

        public async Task<ObservableCollection<Server>> GetServersAsync()
        {
            using (var db = new SpamDB())
                return new ObservableCollection<Server>(await db.Servers.ToArrayAsync());
        }

        public async Task<ObservableCollection<Sender>> GetSendersAsync()
        {
            using (var db = new SpamDB())
                return new ObservableCollection<Sender>(await db.Senders.ToArrayAsync());
        }

        #region Письма
        public async Task<bool> AddNewEmailAsync(Email email)
        {
            using (var db = new SpamDB())
            {
                db.Emails.Add(email);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> RemoveEmailAsync(Email email)
        {
            using (var db = new SpamDB())
            {
                db.Emails.Attach(email);
                
                db.Emails.Remove(email);
                return await db.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateEmailsAsync(Email email)
        {
            using (var db = new SpamDB())
            {
                Debug.WriteLine($"Вызван асинхронный метод сохранения Emails");
                db.Emails.Attach(email);
                db.Entry(email).State = EntityState.Modified;
                return await db.SaveChangesAsync() > 0;
            }
        }
        #endregion
    }
}
