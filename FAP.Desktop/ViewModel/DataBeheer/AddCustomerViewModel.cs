using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class AddCustomerViewModel : ViewModelBase
    {
        //vars
        private String name;
        private int telephone_nr;
        private String postcode;
        private String housenumber;
        private String email;
        private KlantBeheerViewModel klantViewModel;
        private GenericRepository<Customer> repository;

        //properties
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                base.RaisePropertyChanged();
            }
        }
        public int Telephone_nr
        {
            get { return telephone_nr; }
            set
            {
                telephone_nr = value;
                base.RaisePropertyChanged();
            }
        }

        public String Postcode
        {
            get { return postcode; }
            set
            {
                postcode = value;
                base.RaisePropertyChanged();
            }
        }

        public String Housenumber
        {
            get { return housenumber; }
            set
            {
                housenumber = value;
                base.RaisePropertyChanged();
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                base.RaisePropertyChanged();
            }
        }

        //commands
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand AddCustomerCommand { get; set; }

        //constructor
        public AddCustomerViewModel(GenericRepository<Customer> repository, KlantBeheerViewModel klantViewModel)
        {
            this.repository = repository;
            this.klantViewModel = klantViewModel;
            //commands
            CancelCommand =         new RelayCommand(Cancel);
            AddCustomerCommand =    new RelayCommand(AddCustomer);
        }

        //command functions
        public void Cancel()
        {
            klantViewModel.addCustomerWindow.Close();
        }

        public void AddCustomer()
        {
            Customer c = new Customer();
            c.name = Name;
            c.telephone_nr = Telephone_nr;
            c.postcode = Postcode;
            c.house_number = Housenumber;
            c.email = Email;
            repository.Insert(c);
            klantViewModel.UpdateCustomer();
            klantViewModel.addCustomerWindow.Close();
        }
    }

}
