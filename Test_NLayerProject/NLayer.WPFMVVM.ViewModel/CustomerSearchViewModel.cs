using NLayer.Common.MVVM;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MVVMCommand = System.Windows.Input;
using PatternsCommand = NLayer.Common.Pattern.Command;

namespace NLayer.WPFMVVM.ViewModel
{
    public class CustomerSearchViewModel : ObservableObject, ICustomerSearchView
    {
        #region Properties

        private MVVMCommand.ICommand _onDoReset;
        public MVVMCommand.ICommand OnDoReset
        {
            get { return _onDoReset ?? (_onDoReset = new RelayCommand(param => DoReset.Execute())); }
        }

        private MVVMCommand.ICommand _onDoSearch;
        public MVVMCommand.ICommand OnDoSearch
        {
            get { return _onDoSearch ?? (_onDoSearch = new RelayCommand(param => DoSearch.Execute())); }
        }

        #endregion

        #region Constructors

        public CustomerSearchViewModel()
        {
            new CustomerSearchPresenter(this);
        }

        #endregion

        #region ICustomerSearchView

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { _searchQuery = value; RaisePropertyChanged(() => SearchQuery); }
        }

        public PatternsCommand.ICommand DoReset { get; set; }
        public PatternsCommand.ICommand DoSearch { get; set; }

        private IList<string> _searchResults;
        public IList<string> SearchResults
        {
            get { return _searchResults; }
            set { _searchResults = new ObservableCollection<string>(value); RaisePropertyChanged(() => SearchResults); }
        }

        #endregion
    }
}
