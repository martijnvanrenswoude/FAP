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
    public class NieuweDataViewModel
    {
        //commands
        public RelayCommand goToHomeViewCommand { get; set; }
        public RelayCommand goToKlantenViewCommand { get; set; }


        public NieuweDataViewModel()
        {
            goToHomeViewCommand = new RelayCommand(GoToFormulierenView);
        }

        private void GoToFormulierenView()
        {
            ViewNavigator.Navigate(nameof(HomeView));
            //klanten
            //medewerkers
            //inspecteurs
            //offertes/facturen
            //vragenlijsten
        }
    }
}
