﻿using FAP.Desktop.Navigation;
using FAP.Desktop.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class DataBeheerViewModel
    {
        //command
        public RelayCommand GoToHomeViewCommand { get; set; }
        public RelayCommand GoToKlantBeheerViewCommand { get; set; }

        public DataBeheerViewModel()
        {
            GoToHomeViewCommand = new RelayCommand(GoToHomeView);
            GoToKlantBeheerViewCommand = new RelayCommand(GoToKlantBeheerView);
        }

        private void GoToHomeView()
        {
            ViewNavigator.Navigate(nameof(HomeView));
        }
        private void GoToKlantBeheerView()
        {
            ViewNavigator.Navigate(nameof(KlantBeheerView));
        }
    }
}