using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FAP.Desktop.ViewModel 
{
    public class CreateInvoiceViewModel : ViewModelBase
    {
        private GenericRepository<Invoice> repository;
        private InvoiceViewModel invoiceViewModel;

        private int invoice_id;
        private int employee_id;
        private int quotation_id;
        private int payment_status;
        private int sum;
        private DateTime deadline;
        private DateTime date;

        public int Employee_id
        {
            get { return employee_id}
            set { employee_id = value
                    base.RaisePropertyChanged("invoices"); }
        }

        public CreateInvoiceViewModel(GenericRepository<Invoice> repository, InvoiceViewModel invoiceViewModel )
        {
            this.repository = repository;
            this.invoiceViewModel = invoiceViewModel;
        }

        public void Cancel()
        {
            Application.Current.Windows[0].Close();
        }

        public void AddInvoice()
        {
            Invoice i = new Invoice();
            i.id = invoice_id;
            i.employee_id = employee_id;
            i.quotation_id = quotation_id;
            i.payment_status = payment_status;
            i.sum = sum;
            i.deadline = deadline;
            i.date = date;
            repository.Insert(i);
            invoiceViewModel.GetAllInvoices();
            invoiceViewModel.createInvoiceViewModel.Close();
        }
    }
}
