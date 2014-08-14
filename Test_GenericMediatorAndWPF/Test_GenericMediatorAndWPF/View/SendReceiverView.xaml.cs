using Test_GenericMediatorAndWPF.Common.Pattern.Command;
using System.Windows;
using System.Windows.Controls;
using Test_GenericMediatorAndWPF.Presenter;

namespace Test_GenericMediatorAndWPF.View
{
    public partial class SendReceiverView : UserControl, I_MessageSenderView, I_MessageReceiverView
    {
        #region Constructors

        public SendReceiverView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void OnSendMessage(object sender, RoutedEventArgs e)
        {
            DoSendMessage.Execute();
        }

        #endregion

        #region I_SendReceiverView

        public string MessageToSend { get { return xamlMessageToSend.Text; } set { xamlMessageToSend.Text = value; } }
        public I_Command DoSendMessage { get; set; }

        #endregion

        #region I_SendReceiverView

        public string ReceivedMessage { get { return xamlReceivedMessage.Text; } set { xamlReceivedMessage.Text = value; } }

        #endregion
    }
}
