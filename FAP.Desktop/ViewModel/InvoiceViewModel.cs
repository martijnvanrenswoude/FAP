using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FAP.Desktop.ViewModel
{
    public class InvoiceViewModel
    {
        public ObservableCollection<Invoice> invoices { get; set; }
        GenericRepository<Invoice> _repository;
        public ICommand DeleteInvoiceCommand { get; set; }
        public ICommand AddInvoiceCommand { get; set; }

        public Invoice SelectedInvoice { get; set; }

        public InvoiceViewModel(GenericRepository<Invoice> _repository)
        {
            this._repository = _repository;
            invoices = new ObservableCollection<Invoice>();
            SelectedInvoice = invoices.First();
            DeleteInvoiceCommand = new RelayCommand(DeleteInvoice);
            AddInvoiceCommand = new RelayCommand(AddInvoice);
        }

        private void AddInvoice()
        {
            ViewNavigator.Navigate(nameof(CreateInvoiceView));
        }

        private void DeleteInvoice()
        {
            if (SelectedInvoice != null)
            {
                _repository.Delete(SelectedInvoice);
                invoices.Remove(SelectedInvoice);
                SelectedInvoice = null;
            }
        }

        private Invoice EditInspection
        {
            set
            {
                if (value != null)
                {
                    SelectedInvoice = value;
                    _repository.Update(value);
                }
            }
        }

        private void UpdateInvoices()
        {
            invoices = new ObservableCollection<Invoice>(_repository.Get());
        }

        //#region INotifyPropertyChanged Members
        //// Zorgt ervoor dat de view wordt geupdate als de methode wordt aangeroepen, met als parameter het veld dat is veranderd.
        //public override void RaisePropertyChanged(string prop)
        //{
        //    if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //#endregion
    }
}
