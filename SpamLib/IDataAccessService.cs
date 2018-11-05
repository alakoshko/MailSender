using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender;

namespace SpamLib
{
    public interface IDataAccessService
    {
        ObservableCollection<EmployesDB> GetEmployes();
        Guid CreateNewEmployesDB(EmployesDB employesDB);
        void UpdateEmployesDB(EmployesDB employesDB);
    }

    public class DataAccessServiceFromDB : IDataAccessService
    {
        private EmployesDataContext employesDataContext;


        public DataAccessServiceFromDB()
        {
            employesDataContext = new EmployesDataContext();
        }

        public ObservableCollection<EmployesDB> GetEmployes()
        {
            return new ObservableCollection<EmployesDB>(employesDataContext.EmployesDB.ToArray());
        }

        public Guid CreateNewEmployesDB(EmployesDB employesDB)
        {
            if(employesDB.ID == null)
                employesDataContext.EmployesDB.InsertOnSubmit(employesDB);
            employesDataContext.SubmitChanges();
            return employesDB.ID;
        }

        public void UpdateEmployesDB(EmployesDB employesDB)
        {
            try
            {
                employesDataContext.SubmitChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
