using CommonServiceLocator;
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
    public class DataBeheerViewModel
    {
        //vars
        private int accesLevel;
        //command
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand GoToKlantBeheerViewCommand { get; set; }
        public RelayCommand GoToMedewerkerBeheerViewCommand { get; set; }
        //constructor
        public DataBeheerViewModel()
        {            
            GoBackCommand =                         new RelayCommand(GoBackView);
            GoToKlantBeheerViewCommand =            new RelayCommand(GoToKlantBeheerView);
            GoToMedewerkerBeheerViewCommand =       new RelayCommand(GoToMedewerkerBeheerView);
        }
        //functions
        private int getAccesLevel()
        {
            var g = ServiceLocator.Current.GetInstance<LoginViewModel>();
            return g.AccesLevel;
        }

        //command functions
        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }
        private void GoToKlantBeheerView()
        {
            this.accesLevel = getAccesLevel();
            if (accesLevel == 1 || accesLevel == 4)
            {
                ViewNavigator.Navigate(nameof(KlantBeheerView));
            }
        }
        private void GoToMedewerkerBeheerView()
        {
            this.accesLevel = getAccesLevel();
            if (accesLevel == 1 || accesLevel == 2)
            {
                ViewNavigator.Navigate(nameof(EmployeeView));
            }
        }
    }
}
