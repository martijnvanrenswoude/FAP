using FAP.Desktop.Message;
using FAP.Desktop.Navigation;
using FAP.Desktop.View;
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
    public class TestViewModel : ViewModelBase
    {
        public RelayCommand GoToOtherViewCommand { get; set; }

        public TestViewModel()
        {
            GoToOtherViewCommand = new RelayCommand(GoToOtherView);
        }

        private void GoToOtherView()
        {
            ViewNavigator.Navigate(nameof(TestViewOther));
        }
    }
}
