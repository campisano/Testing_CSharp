namespace Test_GenericMediatorAndWPF.Pattern.Mediator
{
    public interface I_Mediator
    {
        void Register(I_Mediable mediable, object type = null);
        void UnRegister(I_Mediable mediable);
        void Send(object message, object type = null);
    }
}
