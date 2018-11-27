using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class EditQuestionViewModel
    {
        GenericRepository<Question> _questionRepository;
        GenericRepository<QuestionType> _questionTypeRepository;

        public ObservableCollection<QuestionType> QuestionTypes { get; set; }

        public Question Question { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public EditQuestionViewModel(GenericRepository<Question> questionRepository, GenericRepository<QuestionType> questionTypeRepository)
        {
            _questionRepository = questionRepository;
            _questionTypeRepository = questionTypeRepository;

            QuestionTypes = new ObservableCollection<QuestionType>(_questionTypeRepository.Get());
            Question = _questionRepository.Get().FirstOrDefault();
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            _questionRepository.Update(Question);
        }
    }
}
