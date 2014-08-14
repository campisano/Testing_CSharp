namespace Test_GenericMediatorAndWPF.Pattern.Mediator
{
    public class BaseMediable : I_Mediable
    {
        private I_Mediator _mediator;
        public delegate void MediableReceiveFunction(object message);

        #region Properties

        public MediableReceiveFunction Function { get; set; }

        #endregion

        #region Constructors

        public BaseMediable()
        {
        }

        #endregion

        #region Methods

        public void SetMediator(I_Mediator mediator)
        {
            _mediator = mediator;
        }

        public void UnSetMediator()
        {
            _mediator = null;
        }

        public void Receive(object message)
        {
            if (Function != null)
            {
                Function(message);
            }
        }

        public void SendMessage(object message, object type = null)
        {
            _mediator.Send(message, type);
        }

        #endregion
    }
}
