using Test_GenericMediatorAndWPF.Common.Pattern.Command;

namespace Test_GenericMediatorAndWPF.Presenter
{
    public interface I_MessageSenderView
    {
        string MessageToSend { get; set; }
        I_Command DoSendMessage { get; set; }
    }
}
