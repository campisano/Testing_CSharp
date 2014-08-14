using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NLayer.WPF
{
    public partial class CustomerSearchView : Window, ICustomerSearchView
    {
        #region Constructors

        public CustomerSearchView()
        {
            InitializeComponent();

            new CustomerSearchPresenter(this);
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

        #region ICustomerSearchView

        public string SearchQuery
        {
            get { return xamlSearchQuery.Text; }
            set { xamlSearchQuery.Text = value; }
        }

        public ICommand DoReset { get; set; }
        public ICommand DoSearch { get; set; }

        public IList<string> SearchResults
        {
            get { return (IList<string>)xamlSearchResults.ItemsSource; }
            set { xamlSearchResults.ItemsSource = new ObservableCollection<string>(value); }
        }

        #endregion
    }
}
