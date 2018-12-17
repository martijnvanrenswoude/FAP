using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FAP.Desktop.ViewModel
{
    class MultipleChoiceViewModel : ViewModelBase
    {
        //vars
        private MultipleChoice question;
        private GenericRepository<MultipleChoice> repository;
        private GenericRepository<MultiplechoiceAnswer> answerRepository;
        //properties
        public int amountOfAnswers { get; set; }
        public int[] PossibleAnswerAmount { get; set; }
        public string Answer { get; set; }
        public string Question
        {
            get { return question.question; }
            set { question.question = value; }
        }        
        public List<MultiplechoiceAnswer> AllAnswers { get; set; }
        public List<MultipleChoice> AllQuestions { get; set; }
        public MultipleChoice SelectedQuestion { get; set; }
        public MultiplechoiceAnswer SelectedAnswer { get; set;}
        //commands
        public ICommand AddQuestionCommand { get; set; }
        public ICommand DeletQuestionCommand { get; set; }
        //constructor
        public MultipleChoiceViewModel()
        {
            PossibleAnswerAmount = new int[] { 2, 3, 4 };
            repository = new GenericRepository<MultipleChoice>(new FAPDatabaseEntities());
            answerRepository = new GenericRepository<MultiplechoiceAnswer>(new FAPDatabaseEntities());

        }
        //methods
        public void GetAllQuestionsFromDatabase()
        {
            AllQuestions = repository.Get().ToList();
        }

        public void GetAllAnswersFromDatabase()
        {
            AllAnswers = answerRepository.Get(a => a.Id == SelectedQuestion.Id).ToList();
        }

        public void AddQuestionToDatabase()
        {
            MultiplechoiceAnswer[] multiplechoiceAnswers = new MultiplechoiceAnswer[amountOfAnswers];
            repository.Insert(question);
            for(int i = 0; i < multiplechoiceAnswers.Length; i++)
            {
                answerRepository.Insert(multiplechoiceAnswers[i]);
                break;
            }
        }

        public void DeleteSelectedQuestionFromDatabase()
        {
            repository.Delete(SelectedQuestion);
        }

    }
}
