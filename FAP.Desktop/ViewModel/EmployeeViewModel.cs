using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FAP.Desktop.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        GenericRepository<Employee> _repository;
        public ObservableCollection<Employee> employees { get; set; }

        public string SearchText { get; set; }

        public RelayCommand search { get; set; }

        public EmployeeViewModel(GenericRepository<Employee> employeeRepo)
        {
            _repository = employeeRepo;
            employees = new ObservableCollection<Employee>(_repository.Get());

            search = new RelayCommand(Search);
        }


        public Employee EditEmployee
        {
            set
            {
                _repository.Update(value);
            }
        }

        private void Search()
        {
            if (SearchText != null && SearchText != "")
            {
                employees = new ObservableCollection<Employee>(_repository.Get().Where(e => e.name.ToUpper().Equals(SearchText.ToUpper())));
            }
            else
            {
                employees = new ObservableCollection<Employee>(_repository.Get());
            }
            RaisePropertyChanged("employees");
        }

    }
}
