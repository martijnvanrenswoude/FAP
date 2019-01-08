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
        private FAPEntities context;

        public ObservableCollection<Invoice> invoices { get; set; }
        public GenericRepository<Invoice> repository;
        public ICommand DeleteInvoiceCommand { get; set; }
        public ICommand AddInvoiceCommand { get; set; }

        public Invoice SelectedInvoice { get; set; }

        public InvoiceViewModel()
        {
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
            context = new FAPEntities();
            using (context)
            {
                if (SelectedInvoice != null)
                {
                    context.Invoices.Remove(SelectedInvoice);
                    context.SaveChanges();
                    GetAllInvoices();
                    SelectedInvoice = null;
                    RaisePropertyChanged("invoices");

                }
            }
        }

        public void GetAllInvoices()
        {
            context = new FAPEntities();
            using (context)
            {
                invoices = new ObservableCollection<Invoice>(context.Invoices.ToList());
            }
        }

        private Invoice EditInspection
        {
            set
            {
                if (value != null)
                {
                    SelectedInvoice = value;
                    context.Invoices.Attach(value);
                    context.SaveChanges();
                    GetAllInvoices();
                    RaisePropertyChanged("invoices");
                }
            }
        }
    }
}
