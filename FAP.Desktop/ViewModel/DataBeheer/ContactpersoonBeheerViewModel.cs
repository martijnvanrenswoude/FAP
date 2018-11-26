using FAP.Desktop.Navigation;
using FAP.Domain;
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
    public class ContactpersoonBeheerViewModel : ViewModelBase
    {
        //vars
        private Customer selectedCustomer;
        private Contact contact;
        //properties
        public Contact Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                base.RaisePropertyChanged();
            }
        }
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                SetContact();
                base.RaisePropertyChanged();
            }
        }
        public ObservableCollection<Customer> AllCustomers { get; set; }
        //commands
        public RelayCommand GoBackCommand { get; set; }
          
        //constructor
        public ContactpersoonBeheerViewModel()
        {
            GetAllCustomers();
            GoBackCommand = new RelayCommand(GoBackView);
        }
        //functions
        private void GetAllCustomers()
        {
            using (var context = new FAPDatabaseEntities())
            {
                AllCustomers = new ObservableCollection<Customer>(context.Customer.ToList());
            }
        }
        private void SetContact()
        {
            using (var context = new FAPDatabaseEntities())
            {
                List<Contact> tempList = new List<Contact>(context.Contact.ToList());
                foreach(Contact c in tempList)
                {
                    if(c.customer_id == selectedCustomer.id)
                    {
                        Contact= c;
                        return;
                    }
                }
                Contact = null;
            }
        }
        //command functions
        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }


    }
}
