using NLayer.Common.Pattern.Mediator;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Domain.Service.SystemOperation.Message;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Presentation.Presenter
{
    public class LogListPresenter : BaseMediable
    {
        private MessageService _message_service;
        private LogService _log_service;
        private I_LogListView _view;

        #region Constructors

        public LogListPresenter(I_LogListView view)
        {
            _message_service = MessageService.Instance;
            _message_service.Register(this, typeof(MessageLogImported));
            MediableFunction = UpdateList;
            _log_service = LogService.Instance;
            _view = view;
            _view.Logs = new List<string>();
            Open();
        }

        #endregion

        #region Methods

        public void Open()
        {
            _view.Logs.Clear();

            foreach (var item in _log_service.GetAllLogNames())
            {
                _view.Logs.Add(item);
            }
        }

        public void UpdateList(object message)
        {
            MessageLogImported msg = (MessageLogImported)message;

            _view.Logs.Add(msg.getLogName());
        }

        #endregion
    }
}
