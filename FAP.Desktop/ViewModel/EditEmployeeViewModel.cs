using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class EditEmployeeViewModel
    {

        public RelayCommand GoBack { get; set; }

        public EditEmployeeViewModel()
        {
            GoBack = new RelayCommand(GoBackCommand);
        }

        private void GoBackCommand()
        {
            ViewNavigator.Navigate(nameof(EmployeeView));
        }
    }
}
