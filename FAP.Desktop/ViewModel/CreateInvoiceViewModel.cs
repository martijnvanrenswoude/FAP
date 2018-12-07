using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    class CreateInvoiceViewModel
    {
        GenericRepository<Invoice> _repository;

        

        public RelayCommand GoBack { get; set; }
        public RelayCommand AddInvoiceButton { get; set; }

        public CreateInvoiceViewModel(GenericRepository<Invoice> _repository)
        {
            this._repository = _repository;

           

            GoBack = new RelayCommand(GoBackCommand);
            AddInvoiceButton = new RelayCommand(AddInvoice);
        }

        private void ResetProperties()
        {
            
        }

        private void AddInvoice()
        {
            Invoice newInvoice = new Invoice();
            

            _repository.Insert(newInvoice);
            GoBackCommand();
        }

        private void GoBackCommand()
        {
            ResetProperties();
            ViewNavigator.Navigate(nameof(InvoiceView));
        }
    }
}
