using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private MultiplechoiceAnswer answer;
        
        private GenericRepository<MultipleChoice> repository;
        private GenericRepository<MultiplechoiceAnswer> answerRepository;
        //properties
        public int amountOfAnswers
        {
            get { return question.AmountOfAnswers; }
            set { this.question.AmountOfAnswers = value; AddQuestionToDatabase(); }
        }
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
        public MultiplechoiceAnswer SelectedAnswer
        {
            get { return this.answer; }
            set { this.answer = value; UpdateAnswer(); }
        }
        //commands
        public ICommand AddQuestionCommand { get; set; }
        public ICommand DeletQuestionCommand { get; set; }
        //constructor
        public MultipleChoiceViewModel()
        {
            PossibleAnswerAmount = new int[] { 2, 3, 4 };
            repository = new GenericRepository<MultipleChoice>(new FAPDatabaseEntities());
            answerRepository = new GenericRepository<MultiplechoiceAnswer>(new FAPDatabaseEntities());
            AddQuestionCommand = new RelayCommand(AddQuestionToDatabase);

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
            RedefineAmountOfAnswers();

            MultiplechoiceAnswer[] multiplechoiceAnswers = new MultiplechoiceAnswer[amountOfAnswers];
            repository.Insert(question);
            for(int i = 0; i < multiplechoiceAnswers.Length; i++)
            {
                answerRepository.Insert(multiplechoiceAnswers[i]);
            }
            RaisePropertyChanged("AllAnswers");

        }

        public void DeleteSelectedQuestionFromDatabase()
        {
            repository.Delete(SelectedQuestion);
        }

        public void RedefineAmountOfAnswers()
        {
            var list = answerRepository.Get(a => a.question_id == SelectedQuestion.Id).ToList();
            for(int i = 0; i < list.Count; i++)
            {
                answerRepository.Delete(list[i]);
            }
            

        }

        public void UpdateAnswer()
        {
            if (SelectedAnswer != null)
            {
                answerRepository.Update(SelectedAnswer);
            }
        }
    }
}
