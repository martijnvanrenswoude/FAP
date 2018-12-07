using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FAP.Repository.Generic;
using FAP.Domain;

namespace FAP.Desktop.ViewModel
{
    class RapportenModel
    {


        public ObservableCollection<Invoice> Invoices { get; set; }
        GenericRepository<Invoice> _repository;
        public ICommand DeleteInspectionCommand { get; set; }
        public ICommand AddInspectionCommand { get; set; }

        public Invoice SelectedInspection { get; set; }

        public RapportenModel()
        {
            DeleteInspectionCommand = new RelayCommand(DeleteInspection);
            AddInspectionCommand = new RelayCommand(AddInspection);

            Invoices = new ObservableCollection<Invoice>(_repository.Get());
        }

        private void AddInspection()
        {
            ViewNavigator.Navigate(nameof(CreateInvoiceView));
        }

        private void DeleteInspection()
        {
            throw new NotImplementedException();
        }

        public Invoice EditInvoice
        {
            set
            {
                if (value != null)
                {
                    SelectedInspection = value;
                    _repository.Update(value);
                }
            }
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
}
