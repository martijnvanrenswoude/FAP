using FAP.Desktop.Message;
using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Customer;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class TestOtherViewModel : ViewModelBase
    {
        // Hier gebruiken we een custom repository ipv generic!
        // Dit kan omdat wij de implicit cast overriden.
        private CustomerRepository _repository;

        public RelayCommand GoToViewCommand { get; set; }

        public TestOtherViewModel(GenericRepository<Employee> repository)
        {
            _repository = repository;
            _repository.SpecialCustomerRelatedAction();

            GoToViewCommand = new RelayCommand(GoToOtherView);
        }
        
        private void GoToOtherView()
        {
            ViewNavigator.Navigate(nameof(TestView));
        }
    }
}
