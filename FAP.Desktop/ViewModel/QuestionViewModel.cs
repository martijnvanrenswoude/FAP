using FAP.Desktop.Message;
using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class QuestionViewModel : ViewModelBase
    {
        GenericRepository<Question> _repository;

        public Question SelectedQuestion { get; set; }
        public ObservableCollection<Question> Questions { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }

        public QuestionViewModel(GenericRepository<Question> repository)
        {
            _repository = repository;
            Questions = new ObservableCollection<Question>(_repository.Get());

            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
        }

        public void Delete()
        {
            _repository.Delete(SelectedQuestion);
            Questions.Remove(Questions.FirstOrDefault(q => q == SelectedQuestion));
        }

        private void Edit()
        {
            ViewNavigator.Navigate(nameof(EditQuestionView));
        }

        private void Add()
        {
            ViewNavigator.Navigate(nameof(AddQuestionView));
        }
    }
}
