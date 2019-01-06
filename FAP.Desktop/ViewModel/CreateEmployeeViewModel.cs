using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class CreateEmployeeViewModel
    {
        GenericRepository<Employee> _repository;
        public List<string> AvailablePositions { get; set; }
        public List<int> AvailableAccesLevels { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Zipcode { get; set; }

        public string Housenumber { get; set; }
        public int AccesLevel { get; set; }
        public DateTime Birthdate{ get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public RelayCommand GoBack { get; set; }
        public RelayCommand AddEmployeeButton { get; set; }

        public CreateEmployeeViewModel(GenericRepository<Employee> _repository)
        {
            this._repository = _repository;
            AvailablePositions = new List<string>();
            AvailableAccesLevels = new List<int>();
            FillPositionsList();
            FillAccesLevelList();

            DateStart = new DateTime(1900, 01, 01);
            Birthdate = DateStart;
            DateEnd = DateTime.Now;

            GoBack = new RelayCommand(GoBackCommand);
            AddEmployeeButton = new RelayCommand(AddEmployee);
        }

        private void FillAccesLevelList()
        {
            for(int i = 1; i < 6; i++)
            {
                AvailableAccesLevels.Add(i);
            }
        }

        private void FillPositionsList()
        {
            AvailablePositions.Add("CEO");
            AvailablePositions.Add("Inspecteur");
            AvailablePositions.Add("Operationeel medewerker");
            AvailablePositions.Add("Sales medewerker");
            AvailablePositions.Add("HR");
        }

        private void ResetProperties()
        {
            Name = null;
            Surname = null;
            Position = null;
            Zipcode = null;
            AccesLevel = 1;
            Housenumber = null;
            Birthdate = DateStart;
        }

        private void AddEmployee()
        {
            Employee newEmployee = new Employee();
            newEmployee.name = Name;
            newEmployee.surname = Surname;

            //Bij deze moet er nog iets gebeuren
            //Deze is nu namelijk hardcoded ingevuld
            newEmployee.department_id = 1;

            newEmployee.position = Position;
            newEmployee.acces_level = AccesLevel;
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
