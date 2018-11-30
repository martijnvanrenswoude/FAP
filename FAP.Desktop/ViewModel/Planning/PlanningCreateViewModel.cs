﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAP.Desktop.Message;
using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace FAP.Desktop.ViewModel
{
    public class PlanningCreateViewModel
        :   ViewModelBase,
            ITransitionable
    {
        private readonly GenericRepository<Planning> planningRepository;
        private readonly GenericRepository<Employee> employeeRepository;
        private readonly GenericRepository<Event> eventRepository;
        private readonly GenericRepository<Customer> customerRepository;
        private readonly GenericRepository<Questionnaire> questionaireRepository;
        
        public ObservableCollection<Employee> Employees { get; }
        public ObservableCollection<Event> Events { get; }
        public ObservableCollection<Customer> Customers { get; }
        public ObservableCollection<Questionnaire> Questionnaires { get; }

        private Employee selectedEmployee;
        private Event selectedEvent;
        private Customer selectedCustomer;
        private Questionnaire selectedQuestionnaire;
        private DateTime selectedDate;
        
        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                selectedDate = value;
                RaisePropertyChanged(() => SelectedDate);
            }
        }

        public Questionnaire SelectedQuestionnaire
        {
            get => selectedQuestionnaire;
            set
            {
                selectedQuestionnaire = value;
                RaisePropertyChanged(() => SelectedQuestionnaire);
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged(() => SelectedCustomer);
            }
        }

        public Event SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                RaisePropertyChanged(() => SelectedEvent);
            }
        }

        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                RaisePropertyChanged(() => SelectedEmployee);
            }
        }

        public RelayCommand BackToPlanningManagementCommand { get; }
        public RelayCommand AddNewPlanningCommand { get; }

        public PlanningCreateViewModel( GenericRepository<Planning> planningRepository,
                                        GenericRepository<Employee> employeeRepository,
                                        GenericRepository<Event> eventRepository,
                                        GenericRepository<Customer> customerRepository,
                                        GenericRepository<Questionnaire> questionaireRepository)
        {
            this.planningRepository = planningRepository;
            this.employeeRepository = employeeRepository;
            this.eventRepository = eventRepository;
            this.customerRepository = customerRepository;
            this.questionaireRepository = questionaireRepository;

            Employees = new ObservableCollection<Employee>();
            Events = new ObservableCollection<Event>();
            Customers = new ObservableCollection<Customer>();
            Questionnaires = new ObservableCollection<Questionnaire>();

            BackToPlanningManagementCommand = new RelayCommand(BackToPlanningManagement);
            AddNewPlanningCommand = new RelayCommand(AddNewPlanning);

            SelectedDate = DateTime.Now;
        }

        private void LoadEmployees()
        {
            Employees.Clear();

            foreach (var employee in employeeRepository.Get())
            {
                Employees.Add(employee);
            }

            RaisePropertyChanged(() => Employees);
        }

        private void LoadEvents()
        {
            Events.Clear();

            foreach (var e in eventRepository.Get())
            {
                Events.Add(e);
            }

            RaisePropertyChanged(() => Events);
        }

        private void LoadCustomers()
        {
            Customers.Clear();

            foreach (var customer in customerRepository.Get())
            {
                Customers.Add(customer);
            }

            RaisePropertyChanged(() => Customers);
        }

        private void LoadQuestionnaires()
        {
            Questionnaires.Clear();

            foreach (var questionnaire in questionaireRepository.Get())
            {
                Questionnaires.Add(questionnaire);
            }

            RaisePropertyChanged(() => Questionnaires);
        }

        private void BackToPlanningManagement()
        {
            ViewNavigator.Navigate("back");
        }

        private void AddNewPlanning()
        {
            if (SelectedEmployee == null ||
                SelectedCustomer == null ||
                SelectedQuestionnaire == null ||
                SelectedEvent == null)
            {
                return;
            }

            planningRepository.Insert(new Planning
            {
                Employee = SelectedEmployee,
                Customer = SelectedCustomer,
                Event = SelectedEvent,
                start_date = SelectedDate,
                Questionnaire = SelectedQuestionnaire
            });

            BackToPlanningManagement();
        }

        public void Show()
        {
            LoadEmployees();
            LoadCustomers();
            LoadEvents();
            LoadQuestionnaires();
        }

        public void Hide()
        {
        }
    }
}