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
        private int customerID;
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
        //commands
        public RelayCommand GoBackCommand { get; set; }
        
        //constructor
        public ContactpersoonBeheerViewModel()
        {
            customerID = 1;
            getContact();            
            GoBackCommand = new RelayCommand(GoBackView);

        }
        //functions
        private void getContact()
        {
            using (var context = new FAPDatabaseEntities())
            {
                List<Contact> tempList = context.Contact.ToList();
                foreach(Contact c in tempList)
                {
                    if(c.customer_id == customerID)
                    {
                        Contact = c;
                    }
                }
            }
        }
        //command functions
        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }


    }
}
