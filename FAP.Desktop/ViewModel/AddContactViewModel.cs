using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FAP.Desktop.ViewModel
{
    public class AddContactViewModel : ViewModelBase
    {
        //vars
        private Contact contact;
        private String name;
        private String surname;
        private int telephone;
        private String email;
          
        private GenericRepository<Contact> repository;
        private KlantBeheerViewModel klantModel;

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
        public String Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                base.RaisePropertyChanged();
            }
        }
        public int Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
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
        public RelayCommand SaveContactCommand { get; set; }
        //constructor
        public AddContactViewModel(GenericRepository<Contact> repository, KlantBeheerViewModel klantModel)
        {
            this.repository = repository;
            this.klantModel= klantModel;
            SetData();
            //commands
            CancelCommand = new RelayCommand(Cancel);
            SaveContactCommand = new RelayCommand(SaveContact);
        }

        //finctions
        private void SetData()
        {
            List<Contact> tempList = new List<Contact>(repository.Get());
            foreach (Contact c in tempList)
            {
                if (c.customer_id == klantModel.SelectedCustomer.id)
                {
                    name = c.name;
                    surname = c.surname;
                    telephone = (int) c.telephone_nr;
                    email = c.email;
                    contact = c;
                    return;
                }
            }
            contact = null;
        }
        //command functions
        public void Cancel()
        {
            klantModel.addContactWindow.Close();
        }

        public void SaveContact()
        {
            if (contact == null)
            {
                Contact c = new Contact();
                c.email = email;
                c.name = name;
                c.surname = surname;
                c.telephone_nr = telephone;
                c.customer_id = klantModel.SelectedCustomer.id;
                repository.Insert(c);
            }
            else
            {
                contact.email = email;
                contact.name = name;
                contact.surname = surname;
                contact.telephone_nr = telephone;
                repository.Update(contact);
            }
            klantModel.addContactWindow.Close();
        }
    }
}

