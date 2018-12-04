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
        GenericRepository<Inlogdata> loginDataRepository;
        GenericRepository<Employee> employeeRepository;
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
        public int AccesLevel { get; set; }
        //commands
        public RelayCommand InlogAsUserCommand { get; set; }
        public RelayCommand InlogAsInspectorCommand { get; set; }
        public RelayCommand BypassLoginCommand { get; set; }
        
        //constructor
        public LoginViewModel(GenericRepository<Inlogdata> iRepo, GenericRepository<Employee> eRepo)
        {
            //set repos
            loginDataRepository = iRepo;
            employeeRepository = eRepo;
            GetAllLoginData();
            //set commands
            InlogAsInspectorCommand =   new RelayCommand(InlogAsInspector);
            InlogAsUserCommand =        new RelayCommand(InlogAsUser);
            BypassLoginCommand =        new RelayCommand(BypassLogin);
        }
        //functions
        private void GetAllLoginData()
        {
            inlogdata = new List<Inlogdata>(loginDataRepository.Get());            
        }

        //command fuctions
        private void InlogAsUser()
        {
            if (username != null && password != null)
            {
                foreach (var i in inlogdata)
                {
                    if (username.Equals(i.username) && password.Equals(i.password))
                    {
                        username = null;
                        password = null;
                        AccesLevel = getAccesLevel(i.Id);
                        ViewNavigator.Navigate(nameof(HomeView));
                        return;
                    }
                }
                LoginMessage = "Gebruikersnaam of wachtwoord is incorrect";
                return;
            }
            LoginMessage = "Vul een Gebruikersnaam en wachtwoord in";
        }
        private void InlogAsInspector()
        {
            
        }
        private void BypassLogin()
        {
            AccesLevel = 1;
            ViewNavigator.Navigate(nameof(HomeView));
        }

        private int getAccesLevel(int id)
        {
            List<Employee> employees = new List<Employee>(employeeRepository.Get());
            foreach( var e in employees)
            {
                if(e.id == id)
                {
                    return (int) e.acces_level;
                }
            }
            return -1;
        }



    }
}
