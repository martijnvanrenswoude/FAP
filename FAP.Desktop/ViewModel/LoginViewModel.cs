using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
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
        private List<Inlogdata> inlogdata;
        private String username;
        private String password;
        private String loginMessage;
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
        public String LoginMessage
        {
            get { return loginMessage; }
            set
            {
                loginMessage = value;
                base.RaisePropertyChanged();
            }
        }
        //commands
        public RelayCommand InlogAsUserCommand { get; set; }
        public RelayCommand InlogAsInspectorCommand { get; set; }
        public RelayCommand BypassLoginCommand { get; set; }
        
        //constructor
        public LoginViewModel()
        {
            GetAllLoginData();
            //set commands
            InlogAsInspectorCommand =   new RelayCommand(InlogAsInspector);
            InlogAsUserCommand =        new RelayCommand(InlogAsUser);
            BypassLoginCommand =        new RelayCommand(BypassLogin);
        }
        //functions
        private void GetAllLoginData()
        {
            using (var context = new FAPDatabaseEntities())
            {

                inlogdata = context.Inlogdata.ToList();
            }
        }

        //command fuctions
        private void InlogAsUser()
        {
            foreach(var i in inlogdata)
            {
                if(username != null && password != null)
                {
                    if (username.Equals(i.username) && password.Equals(i.password))
                    {
                        username = null;
                        password = null;
                        ViewNavigator.Navigate(nameof(HomeView));
                        return;
                    }
                    LoginMessage = "Gebruikersnaam of wachtwoord is incorrect";
                    return;
                }
                LoginMessage = "Vul een Gebruikersnaam en wachtwoord in";
            }
        }
        private void InlogAsInspector()
        {
            
        }
        private void BypassLogin()
        {
            ViewNavigator.Navigate(nameof(HomeView));
        }



    }
}
