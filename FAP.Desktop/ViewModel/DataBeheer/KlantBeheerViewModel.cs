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
using System.Windows;

namespace FAP.Desktop.ViewModel
{
    public class KlantBeheerViewModel : ViewModelBase
    {
        //vars
        private Customer selectedCustomer;
        private GenericRepository<Customer> repository;
        public Window addCustomerWindow;
        public Window addContact;

        //properties
        public Customer SelectedCustomer

        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                repository.Update(selectedCustomer);
                base.RaisePropertyChanged();
            }
        }
        public ObservableCollection<Customer> AllCustomers { get; set; }

        //Commands
        public RelayCommand NewCustomerCommand { get; set; }
        public RelayCommand ShowContactCommand { get; set; }
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand DeleteCustomerCommand { get; set; }
        
        //constructor
        public KlantBeheerViewModel(GenericRepository<Customer> repository)
        {
            this.repository = repository;
            GetAllCustomers();
            
            //commands
            NewCustomerCommand =        new RelayCommand(NewCustomer);
            GoBackCommand =             new RelayCommand(GoBackView);
            DeleteCustomerCommand =     new RelayCommand(DeleteCustomer);
            ShowContactCommand =        new RelayCommand(ShowContactView);
        }

        //functions
        private void GetAllCustomers()
        {
            AllCustomers = new ObservableCollection<Customer>(repository.Get());
        }
        
        public void UpdateCustomer()
        {
            GetAllCustomers();
            base.RaisePropertyChanged("AllCustomers");           
        }
        //command functions
        private void ShowContactView()
        {
   
        }
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
        private void NewCustomer()
        {
            addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }
    }
}
