using Test_GenericMediatorAndWPF.Pattern.Mediator;
using Test_GenericMediatorAndWPF.Service;

namespace Test_GenericMediatorAndWPF.Presenter
{
    public class MessageReceiverPresenter : BaseMediable
    {
        private MessageService _service;
        private I_MessageReceiverView _view;

        #region Constructors

        public MessageReceiverPresenter(I_MessageReceiverView view)
        {
            _service = MessageService.Instance;
            _service.Register(this);
            _view = view;

            Function = ReceiveMessageOperation;
        }

        #endregion

        #region Methods

        public void ReceiveMessageOperation(object message)
        {
            _view.ReceivedMessage = (string)message;
        }

        #endregion
    }
}
