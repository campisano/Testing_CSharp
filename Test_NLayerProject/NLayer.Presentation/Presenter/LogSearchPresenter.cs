using NLayer.Common.Pattern.Command;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Presentation.Presenter
{
    public class LogSearchPresenter
    {
        private LogService _service;
        private I_LogSearchView _view;

        #region Constructors

        public LogSearchPresenter(I_LogSearchView view)
        {
            _service = LogService.Instance;
            _view = view;
            _view.DoReset = new SimpleCommand(ShowAllLogsOperation);
            _view.DoSearch = new SimpleCommand(SearchLogOperation);
            _view.SearchQuery = "";
            _view.SearchResults = new List<string>();

            _view.DoReset.Execute();
        }

        #endregion

        #region Methods

        public void ShowAllLogsOperation()
        {
            _view.SearchResults.Clear();

            foreach (var item in _service.GetAllLogNames())
            {
                _view.SearchResults.Add(item);
            }
        }

        public void SearchLogOperation()
        {
            _view.SearchResults.Clear();

            IEnumerable<string> logNames;

            if (_view.SearchQuery.Trim().Equals(string.Empty))
            {
                logNames = _service.GetAllLogNames();
            }
            else
            {
                logNames = _service.SearchLogsByName(_view.SearchQuery);
            }

            foreach (var item in logNames)
            {
                _view.SearchResults.Add(item);
            }
        }

        #endregion
    }
}
