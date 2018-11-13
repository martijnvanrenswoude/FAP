using System.Collections.Generic;
using System.Windows;
using FAP.Desktop.Message;
using FAP.Desktop.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

namespace FAP.Desktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewNavigator _navigator;

        public FrameworkElement ViewNavigator => _navigator.CurrentView;


        public MainViewModel()
        {
            _navigator = new ViewNavigator(/* nameof(HomeView) */ "HomeView");

            Messenger.Default.Register<NavigationMessage>(this, (message) =>
            {
                _navigator.ChangeView(message.View);
            });
        }
    }
}