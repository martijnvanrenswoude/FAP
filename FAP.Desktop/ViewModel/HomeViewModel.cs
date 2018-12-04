using CommonServiceLocator;
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
        //vars
        private int accesLevel;
        //commands
        public RelayCommand GoToSettingsViewCommand { get; set; }
        public RelayCommand GoToRapportagesViewCommand { get; set; }
        public RelayCommand GoToDataBeheerViewCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }
        //constructor
        public HomeViewModel(GenericRepository<Customer> repository)
        {
            this.accesLevel = getAccesLevel();
            //commands
            GoToSettingsViewCommand =       new RelayCommand(GoToSettingsView);
            GoToRapportagesViewCommand =    new RelayCommand(GoToRapportagesView);
            GoToDataBeheerViewCommand =     new RelayCommand(GoToDataBeheerView);
            LogoutCommand =                 new RelayCommand(Logout);
        }

        //functions
        private int getAccesLevel()
        {
            var g = ServiceLocator.Current.GetInstance<LoginViewModel>();
            return g.AccesLevel;
        }
        
        //command functions
        private void Logout()
        {
            accesLevel = -1;
            ViewNavigator.Navigate(nameof(LoginView));
        }
        private void GoToSettingsView()
        {
            ViewNavigator.Navigate(nameof(SettingsView));
        }
        private void GoToRapportagesView()
        {
            this.accesLevel = getAccesLevel();
            if (accesLevel == 1 || accesLevel == 3)
            {
                ViewNavigator.Navigate(nameof(RapportagesView));
            }            
        }
        private void GoToDataBeheerView()
        {
            ViewNavigator.Navigate(nameof(DataBeheerView));
        }
    }
}
