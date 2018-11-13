using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAP.Repository.Base;

namespace FAP.Repository.Customer
{
    public class CustomerRepository : IEntityRepository<string, int> // : IEntityRepository<Customer, int>
    {
        //public FAPEntities Context { get; }
        //
        //public CustomerRepository()
        //{
        //    Context = new FAPEntities();
        //}

        public DbResult<string> Create(string e)
        {
            throw new NotImplementedException();
        }

        public DbResult<string> Update(string e)
        {
            throw new NotImplementedException();
        }

        public DbResult<string> Delete(string e)
        {
            throw new NotImplementedException();
        }

        public DbResult<string> ReadById(int k)
        {
            throw new NotImplementedException();
        }

        public DbResult<IEnumerable<string>> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
