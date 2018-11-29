using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace FAP.Desktop.ViewModel
{
    class InspectiesModel
    {
        public ObservableCollection<InspectionVM> Inspections { get; set; }
        public ICommand OpenInspectionCommand { get; set; }
        public ICommand DeleteInspectionCommand { get; set; }
        public ICommand AddInspectionCommand { get; set; }

        public InspectiesModel()
        {
            OpenInspectionCommand = new RelayCommand(OpenInspection);
            DeleteInspectionCommand = new RelayCommand(DeleteInspection);
            AddInspectionCommand = new RelayCommand(AddInspection);
        }

        private void AddInspection()
        {
            throw new NotImplementedException();
        }

        private void DeleteInspection()
        {
            throw new NotImplementedException();
        }

        private void OpenInspection()
        {
            throw new NotImplementedException();
        }

        #region INotifyPropertyChanged Members
        // Zorgt ervoor dat de view wordt geupdate als de methode wordt aangeroepen, met als parameter het veld dat is veranderd.
        public override void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
