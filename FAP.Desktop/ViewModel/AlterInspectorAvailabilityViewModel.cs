using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FAP.Desktop.ViewModel
{
    public class AlterInspectorAvailabilityViewModel : ViewModelBase
    {
        //Variables
        private Inspector_shedule InspectorShedule;
        GenericRepository<Inspector_shedule> repository;
        GenericRepository<Event> eventRepository;
        //Properties
        public Inspector Inspector { get; set; }
        public string Name { get; set; }
        public ICommand UpdateAvailabilityCommand { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public List<Event> UpcomingEvents { get; set; }
        public Event SelectedEvent { get; set; }

        // Constructor
        public AlterInspectorAvailabilityViewModel()
        {
            Inspector = GetInspector();
            Name = Inspector.name;
            repository = new GenericRepository<Inspector_shedule>(new FAPDatabaseEntities());
            eventRepository = new GenericRepository<Event>(new FAPDatabaseEntities());
            InspectorShedule = new Inspector_shedule();
            UpdateAvailabilityCommand = new RelayCommand(UpdateAvailability);
        }

        //Methods
        public void UpdateAvailability()
        {
            InspectorShedule.inspector_id = Inspector.Id;

            InspectorShedule.date = SelectedEvent.date;

            InspectorShedule.available_from = AvailableFrom;
            InspectorShedule.available_until = AvailableTo;
            repository.Insert(InspectorShedule);
        }

        public Inspector GetInspector()
        {
            //dit gaat nog weg
            using(var context = new FAPDatabaseEntities())
            {
                Inspector inspector = (Inspector)context.Inspectors.First(i => i.Id == 1005);
                return inspector;
            }
        }

        public void GetUpcomingEvents()
        {
            UpcomingEvents = eventRepository.Get().ToList();
        }
        
    }
}
