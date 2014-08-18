using System;
using System.Collections.Generic;

namespace NLayer.Common.Pattern.Mediator
{
    public class BaseMediator : I_Mediator
    {
        private IDictionary<I_Mediable, Type> _mediateds;

        #region Constructors

        public BaseMediator()
        {
            _mediateds = new Dictionary<I_Mediable, Type>();
        }

        #endregion

        #region Methods

        public void Register(I_Mediable mediable, Type type = null)
        {
            _mediateds.Add(mediable, type);
        }

        public void UnRegister(I_Mediable mediable)
        {
            _mediateds.Remove(mediable);
        }

        public void Send(object message, Type type = null)
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
