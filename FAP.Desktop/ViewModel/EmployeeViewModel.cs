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
        //public string[] positions = { "Inspecteur", "Sales", "Financieel manager"};
        //public string[] names = { "Bart", "Nick", "Rick", "Jan", "Bart", "Martijn", "Wouter", "Gijs", "Henk", "Hans", "Teun", "Daan" };

        GenericRepository<Employee> _repository;
        public ObservableCollection<Employee> employees { get; set; }

        public Employee SelectedEmployee { get; set; }

        public string SearchText { get; set; }

        public RelayCommand search { get; set; }
        public RelayCommand Delete { get; set; }
        public RelayCommand NewEmployeeButton { get; set; }
        public RelayCommand GraphWindowButton { get; set; }

        public EmployeeViewModel(GenericRepository<Employee> _repository)
        {
            this._repository = _repository;
            employees = new ObservableCollection<Employee>(_repository.Get());

            search = new RelayCommand(Search);
            Delete = new RelayCommand(DeleteEmployee);
            NewEmployeeButton = new RelayCommand(NewEmployee);
            GraphWindowButton = new RelayCommand(GraphWindow);
        }

        private void GraphWindow()
        {
            ViewNavigator.Navigate(nameof(GenerateGraphView));
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
                if (value != null)
                {
                    SelectedEmployee = value;
                    _repository.Update(value);
                }
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

        //public void InsertTestData()
        //{
        //    for(int i = 0; i < 100; i++)
        //    {
        //        Employee employee = new Employee();
        //        Random random = new Random();
        //        employee.department_id = 1;
        //        employee.name = names[random.Next(12)];
        //        employee.surname = "Test";
        //        employee.acces_level = null;
        //        employee.position = positions[random.Next(3)];
        //        employee.postcode = "1234AB";
        //        employee.house_number = (random.Next(99)+1).ToString();
        //        employee.date_of_birth = new DateTime(1980, 01, 01);
        //        _repository.Insert(employee);
        //    }
        //}
    }
}
