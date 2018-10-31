using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public interface IDataAccessService
    {
        ObservableCollection<EmployesDB> GetEmployes();
        Guid CreateNewEmployesDB(EmployesDB employesDB);
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
            employesDataContext.EmployesDB.InsertOnSubmit(employesDB);
            employesDataContext.SubmitChanges();
            return employesDB.ID;
        }
    }
}
