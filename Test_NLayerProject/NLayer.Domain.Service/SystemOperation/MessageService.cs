using NLayer.Common.Pattern.Mediator;

namespace NLayer.Domain.Service.SystemOperation
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
    }
}
