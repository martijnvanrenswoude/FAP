using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class RapportagesViewModel
    {
        public RelayCommand GoToHomeViewCommand { get; set; }

        public RapportagesViewModel()
        {
            GoToHomeViewCommand = new RelayCommand(GoToSettingsView);
        }

        private void GoToSettingsView()
        {
            ViewNavigator.Navigate(nameof(HomeView));
        }
    }
}
