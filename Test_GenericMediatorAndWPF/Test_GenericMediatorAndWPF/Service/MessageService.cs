using Test_GenericMediatorAndWPF.Pattern.Mediator;

namespace Test_GenericMediatorAndWPF.Service
{
    public class MessageService : BaseMediator
    {
        private static MessageService _instance;

        #region Properties

        public static MessageService Instance
        {
            get { if (_instance == null) _instance = new MessageService(); return _instance; }
        }

        #endregion

        #region Constructors

        private MessageService()
        {
        }

        #endregion

        #region Methods

        #region public

        #endregion

        #region private

        #endregion

        #endregion
    }
}
