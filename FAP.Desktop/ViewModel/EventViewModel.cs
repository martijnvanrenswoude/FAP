using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAP.Domain;
using FAP.Repository.Generic;

namespace FAP.Desktop.ViewModel
{
    public class EventViewModel
    {
        //Variables
        private Event _event; //Not according to coding guidelines, but event is a keyword in visualstudio
        private GenericRepository<Event> repository;
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

        //Constructor
        public EventViewModel()
        {
            _event = new Event();
            repository = new GenericRepository<Event>(new FAPDatabaseEntities());

        }
        //Methods

        private void GetAllContacts()
        {
            
        }

        public void RemoveEvent()
        {

        }

        public void UpdateEvent()
        {

        }
        
        public void InsertEvent()
        {

        }
    }
}
