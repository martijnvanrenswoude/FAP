using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FAP.Desktop.Message;
using FAP.Desktop.ViewModel;
using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using FAP.Desktop.View;
using FAP.Desktop.View.Planning;

namespace FAP.Desktop.Navigation
{
    // typedef
    using View = FrameworkElement;

    internal class UniqueStack<T> : Stack<T>
    {
        public new T Pop()
        {
            return base.Pop();
        }

        public new void Push(T t)
        {
            if (ToArray().Any(o => o.GetType() == typeof(T)))
            {
                return;
            }

            base.Push(t);
        }

        public new T Peek()
        {
            return base.Peek();
        }
    }

    internal sealed class ViewNavigator
    {
        private readonly UniqueStack<View> _viewHistory;

        public View CurrentView => (_viewHistory.Count > 0) ? _viewHistory.Peek() : null;
            

        public ViewNavigator(string viewname)
        {
            _viewHistory = new UniqueStack<View>();
            ChangeView(viewname);
        }

        public void ChangeView(string view)
        {
            HideView();

            //Als je hier een exception krijgt over TargetInvocation, check dan ff of het repository object geregistreert staat in de ViewModelLocator
            switch (view)
            {
                case "Back": Back(); break;
                case "back": Back(); break;

                case nameof(HomeView):
                    _viewHistory.Push(new HomeView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<HomeViewModel>()
                    });
                    break;
                case nameof(SettingsView):
                    _viewHistory.Push(new SettingsView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<SettingsViewModel>()
                    });
                    break;
                case nameof(RapportagesView):
                    _viewHistory.Push(new RapportagesView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<RapportagesViewModel>()
                    });
                    break;
                case nameof(DataBeheerView):
                    _viewHistory.Push(new DataBeheerView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<DataBeheerViewModel>()
                    });
                    break;
                case nameof(KlantBeheerView):
                    _viewHistory.Push(new KlantBeheerView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<KlantBeheerViewModel>()
                    });
                    break;
                case nameof(LoginView):
                    _viewHistory.Push(new LoginView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<LoginViewModel>()
                    });
                    break;
                case nameof(PlanningBeheerView): _viewHistory.Push(new PlanningBeheerView()); break;
                case nameof(PlanningCreateView): _viewHistory.Push(new PlanningCreateView()); break;
                case nameof(PlanningUpdateView): _viewHistory.Push(new PlanningUpdateView()); break;

                default: throw new ArgumentException("Non existend view passed in arguments. Is the requested view registered above?");
            }

            ShowView();
        }

        private void HideView()
        {
            if (CurrentView != null)
            {
                (CurrentView.DataContext as ITransitionable)?.Hide();
            }
        }

        private void ShowView()
        {
            if (CurrentView != null)
            {
                (CurrentView.DataContext as ITransitionable)?.Show();
            }
        }

        public void Back()
        {
            if (_viewHistory.Count > 1)
            {
                _viewHistory.Pop();
            }
        }
        
        public static void Navigate(string name)
        {
            Messenger.Default.Send(new NavigationMessage
            {
                View = name
            });
        }
    }
}
