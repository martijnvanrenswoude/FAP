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
using System.Windows;

namespace FAP.Desktop.ViewModel
{
    public class AddQuestionViewModel : ViewModelBase
    {
        GenericRepository<Question> _questionRepository;
        GenericRepository<QuestionType> _questionTypeRepository;
        public ObservableCollection<QuestionType> QuestionTypes { get; set; }

        private Question question;
        public Question Question
        {
            get { return question; }
            set
            {
                question = value;
                RaisePropertyChanged("Question");
            }
        }

        private bool advancedForm;
        public bool AdvancedForm
        {
            get { return advancedForm; }
            set
            {
                advancedForm = value;
                RaisePropertyChanged("AdvancedForm");
            }
        }

        private QuestionType selectedQuestionType;
        public QuestionType SelectedQuestionType
        {
            get { return selectedQuestionType; }
            set
            {
                selectedQuestionType = value;
                ChangeForm();
            }
        }

        public RelayCommand AddCommand { get; set; }

        public AddQuestionViewModel(GenericRepository<QuestionType> questionTypeRepository, GenericRepository<Question> questionRepository)
        {
            Question = new Question();
            AdvancedForm = false;
            _questionTypeRepository = questionTypeRepository;
            _questionRepository = questionRepository;

            QuestionTypes = new ObservableCollection<QuestionType>(_questionTypeRepository.Get());
            SelectedQuestionType = QuestionTypes.FirstOrDefault(s => s.Name == "Normaal");

            AddCommand = new RelayCommand(Add);
        }

        private void Add()
        {
            Question.questionType = SelectedQuestionType.Name;
            _questionRepository.Insert(Question);


            MessageBoxResult result = MessageBox.Show("De vraag is opgeslagen, wil je nog een vraag toevoegen?",
                                          "Bevestiging",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);

            Question = new Question();

            if (result == MessageBoxResult.No)
            { 
                ViewNavigator.Navigate(nameof(QuestionView));
            }
        }

        private void ChangeForm()
        {
            switch (SelectedQuestionType.Name)
            {
                case "Normaal":
                    AdvancedForm = false;
                    break;
                case "Met Fotos":
                    AdvancedForm = false;
                    break;
                case "Met kaart":
                    AdvancedForm = false;
                    break;
                default:
                    AdvancedForm = true;
                    break;
            }
        }
    }
}
