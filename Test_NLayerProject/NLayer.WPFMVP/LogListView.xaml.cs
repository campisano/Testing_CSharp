﻿using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NLayer.WPFMVP
{
    public partial class LogListView : Window, I_LogListView
    {
        #region Constructors

        public LogListView()
        {
            InitializeComponent();

            new LogListPresenter(this);
        }

        #endregion

        #region I_LogListView

        public IList<string> Logs
        {
            get { return (IList<string>)xamlLogs.ItemsSource; }
            set { xamlLogs.ItemsSource = new ObservableCollection<string>(value); }
        }

        #endregion
    }
}
