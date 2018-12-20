using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;

using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
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
    public class InvoiceViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public CreateInvoiceView createInvoiceView;

        public ObservableCollection<Invoice> invoices { get; set; }
        public GenericRepository<Invoice> repository;
        public ICommand DeleteInvoiceCommand { get; set; }
        public ICommand AddInvoiceCommand { get; set; }

        public Invoice SelectedInvoice { get; set; }

        public InvoiceViewModel()
        {
            repository = new GenericRepository<Invoice>(new FAPEntities());
            GetAllInvoices();
            DeleteInvoiceCommand = new RelayCommand(DeleteInvoice);
            AddInvoiceCommand = new RelayCommand(AddInvoice);
        }
        
        private void AddInvoice()
        {
            createInvoiceView = new CreateInvoiceView();
            createInvoiceView.Show();
        }

        private void DeleteInvoice()
        {
            if (SelectedInvoice != null)
            {
                repository.Delete(SelectedInvoice);
                invoices.Remove(SelectedInvoice);
                SelectedInvoice = null;
                RaisePropertyChanged("invoices");
                
            }
        }

        public void GetAllInvoices()
        {
            invoices = new ObservableCollection<Invoice>(repository.Get());
        }

        private Invoice EditInspection
        {
            set
            {
                if (value != null)
                {
                    SelectedInvoice = value;
                    repository.Update(value);
                    RaisePropertyChanged("invoices");
                }
            }
        }

        private void UpdateInvoices()
        {
            invoices = new ObservableCollection<Invoice>(repository.Get());
        }
    }
}
