namespace NLayer.Common.Pattern.Mediator
{
    public interface I_Mediable
    {
        void Receive(object message);
        void SetMediator(I_Mediator mediator);
        void UnSetMediator();
    }
}
