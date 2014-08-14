using System.Windows;
using Test_GenericMediatorAndWPF.Presenter;

namespace Test_GenericMediatorAndWPF.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOpenWindow(object sender, RoutedEventArgs e)
        {
            Window w = new Window();
            w.Height = 100;
            w.Width = 300;
            SendReceiverView view = new SendReceiverView();
            new MessageSenderPresenter(view);
            new MessageReceiverPresenter(view);
            w.Content = view;
            w.Show();
        }
    }
}
