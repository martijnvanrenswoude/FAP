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

        public PlanningBeheerViewModel(GenericRepository<Planning> repository)
        {
            this.repository = repository;

            plannings = new ObservableCollection<Planning>();

            SelectedPlanningChangedCommand = new RelayCommand<Planning>(ChangeSelectedPlanning);

            
        }

        private void RetrievePlanningData()
        {
            plannings.Clear();

            foreach (var planning in repository.Get())
            {
                plannings.Add(planning);
            }
        }

        private void ChangeSelectedPlanning(Planning planning)
        {
            SelectedPlanning = planning;
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
