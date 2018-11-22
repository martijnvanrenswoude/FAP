using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //vars
        private String username;
        private String password;
        //properties
        public String Username
        {
            get { return username; }
            set
            {
                username = value;
                base.RaisePropertyChanged();
            }
        }
        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                base.RaisePropertyChanged();
            }
        }
       
        //commands
        public RelayCommand InlogAsUserComand { get; set; }
        public RelayCommand InlogAsInspectorCommand { get; set; }
        //constructor
        public LoginViewModel()
        {
            InlogAsInspectorCommand = new RelayCommand(InlogAsInspector);
            InlogAsUserComand = new RelayCommand(InlogAsUser);
        }
        //command fuctions
        private void InlogAsUser()
        {
            
        }
        private void InlogAsInspector()
        {

        }

    }
}
