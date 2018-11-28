using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class CreateEmployeeViewModel
    {
        GenericRepository<Employee> _repository;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Zipcode { get; set; }
        public string Housenumber { get; set; }
        public DateTime Birthdate{ get; set; }
        public DateTime DateEnd { get; set; }

        public RelayCommand GoBack { get; set; }
        public RelayCommand AddEmployeeButton { get; set; }

        public CreateEmployeeViewModel(GenericRepository<Employee> _repository)
        {
            this._repository = _repository;

            Birthdate = new DateTime(1900, 01, 01);
            DateEnd = DateTime.Now;

            GoBack = new RelayCommand(GoBackCommand);
            AddEmployeeButton = new RelayCommand(AddEmployee);
        }

        private void ResetProperties()
        {
            Name = null;
            Surname = null;
            Position = null;
            Zipcode = null;
            Housenumber = null;
            Birthdate = new DateTime(1900, 01, 01);
        }

        private void AddEmployee()
        {
            Employee newEmployee = new Employee();
            newEmployee.name = Name;
            newEmployee.surname = Surname;

            //Bij deze 2 moet er nog iets gebeuren
            //Deze zijn nu namelijk hardcoded ingevuld
            newEmployee.acces_level = null;
            newEmployee.department_id = 1;

            newEmployee.position = Position;
            newEmployee.postcode = Zipcode;
            newEmployee.house_number = Housenumber;
            newEmployee.date_of_birth = Birthdate;

            _repository.Insert(newEmployee);
            GoBackCommand();
        }

        private void GoBackCommand()
        {
            ResetProperties();
            ViewNavigator.Navigate(nameof(EmployeeView));
        }
    }
}
