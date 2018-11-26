using FAP.Domain;
using FAP.Repository.Explicit;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FAP.Desktop.ViewModel
{
    public class InspectorViewModel : ViewModelBase

    {
        /*
         * variables 
         */

        private List<Inspector> _inspectors;

        private Inspector inspector;

        private Inspector selectedInspector;

        private GenericRepository<Inspector> repository;


        /*
         * Properties
         */

        public ICommand AddInspectorCommand { get; set; }
        public ICommand DeleteInspectorCommand { get; set; }
        public ICommand AlterInspectorCommand { get; set; }
        public ICommand SearchInspectorCommand { get; set; }
        public Inspector SelectedInspector { get; set; }
        public List<Inspector> SelectedInspectors { get; set; }

        public string SearchKey { get; set; }

        public string Name
        {
            get { return inspector.name; }
            set { inspector.name = value; }
        }

        public string Surname
        {
            get { return inspector.surname; }
            set { inspector.surname = value; }
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
    
        public DateTime DateOfBirth { 
            set {inspector.date_of_birth = value; }
        }
        public string Housenumber
        {
            set { inspector.house_number = value; }
        }
        public List<Inspector> Inspectors { get { return this._inspectors; }}
        /*
         * Constructor
         */ 

        public InspectorViewModel()
        {
            repository = new GenericRepository<Inspector>(new FAPDatabaseEntities());


            //Alle mogelijke inspectors instantieren
            inspector = new Inspector();
            GetAllInspectors();
            //Commands voor het binden
            AddInspectorCommand = new RelayCommand(AddInspector);
            DeleteInspectorCommand = new RelayCommand(DeleteInspector);
            AlterInspectorCommand = new RelayCommand(AlterInspector);
          //  SearchInspectorCommand = new RelayCommand(SearchInspector);
        }

        /*
         * Functions
         */ 

        private void AddInspector()
        {
            repository.Insert(inspector);
        }

        private void DeleteInspector()
        {
            repository.Delete(SelectedInspector);
        }

        private void AlterInspector()
        {
            repository.Update(SelectedInspector);
        }

        private void GetAllInspectors()
        {
            using(var context = new FAPDatabaseEntities())
            {
               _inspectors = context.Inspectors.ToList();
            }     
        }
        
        //////public void SearchInspector()
        //////{
        //////    SelectedInspectors = repository.SearchInspector(SearchKey);
        //////}
    }
}
