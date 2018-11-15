using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;
using SpamLib.Data;

namespace SpamLib
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();
        Task<ObservableCollection<Recipient>> GetRecipientsAsync();

        //Guid CreateNewRecipients(Recipient Recipients);
        //void UpdateRecipients(Recipient Recipients);

        Task<ObservableCollection<ScheduledTask>> GetScheduledTasks();

        Task<Guid> CreateRecipientsAsync(Recipient Recipients);

        #region Письма
        Task<ObservableCollection<Email>> GetEmailsAsync();
        Task<bool> AddNewEmailAsync(Email email);
        Task<bool> RemoveEmailAsync(Email email);
        #endregion

        //ObservableCollection<Server> GetServers();
        Task<ObservableCollection<Server>> GetServersAsync();
        //ObservableCollection<Sender> GetSenders();
        Task<ObservableCollection<Sender>> GetSendersAsync();
    }

    public class DataAccessServiceFromDB : IDataAccessService
    {
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

        public async Task<Guid> CreateRecipientsAsync(Recipient recipient)
        {
            using (var db = new SpamDB())
            {
                db.Recipients.Add(recipient);
                if (await db.SaveChangesAsync().ConfigureAwait(false) > 0)
                    return recipient.Id;
            }
            return new Guid();
        }

        public void UpdateRecipientsDB(Recipient Recipients)
        {
            try
            {
                //RecipientsDataContext.SubmitChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

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
    }
}
