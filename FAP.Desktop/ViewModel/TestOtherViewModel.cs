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
    public class TestOtherViewModel : ViewModelBase, ITransitionable
    {
        // Hier gebruiken we een custom repository ipv generic!
        // Dit kan omdat wij de implicit cast overriden.
        private CustomerRepository _repository;

        public RelayCommand GoToViewCommand { get; set; }

        public TestOtherViewModel(GenericRepository<Employee> repository)
        {
            _repository = repository;

            // Voorbeeld aanroep van custom repository
            _repository.SpecialCustomerRelatedAction();

            GoToViewCommand = new RelayCommand(GoToOtherView);
        }
        
        private void GoToOtherView()
        {
            ViewNavigator.Navigate(nameof(TestView));
        }

        // Gebruik de show method van ITransitionable om dingen te refreshen wanneer je van een andere view komt.
        // MvvM bewaart alle ViewModels instances waardoor de ctor maar 1x uitgevoerd wordt.
        public void Show()
        {
            Console.WriteLine("This could be a refresh function :P");
        }

        // Zelfde als show maar dan tegenovergesteld.
        public void Hide()
        {
            Console.WriteLine("This could be a dispose function :P");
        }
    }
}
