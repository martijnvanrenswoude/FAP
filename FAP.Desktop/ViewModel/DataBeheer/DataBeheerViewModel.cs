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
        
        //command
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand GoToKlantBeheerViewCommand { get; set; }
        public RelayCommand GoToContactpersoonBeheerViewCommand { get; set; }

        public DataBeheerViewModel()
        {
            GoToContactpersoonBeheerViewCommand =   new RelayCommand(GoToContactpersoonBeheerView);
            GoBackCommand =                         new RelayCommand(GoBackView);
            GoToKlantBeheerViewCommand =            new RelayCommand(GoToKlantBeheerView);
        }

        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }
        private void GoToKlantBeheerView()
        {
            ViewNavigator.Navigate(nameof(KlantBeheerView));
        }
        private void GoToContactpersoonBeheerView()
        {
            ViewNavigator.Navigate(nameof(ContactpersoonBeheerView));
        }
    }
}
