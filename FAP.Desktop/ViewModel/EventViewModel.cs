using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FAP.Desktop.ViewModel
{
    public class EventViewModel : ViewModelBase, INotifyPropertyChanged
    {
        //Variables
        private Event _event; //Not according to coding guidelines, but event is a keyword in visualstudio
        private GenericRepository<Event> repository;
        private GenericRepository<Contact> contactRepository;
        private GenericRepository<Customer> customerRepository;

        //Properties
        public string Name { get; set; }
        public int ContactID { get; set; }
        public DateTime Date { get; set; }
        public int AmountOfVisitors { get; set; }
        public int SurfaceAreaM2 { get; set; }
        public string Description { get; set; }

        public Event SelectedEvent{ get; set; }
        public List<Event> Events { get; set; }
        public List<Contact> AllContacts { get; set; }
        public Contact SelectedContact { get; set; }
        public List<Customer> AllCustomers { get; set; }
        public Customer SelectedCustomer { get {return  SelectedCustomer; } set { RaisePropertyChanged("AllContacts"); } }

        //Command properties
        ICommand UpdateEventCommand { get; set; }
        ICommand AddEventCommand { get; set; }
        ICommand DeleteEventCommand { get; set; }
        //Constructor
        public EventViewModel()
        {
            _event = new Event();
            contactRepository = new GenericRepository<Contact>(new FAPDatabaseEntities());
            customerRepository = new GenericRepository<Customer>(new FAPDatabaseEntities());
            repository = new GenericRepository<Event>(new FAPDatabaseEntities());

            UpdateEventCommand = new RelayCommand(UpdateEvent);
            AddEventCommand = new RelayCommand(InsertEvent);
            DeleteEventCommand = new RelayCommand(RemoveEvent);


        }
        //Methods

        private void GetAllContacts()
        {
            contactRepository.Get(c => c.customer_id == SelectedCustomer.id);
        }

        public void RemoveEvent()
        {
            repository.Delete(SelectedEvent);
        }

        public void UpdateEvent()
        {
            repository.Update(SelectedEvent);
        }
        
        public void InsertEvent()
        {
            repository.Insert(_event);
        }

        public void GetAllCustomer()
        {
            customerRepository.Get();
        }
    }
}
