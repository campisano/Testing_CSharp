using NLayer.Common.MVVM;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NLayer.WPFMVVM.ViewModel
{
    public class LogSearchViewModel : ObservableObject, I_LogSearchView
    {
        #region Properties

        private ICommand _onDoReset;
        public ICommand OnDoReset
        {
            get { return _onDoReset ?? (_onDoReset = new RelayCommand(param => DoReset.Execute())); }
        }

        private ICommand _onDoSearch;
        public ICommand OnDoSearch
        {
            get { return _onDoSearch ?? (_onDoSearch = new RelayCommand(param => DoSearch.Execute())); }
        }

        #endregion

        #region Constructors

        public LogSearchViewModel()
        {
            new LogSearchPresenter(this);
        }

        #endregion

        #region I_LogSearchView

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { _searchQuery = value; RaisePropertyChanged(() => SearchQuery); }
        }

        public I_Command DoReset { get; set; }
        public I_Command DoSearch { get; set; }

        private IList<string> _searchResults;
        public IList<string> SearchResults
        {
            get { return _searchResults; }
            set { _searchResults = new ObservableCollection<string>(value); RaisePropertyChanged(() => SearchResults); }
        }

        #endregion
    }
}
