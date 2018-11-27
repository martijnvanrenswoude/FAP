using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using FAP.Domain;
using FAP.Repository;
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
    public class QuestionnaireViewModel : ViewModelBase
    {

        GenericRepository<Questionnaire> _repository;

        public Questionnaire SelectedQuestionnaire { get; set; }
        public ObservableCollection<Questionnaire> Questionnaires { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }

        public QuestionnaireViewModel(GenericRepository<Questionnaire> repository)
        {
            _repository = repository;

            Questionnaires = new ObservableCollection<Questionnaire>(_repository.Get());

            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
        }

        public void Delete()
        {
            _repository.Delete(SelectedQuestionnaire);
            Questionnaires.Remove(Questionnaires.FirstOrDefault(q => q == SelectedQuestionnaire));
        }

        private void Edit()
        {
            // Niente
        }

        private void Add()
        {
            ViewNavigator.Navigate(nameof(AddQuestionnaireView));
        }
    }
}