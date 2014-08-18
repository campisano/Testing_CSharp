using NLayer.Common.Pattern.Command;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Domain.Service.SystemOperation.Message;
using NLayer.Presentation.IView;

namespace NLayer.Presentation.Presenter
{
    public class LogChangeDisplayPropertiesPresenter
    {
        private MessageService _message_service;
        private LogService _log_service;
        private I_LogChangeDisplayPropertiesView _view;

        #region Constructors

        public LogChangeDisplayPropertiesPresenter(I_LogChangeDisplayPropertiesView view)
        {
            _message_service = MessageService.Instance;
            _log_service = LogService.Instance;
            _view = view;
            _view.LogName = string.Empty;
            _view.LogColor = "Black";
            _view.LogThickness = 1;
            _view.DoChange = new SimpleCommand(LogChangeDisplayProperties);
        }

        #endregion

        #region Methods

        private void LogChangeDisplayProperties()
        {
            _log_service.SetLogApparence(_view.LogName, _view.LogColor, _view.LogThickness); //TODO [CMP] enum seem better for color and thickness too
            _message_service.Send(new MessageLogApparenceChanged(_view.LogName), typeof(MessageLogApparenceChanged));
        }

        #endregion
    }
}
