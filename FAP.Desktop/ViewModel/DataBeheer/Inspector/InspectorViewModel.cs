using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;

using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FAP.Desktop.ViewModel
{
    public class InspectorViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /*
         * variables 
         */

        private List<Inspector> _inspectors;

        private Inspector inspector;

        private AddInspector addInspectorWindow;

        private GenericRepository<Inspector> repository;


        /*
         * Properties
         */
        public Inspector SelectedInspector
        {
            set { inspector = value;
                base.RaisePropertyChanged();
                if (inspector != null)
                {
                    repository.Update(inspector);
                }
            }

        }
        public List<Inspector> SelectedInspectors { get; set; }
        public string SearchText { get; set; }

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
        public DateTime DateOfBirth
        {
            set { inspector.date_of_birth = value; }
        }
        public string Housenumber
        {
            set { inspector.house_number = value; }
        }

      // public List<Inspector> Inspectors { get { return this._inspectors; } }

        public ObservableCollection<Inspector> Inspectors { get; set; }
        /*
         * Commands
         */

        public RelayCommand CancelCommand { get; set; }
        public ICommand AddInspectorWindowCommand { get; set; }
        public ICommand AddInspectorCommand { get; set; }
        public ICommand DeleteInspectorCommand { get; set; }
        public ICommand AlterInspectorCommand { get; set; }
        public ICommand search { get; set; }
        public ICommand GoBackCommand { get; set; }
                
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
            CancelCommand = new RelayCommand(CancelAddInspector);
            AddInspectorWindowCommand = new RelayCommand(OpenAddInspectorWindow);
            AddInspectorCommand = new RelayCommand(AddInspector);
            DeleteInspectorCommand = new RelayCommand(DeleteInspector);
            AlterInspectorCommand = new RelayCommand(AlterInspector);
            search = new RelayCommand(SearchInspector);
            GoBackCommand = new RelayCommand(GoBackView);
        }

        /*
         * Functions
         */ 
        private void OpenAddInspectorWindow()
        {
            addInspectorWindow = new AddInspector();
            addInspectorWindow.Show();
        }
        private void AddInspector()
        {
            try
            {
                repository.Insert(inspector);
                Inspectors.Add(inspector);
                addInspectorWindow.Close();
            }
            catch (Exception e)
            {

            }
      
      
        }

        private void DeleteInspector()
        {
                repository.Delete(inspector);
            Inspectors.Remove(inspector);
            inspector = null;
                
        }

        private void AlterInspector()
        {
            repository.Update(inspector);
        }
        public void CancelAddInspector()
        {
            addInspectorWindow.Close();
        }
        private void GetAllInspectors()
        {
           Inspectors = new ObservableCollection<Inspector>(repository.Get());
        }
        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }
        public void SearchInspector()
        {
            if (SearchText != null && SearchText != "")
            {
                Inspectors = new ObservableCollection<Inspector>(repository.Get().Where(e => e.name.ToUpper().Contains(SearchText.ToUpper()) || e.surname.ToUpper().Contains(SearchText.ToUpper())));
            }
            else
            {
                Inspectors = new ObservableCollection<Inspector>(repository.Get());
            }
            RaisePropertyChanged("Inspectors");            
        }
    }
}
