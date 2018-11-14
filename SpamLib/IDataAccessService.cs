using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //Task<ObservableCollection<Recipient>> GetRecipientsAsync();

        Guid CreateNewRecipientsDB(Recipient Recipients);
        void UpdateRecipientsDB(Recipient Recipients);
    }

    public class DataAccessServiceFromDB : IDataAccessService
    {
        public ObservableCollection<Recipient> GetRecipients()
        {
            using (var db = new SpamDB())
                return new ObservableCollection<Recipient>(db.Recipients.ToArray());
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
    }
}
