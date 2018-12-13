/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:FAP.Desktop"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace FAP.Desktop.ViewModel
{
    public class ViewModelLocator
    {
        private MasterRepository _master;

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            _master = new MasterRepository();

            SimpleIoc.Default.Register(_master.GetRepository<Bank_Account>);
            SimpleIoc.Default.Register(_master.GetRepository<Contact>);
            SimpleIoc.Default.Register(_master.GetRepository<Customer>);
            SimpleIoc.Default.Register(_master.GetRepository<Department>);
            SimpleIoc.Default.Register(_master.GetRepository<Employee>);
            SimpleIoc.Default.Register(_master.GetRepository<Event>);
            SimpleIoc.Default.Register(_master.GetRepository<ID>);
            SimpleIoc.Default.Register(_master.GetRepository<Inlogdata>);
            SimpleIoc.Default.Register(_master.GetRepository<Inspector>);
            SimpleIoc.Default.Register(_master.GetRepository<Inspector_shedule>);
            SimpleIoc.Default.Register(_master.GetRepository<Invoice>);
            SimpleIoc.Default.Register(_master.GetRepository<Payment_status>);
            SimpleIoc.Default.Register(_master.GetRepository<Planning>);
            SimpleIoc.Default.Register(_master.GetRepository<Question>);
            SimpleIoc.Default.Register(_master.GetRepository<Questionnaire>);
            SimpleIoc.Default.Register(_master.GetRepository<Quotation>);
            SimpleIoc.Default.Register(_master.GetRepository<StandardQuestion>);
            SimpleIoc.Default.Register(_master.GetRepository<StandardQuestionsList>);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestViewModel>();
            SimpleIoc.Default.Register<TestOtherViewModel>();
            SimpleIoc.Default.Register<InvoiceViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TestViewModel TestView => ServiceLocator.Current.GetInstance<TestViewModel>();
        public TestOtherViewModel TestViewOther => ServiceLocator.Current.GetInstance<TestOtherViewModel>();
        public InvoiceViewModel InvoiceView => ServiceLocator.Current.GetInstance<InvoiceViewModel>();


        public static void Cleanup()
        {
        }
    }
}