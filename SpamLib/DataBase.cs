using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public class DataBase
    {
        private readonly EmployesDataContext employesDataContext = new EmployesDataContext();

        public IQueryable<EmployesDB> Employes => employesDataContext.EmployesDB;
    }
}
