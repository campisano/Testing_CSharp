using Test_GenericMediatorAndWPF.Common.Pattern.Command;
using Test_GenericMediatorAndWPF.Service;

namespace Test_GenericMediatorAndWPF.Presenter
{
    public class MessageSenderPresenter
    {
        private MessageService _service;
        private I_MessageSenderView _view;

        #region Constructors

        public MessageSenderPresenter(I_MessageSenderView view)
        {
            _service = MessageService.Instance;
            _view = view;
            _view.DoSendMessage = new SimpleCommand(SendMessageOperation);
        }

        #endregion

        #region Methods

        public void SendMessageOperation()
        {
            _service.Send(_view.MessageToSend);
            _view.MessageToSend = string.Empty;
        }

        #endregion
    }
}
