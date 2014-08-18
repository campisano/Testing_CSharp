using NLayer.Common.Pattern.Command;
using NLayer.Common.Pattern.Mediator;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Domain.Service.SystemOperation.Message;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Presentation.Presenter
{
    public class LogSearchPresenter : BaseMediable
    {
        private MessageService _message_service;
        private LogService _log_service;
        private I_LogSearchView _view;

        #region Constructors

        public LogSearchPresenter(I_LogSearchView view)
        {
            _message_service = MessageService.Instance;
            _message_service.Register(this, typeof(MessageLogImported));
            MediableFunction = UpdateList;
            _log_service = LogService.Instance;
            _view = view;
            _view.DoReset = new SimpleCommand(ShowAllLogsOperation);
            _view.DoSearch = new SimpleCommand(SearchLogOperation);
            _view.SearchQuery = string.Empty;
            _view.SearchResults = new List<string>();

            _view.DoReset.Execute();
        }

        #endregion

        #region Methods

        public void ShowAllLogsOperation()
        {
            _view.SearchQuery = string.Empty;
            _view.SearchResults.Clear();

            foreach (var item in _log_service.GetAllLogNames())
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
                logNames = _log_service.GetAllLogNames();
            }
            else
            {
                logNames = _log_service.SearchLogsByName(_view.SearchQuery);
            }

            foreach (var item in logNames)
            {
                _view.SearchResults.Add(item);
            }
        }

        public void UpdateList(object message)
        {
            SearchLogOperation();
        }

        #endregion
    }
}
