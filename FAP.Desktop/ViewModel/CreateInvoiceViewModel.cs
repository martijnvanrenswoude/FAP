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
        private FAPEntities context;

        private int invoice_id = 0;
        private int employee_id;
        private int quotation_id;
        private int payment_status;
        private int sum;
        private DateTime deadline;
        private DateTime date;
         public int Invoice_id
        {
            get { return invoice_id; }
            set { invoice_id = value;
                base.RaisePropertyChanged("invoices");
            }
        }
        public int Employee_id
        {
            get { return employee_id; }
            set { employee_id = value;
                base.RaisePropertyChanged("invoices"); }
        }
        public int Quotation_id
        {
            get { return quotation_id; }
            set
            {
                quotation_id = value;
                base.RaisePropertyChanged("invoices");
            }
        }
        public int Payment_status
        {
            get { return payment_status; }
            set
            {
                payment_status = value;
                base.RaisePropertyChanged("invoices");
            }
        }
        public int Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                base.RaisePropertyChanged("invoices");
            }
        }
        public DateTime Deadline
        {
            get { return deadline; }
            set
            {
                deadline = value;
                base.RaisePropertyChanged("invoices");
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                base.RaisePropertyChanged("invoices");
            }
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
            context = new FAPEntities();
            Invoice i = new Invoice();
            if (context.Invoices.ToList().LastOrDefault() == null)
            {
                i.id = 1;
            } else {
                i.id = context.Invoices.ToList().LastOrDefault().id + 1;
            }
            i.employee_id = employee_id;
            i.quotation_id = quotation_id;
            i.payment_status = payment_status;
            i.sum = sum;
            i.deadline = deadline;
            i.date = date;
            context.Invoices.Add(i);
            context.SaveChanges();
            invoiceViewModel.GetAllInvoices();
            invoiceViewModel.createInvoiceView.Close();
        }
    }
}
