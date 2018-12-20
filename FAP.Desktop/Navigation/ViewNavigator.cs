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

                case nameof(TestView):
                    _viewHistory.Push(new TestView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<TestViewModel>()
                    });
                    break;

                case nameof(TestViewOther):
                    _viewHistory.Push(new TestViewOther
                    {
                        DataContext = SimpleIoc.Default.GetInstance<TestOtherViewModel>()
                    });
                    break;

                case nameof(InvoiceView):
                    _viewHistory.Push(new InvoiceView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<InvoiceViewModel>()
                    });
                    break;

                case nameof(CreateInvoiceView):
                    _viewHistory.Push(new CreateInvoiceView
                    {
                        DataContext = SimpleIoc.Default.GetInstance<CreateInvoiceViewModel>()
                    });
                    break;

                default: throw new ArgumentException("Non existend view passed in arguments.");
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
