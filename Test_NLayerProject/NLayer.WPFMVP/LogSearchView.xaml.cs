using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NLayer.WPFMVP
{
    public partial class LogSearchView : Window, I_LogSearchView
    {
        #region Constructors

        public LogSearchView()
        {
            InitializeComponent();

            new LogSearchPresenter(this);
        }

        #endregion

        #region Methods

        private void OnResetClick(object sender, RoutedEventArgs e)
        {
            DoReset.Execute();
        }

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            DoSearch.Execute();
        }

        #endregion

        #region I_LogSearchView

        public string SearchQuery
        {
            get { return xamlSearchQuery.Text; }
            set { xamlSearchQuery.Text = value; }
        }

        public I_Command DoReset { get; set; }
        public I_Command DoSearch { get; set; }

        public IList<string> SearchResults
        {
            get { return (IList<string>)xamlSearchResults.ItemsSource; }
            set { xamlSearchResults.ItemsSource = new ObservableCollection<string>(value); }
        }

        #endregion
    }
}
