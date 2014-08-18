using System;

namespace NLayer.Common.Pattern.Mediator
{
    public interface I_Mediator
    {
        void Register(I_Mediable mediable, Type type = null);
        void UnRegister(I_Mediable mediable);
        void Send(object message, Type type = null);
    }
}
