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
    public class EmployeeViewModel : ViewModelBase, ITransitionable
    {
        GenericRepository<Employee> _repository;
        public ObservableCollection<Employee> employees { get; set; }

        public Employee SelectedEmployee { get; set; }

        public string SearchText { get; set; }

        public RelayCommand search { get; set; }
        public RelayCommand Delete { get; set; }
        public RelayCommand NewEmployeeButton { get; set; }

        public EmployeeViewModel(GenericRepository<Employee> _repository)
        {
            this._repository = _repository;
            employees = new ObservableCollection<Employee>(_repository.Get());

            search = new RelayCommand(Search);
            Delete = new RelayCommand(DeleteEmployee);
            NewEmployeeButton = new RelayCommand(NewEmployee);
        }

        private void NewEmployee()
        {
            ViewNavigator.Navigate(nameof(CreateEmployeeView));
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                _repository.Delete(SelectedEmployee);
                employees.Remove(SelectedEmployee);
            }
        }

        public Employee EditEmployee
        {
            set
            {
                    SelectedEmployee = value;
                    _repository.Update(value);
            }
        }

        private void Search()
        {
            if (SearchText != null && SearchText != "")
            {
                employees = new ObservableCollection<Employee>(_repository.Get().Where(e => e.name.ToUpper().Contains(SearchText.ToUpper())));
            }
            else
            {
                employees = new ObservableCollection<Employee>(_repository.Get());
            }
            RaisePropertyChanged("employees");
        }

        public void Show()
        {
            employees = new ObservableCollection<Employee>(_repository.Get());
        }

        public void Hide()
        {
        }
    }
}
