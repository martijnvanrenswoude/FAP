using System.Collections.Generic;
using System.Windows;
using FAP.Desktop.Message;
using FAP.Desktop.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using FAP.Desktop.View;

namespace FAP.Desktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewNavigator _navigator;
        
        public FrameworkElement CurrentView => _navigator.CurrentView;
        
        public MainViewModel()
        {
            _navigator = new ViewNavigator(nameof(QuestionView));

            Messenger.Default.Register<NavigationMessage>(this, (message) =>
            {
                _navigator.ChangeView(message.View);
                RaisePropertyChanged(() => CurrentView);
            });

            RaisePropertyChanged(() => CurrentView);
        }
        
    }
}