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
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Contact> contactRepository;
        public Window addCustomerWindow;
        public Window addContactWindow;

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
        public RelayCommand ShowContactCommand { get; set; }
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand DeleteCustomerCommand { get; set; }
        public RelayCommand SaveUpdatesCommand { get; set; }
        //constructor
        public KlantBeheerViewModel(GenericRepository<Customer> customerRepository, GenericRepository<Contact> contactRepository)
        {
            this.customerRepository = customerRepository;
            this.contactRepository = contactRepository;
            GetAllCustomers();

            //commands
            NewCustomerCommand = new RelayCommand(NewCustomer);
            GoBackCommand = new RelayCommand(GoBackView);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
            ShowContactCommand = new RelayCommand(ShowContactView);
            SaveUpdatesCommand = new RelayCommand(SaveUpdates);
        }

        //functions
        private void GetAllCustomers()
        {
            AllCustomers = new ObservableCollection<Customer>(customerRepository.Get());
        }
        public void UpdateCustomer()
        {
            AllCustomers = null;
            GetAllCustomers();
            base.RaisePropertyChanged("AllCustomers");
        }

        //command functions
        private void ShowContactView()
        {
            addContactWindow = new AddContactWindow();
            addContactWindow.Show();
        }
        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }
        public void DeleteCustomer()
        {
            Contact SelectedContact = null;
            List<Contact> c = new List<Contact>(contactRepository.Get());
            foreach(Contact item in c)
            {
                if(item.customer_id == SelectedCustomer.id)
                {
                    SelectedContact = item;
                }
            }
            if (SelectedContact != null)
            {
                contactRepository.Delete(SelectedContact);
            }            
            customerRepository.Delete(selectedCustomer);
            AllCustomers.Remove(selectedCustomer);
        }
        private void NewCustomer()
        {
            addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }
        private void SaveUpdates()
        {
            customerRepository.Update(selectedCustomer);
        }
    }
}
