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
using FAP.Repository.Explicit;
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

            // Implicit
            SimpleIoc.Default.Register(_master.GetRepository<Bank_Account>);
            SimpleIoc.Default.Register(_master.GetRepository<Contact>);
            SimpleIoc.Default.Register(_master.GetRepository<Customer>);
            SimpleIoc.Default.Register(_master.GetRepository<Department>);
            SimpleIoc.Default.Register(_master.GetRepository<Employee>);
            SimpleIoc.Default.Register(_master.GetRepository<Event>);
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
            SimpleIoc.Default.Register(_master.GetRepository<Inspector_Bank_Account>);
            SimpleIoc.Default.Register(_master.GetRepository<MultipleChoice>);
            SimpleIoc.Default.Register(_master.GetRepository<MultiplechoiceAnswers>);
            SimpleIoc.Default.Register(_master.GetRepository<OpenSubjectQuestion>);
            SimpleIoc.Default.Register(_master.GetRepository<ComboQuestion>);

            // Explicit
            //SimpleIoc.Default.Register<CustomerRepository>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<RapportagesViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<DataBeheerViewModel>();
            SimpleIoc.Default.Register<KlantBeheerViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<PlanningBeheerViewModel>();
            SimpleIoc.Default.Register<PlanningCreateViewModel>();
            SimpleIoc.Default.Register<PlanningUpdateViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public HomeViewModel HomeView => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public SettingsViewModel SettingsView => ServiceLocator.Current.GetInstance<SettingsViewModel>();
        public RapportagesViewModel RapportagesView => ServiceLocator.Current.GetInstance<RapportagesViewModel>();
        public DataBeheerViewModel NieuweDataView => ServiceLocator.Current.GetInstance<DataBeheerViewModel>();
        public KlantBeheerViewModel KlantBeheerView => ServiceLocator.Current.GetInstance<KlantBeheerViewModel>();
        public PlanningBeheerViewModel PlanningBeheerViewModel => ServiceLocator.Current.GetInstance<PlanningBeheerViewModel>();
        public PlanningCreateViewModel PlanningCreateViewModel => ServiceLocator.Current.GetInstance<PlanningCreateViewModel>();
        public PlanningUpdateViewModel PlanningUpdateViewModel => ServiceLocator.Current.GetInstance<PlanningUpdateViewModel>();

        public LoginViewModel LoginView => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public static void Cleanup()
        {
        }
    }
}