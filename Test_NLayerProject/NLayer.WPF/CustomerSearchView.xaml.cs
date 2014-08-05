using NLayer.Common.Pattern.Command;
using NLayer.Presentation;
using System.Collections.Generic;
using System.Windows;

namespace NLayer.WPF
{
    public partial class CustomerSearchView : Window, ICustomerSearchView
    {
        public CustomerSearchView()
        {
            InitializeComponent();

            new CustomerSearchPresenter(this);
        }

        private void OnResetClick(object sender, RoutedEventArgs e)
        {
            DoReset.Execute();
        }

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            DoSearch.Execute();
        }

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
            set { xamlSearchResults.ItemsSource = value; }
        }

        #endregion
    }
}
