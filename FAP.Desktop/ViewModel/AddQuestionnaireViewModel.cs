using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class AddQuestionnaireViewModel : ViewModelBase
    {
        private GenericRepository<Question> _questionRepository;
        private GenericRepository<Questionnaire> _questionnaireRepository;

        public Question SelectedQuestionnaireQuestion { get; set; }
        public Question SelectedQuestion { get; set; }

        private Questionnaire questionnaire;
        public Questionnaire Questionnaire
        {
            get { return questionnaire; }
            set
            {
                questionnaire = value;
                RaisePropertyChanged("Questionnaire");
            }
        }

        public ObservableCollection<Question> Questions { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public AddQuestionnaireViewModel(GenericRepository<Question> questionRepository, GenericRepository<Questionnaire> questionnaireRepository)
        {
            Questionnaire = new Questionnaire();
            SelectedQuestionnaireQuestion = new Question();
            SelectedQuestion = new Question();
            Questions = new ObservableCollection<Question>(questionRepository.Get());

            _questionRepository = questionRepository;
            _questionnaireRepository = questionnaireRepository;

            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            Questionnaire.Comment = "";
            _questionnaireRepository.Insert(Questionnaire);
            ViewNavigator.Navigate(nameof(QuestionnaireView));
            //TODO: Messagebox
        }

        private void Delete()
        {
            Questionnaire.Questions.Remove(SelectedQuestionnaireQuestion);
        }

        private void Add()
        {
            Questionnaire.Questions.Add(SelectedQuestion);
            RaisePropertyChanged("Questionnaire");
        }


    }
}
