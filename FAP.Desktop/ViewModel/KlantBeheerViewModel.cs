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
    public class KlantBeheerViewModel
    {
        public RelayCommand GoBackViewCommand { get; set; }

        public KlantBeheerViewModel()
        {
            GoBackViewCommand = new RelayCommand(GoBackView);
        }

        private void GoBackView()
        {
            ViewNavigator.Navigate("back");
        }
    }
}