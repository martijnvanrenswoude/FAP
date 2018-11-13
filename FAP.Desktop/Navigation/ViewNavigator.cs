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

        public View CurrentView => _viewHistory.Peek();

        public ViewNavigator(string homeView)
        {
            _viewHistory = new UniqueStack<View>();
            ChangeView(homeView);
        }

        public void ChangeView(string view)
        {
            switch (view)
            {
                case "Back": Back(); break;
                case "back": Back(); break;

                //case nameof(EventView):
                //    _viewHistory.Push(new EventView
                //    {
                //        DataContext = new EventViewModel(
                //          SimpleIoc.Default.GetInstance<GenericRepository<Event>>())
                //    });
                //    break;
            }
        }

        public void Back()
        {
            if (_viewHistory.Count > 1)
            {
                _viewHistory.Pop();
            }
        }
    }
}
