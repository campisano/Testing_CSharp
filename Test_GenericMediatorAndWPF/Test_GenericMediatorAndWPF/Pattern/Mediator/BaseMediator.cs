using System.Collections.Generic;

namespace Test_GenericMediatorAndWPF.Pattern.Mediator
{
    public class BaseMediator : I_Mediator
    {
        private IDictionary<I_Mediable, object> _mediateds;

        #region Constructors

        public BaseMediator()
        {
            _mediateds = new Dictionary<I_Mediable, object>();
        }

        #endregion

        #region Methods

        public void Register(I_Mediable mediable, object type = null)
        {
            _mediateds.Add(mediable, type);
        }

        public void UnRegister(I_Mediable mediable)
        {
            _mediateds.Remove(mediable);
        }

        public void Send(object message, object type = null)
        {
            foreach (var mediated_pair in _mediateds)
            {
                if (mediated_pair.Value == null ||
                    mediated_pair.Value == type)
                {
                    mediated_pair.Key.Receive(message);
                }
            }
        }

        #endregion
    }
}
