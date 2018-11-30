using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAP.Desktop.Message;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using FAP.Desktop.Navigation;
using FAP.Desktop.View.Planning;

namespace FAP.Desktop.ViewModel
{
    public sealed class PlanningBeheerViewModel 
        :   ViewModelBase,
            ITransitionable
    {
        private readonly GenericRepository<Planning>        repository;
        private ObservableCollection<Planning>              plannings;
        private Planning                                    selectedPlanning;
        private string                                      planningSearch;

        public ObservableCollection<Planning> Plannings
        {
            get => plannings;
            set
            {
                plannings = value;
                RaisePropertyChanged(() => Plannings);
            }
        }

        public Planning SelectedPlanning
        {
            get => selectedPlanning;
            set
            {
                selectedPlanning = value;
                RaisePropertyChanged(() => SelectedPlanning);
            }
        }

        public string PlanningSearch
        {
            get => planningSearch;
            set
            {
                planningSearch = value;
                RaisePropertyChanged(() => PlanningSearch);
            }
        }

        public RelayCommand<Planning> SelectedPlanningChangedCommand { get; }
        public RelayCommand ResetSearchCommand { get; }
        public RelayCommand SearchPlanningCommand { get; }
        public RelayCommand GoToEditPlanningViewCommand { get; }
        public RelayCommand GoToNewPlanningViewCommand { get; }
        public RelayCommand DeletePlanningCommand { get; }
        public RelayCommand GoBackCommand { get; }

        public RelayCommand OpenEmployeeSelectorCommand { get; }
        public RelayCommand OpenCustomerSelectorCommand { get; }
        public RelayCommand OpenEventSelectorCommand { get; }
        public RelayCommand OpenQuestionnaireSelectorCommand { get; }

        public PlanningBeheerViewModel(GenericRepository<Planning> repository)
        {
            this.repository = repository;

            plannings = new ObservableCollection<Planning>();

            SelectedPlanningChangedCommand = new RelayCommand<Planning>(ChangeSelectedPlanning);
            SearchPlanningCommand = new RelayCommand(SearchPlanning);
            GoToEditPlanningViewCommand = new RelayCommand(GoToEditPlanning);
            GoToNewPlanningViewCommand = new RelayCommand(GoToCreatePlanning);
            DeletePlanningCommand = new RelayCommand(DeletePlanning);
            GoBackCommand = new RelayCommand(GoBack);
            ResetSearchCommand = new RelayCommand(() => PlanningSearch = string.Empty);
        }

        private void RetrievePlanningData()
        {
            plannings.Clear();

            foreach (var planning in repository.Get())
            {
                plannings.Add(planning);
            }
        }

        private void SearchPlanning()
        {
            plannings.Clear();

            foreach (var planning in repository.Get(o => o.Event.name.Contains(PlanningSearch)))
            {
                plannings.Add(planning);
            }
        }

        private void ChangeSelectedPlanning(Planning planning)
        {
            SelectedPlanning = planning;
        }

        private void DeletePlanning()
        {
            if (SelectedPlanning != null)
            {
                repository.Delete(SelectedPlanning);
            }
        }
        
        private void GoToEditPlanning()
        {
            ViewNavigator.Navigate(nameof(PlanningUpdateView));
        }
        
        private void GoToCreatePlanning()
        {
            ViewNavigator.Navigate(nameof(PlanningCreateView));
        }

        private void GoBack()
        {
            ViewNavigator.Navigate("Back");
        }

        public void Show()
        {
            RetrievePlanningData();
        }

        public void Hide()
        {
        }
    }
}
