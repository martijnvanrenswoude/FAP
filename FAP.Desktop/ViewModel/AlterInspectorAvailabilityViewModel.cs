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
    class AlterInspectorAvailabilityViewModel : ViewModelBase
    {
        //Variables
        private Inspector_shedule InspectorShedule;
        GenericRepository<Inspector_shedule> repository;
        //Properties
        public Inspector Inspector { get; set; }
        public ICommand UpdateAvailabilityCommand { get; set; }
        public DateTime AvailableDay { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        // Constructor
        public AlterInspectorAvailabilityViewModel()
        {
            repository = new GenericRepository<Inspector_shedule>(new FAPDatabaseEntities());
            InspectorShedule = new Inspector_shedule();
            UpdateAvailabilityCommand = new RelayCommand(UpdateAvailability);
        }

        //Methods
        public void UpdateAvailability()
        {
            InspectorShedule.inspector_id = Inspector.Id;
            InspectorShedule.date = AvailableDay;
            InspectorShedule.available_from = AvailableFrom;
            InspectorShedule.available_until = AvailableTo;
            repository.Insert(InspectorShedule);
        }

    }
}
