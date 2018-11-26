using FAP.Domain;
using FAP.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Repository.Explicit
{
    public class InspectorRepository : GenericRepository<Domain.Inspector>
    {
        public InspectorRepository(FAPDatabaseEntities context) : base(context)
        {

        }


        //public static implicit operator InspectorRepository(GenericRepository<Inspector> i)
        //{
        //    return new InspectorRepository(i.Context);
        //}

        public List<Inspector> SearchInspector(string searchkey)
        {
            List<Inspector> list = Context.Inspectors.Where(i => i.name == searchkey || i.surname == searchkey).ToList();
            return list;
        }
    }

}

