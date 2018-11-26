using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class KlantBeheerViewModel : ViewModelBase
    {
        //vars
        private Customer selectedCustomer;
        private GenericRepository<Customer> repository;
        
        //properties
        public Customer SelectedCustomer

        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                base.RaisePropertyChanged();
            }
        }
        public ObservableCollection<Customer> AllCustomers { get; set; }

        //Commands
        public RelayCommand NewCustomerCommand { get; set; }
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand DeleteCustomerCommand { get; set; }
      
        //constructor
        public KlantBeheerViewModel()
        {
            GetAllCustomers();
            repository = new GenericRepository<Customer>(new FAPDatabaseEntities());
            //commands
            NewCustomerCommand = new RelayCommand(NewCustomer);
            GoBackCommand =             new RelayCommand(GoBackView);
            DeleteCustomerCommand =     new RelayCommand(DeleteCustomer);
            
        }

        //functions
        private void GetAllCustomers()
        {
            using (var context = new FAPDatabaseEntities())
            {
                AllCustomers = new ObservableCollection<Customer>(context.Customer.ToList());
            }
        }
        
        //command functions
        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }
        private void GoToContactpersoonBeheerView()
        {
            ViewNavigator.Navigate(nameof(ContactpersoonBeheerView));
        }
        private void DeleteCustomer()
        {
            repository.Delete(SelectedCustomer);
            AllCustomers.Remove(SelectedCustomer);
        }
        
        private void NewCustomer() { }
    }
}
