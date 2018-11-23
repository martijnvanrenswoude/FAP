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
        //commands
        public RelayCommand GoToSettingsViewCommand { get; set; }
        public RelayCommand GoToRapportagesViewCommand { get; set; }
        public RelayCommand GoToDataBeheerViewCommand { get; set; }

        //constructor
        public HomeViewModel(GenericRepository<Customer> repository)
        {
            GoToSettingsViewCommand = new RelayCommand(GoToSettingsView);
            GoToRapportagesViewCommand = new RelayCommand(GoToRapportagesView);
            GoToDataBeheerViewCommand = new RelayCommand(GoToDataBeheerView);
  

        }

        //command functions
        private void GoToSettingsView()
        {
            ViewNavigator.Navigate(nameof(SettingsView));
        }
        private void GoToRapportagesView()
        {
            ViewNavigator.Navigate(nameof(RapportagesView));
        }
        private void GoToDataBeheerView()
        {
            ViewNavigator.Navigate(nameof(DataBeheerView));
        }
    }
}
