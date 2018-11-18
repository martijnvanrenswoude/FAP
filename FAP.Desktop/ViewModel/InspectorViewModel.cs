using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    class InspectorViewModel : ViewModelBase

    {
        private Inspector inspector;

        private GenericRepository<Inspector> genericRepository;

        public string Name
        {
            get { return inspector.name; }
            set { inspector.name = value; }
        }

        public string Surname
        {
            get { return inspector.name; }
            set { inspector.name = value; }
        }

        public string Postcode
        {
            get { return inspector.postcode; }
            set { inspector.postcode = value; }
        }

        public int TelephoneNumber
        {
            set { inspector.telephone_nr = value; }
        }

        public InspectorViewModel()
        {
            genericRepository = new GenericRepository<Inspector>(new FAPDatabaseEntities);
            inspector = new Inspector();
        }

        public void AddInspector()
        {
            genericRepository.Insert(inspector);
        }
    }
}
