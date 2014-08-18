using NLayer.Common.Pattern.Command;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Domain.Service.SystemOperation.Message;
using NLayer.Presentation.IView;

namespace NLayer.Presentation.Presenter
{
    public class LogImportPresenter
    {
        private MessageService _message_service;
        private LogService _log_service;
        private I_LogImportView _view;

        #region Constructors

        public LogImportPresenter(I_LogImportView view)
        {
            _message_service = MessageService.Instance;
            _log_service = LogService.Instance;
            _view = view;
            _view.InputFilePath = string.Empty;
            _view.LogName = string.Empty;
            _view.DoImport = new SimpleCommand(ImportOperation);
            _view.MessageResult = string.Empty;
        }

        #endregion

        #region Methods

        public void ImportOperation()
        {
            string logName = _view.LogName.Trim();
            string inputFilePath = _view.InputFilePath.Trim();

            if (logName.Equals(string.Empty))
            {
                _view.MessageResult = "Choose a log name!";
            }
            else if (!_log_service.IsNewLogNameValid(logName))
            {
                _view.MessageResult = "Log name invalid!";
            }
            else if (!_log_service.IsLogImportFilePathValid(inputFilePath))
            {
                _view.MessageResult = "Log file path invalid!";
            }
            else
            {
                if (_log_service.Import(inputFilePath, logName))
                {
                    _view.MessageResult = "Log imported: " + _log_service.GetLogPointsNum(logName) + " points.";

                    //TODO [CMP] todefine: _log_service.Import can be used to notify the MessageLogImported, is it better?
                    MessageLogImported msg = new MessageLogImported(logName);
                    _message_service.Send(msg, typeof(MessageLogImported));
                }
                else
                {
                    _view.MessageResult = "Log import error!";
                }
            }
        }

        #endregion
    }
}
