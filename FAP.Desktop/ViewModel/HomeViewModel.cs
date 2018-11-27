using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class HomeViewModel
    {
        GenericRepository<Customer> _repository;
        public RelayCommand GoToSettingsViewCommand { get; set; }

        public HomeViewModel(GenericRepository<Customer> repository)
        {
            //GoToSettingsViewCommand = new RelayCommand(GoToSettingsView);
            //_repository = repository;
            //var kaas = _repository.Get().FirstOrDefault();
            //Console.WriteLine("kaas.name");
            //Console.WriteLine(kaas.name);
        }

        private void GoToSettingsView()
        {
            ViewNavigator.Navigate(nameof(SettingsView));
        }
    }
}
