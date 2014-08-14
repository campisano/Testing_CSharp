using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Windows;

namespace NLayer.WPF
{
    public partial class MainWindow : Window, IMainWindowView
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            new MainWindowPresenter(this);
        }

        #endregion

        #region Methods

        private void OnOpenCustomerSearch(object sender, RoutedEventArgs e)
        {
            DoOpenCustomerSearch.Execute();
        }

        private void OnOpenImportLog(object sender, RoutedEventArgs e)
        {
            DoOpenImportLog.Execute();
        }

        private void OnOpenLogList(object sender, RoutedEventArgs e)
        {
            DoOpenLogList.Execute();
        }

        private void OnOpenDrawLog(object sender, RoutedEventArgs e)
        {
            DoOpenDrawLog.Execute();
        }

        #endregion

        #region IMainWindowView

        public ICommand DoOpenCustomerSearch { get; set; }
        public ICommand DoOpenImportLog { get; set; }
        public ICommand DoOpenLogList { get; set; }
        public ICommand DoOpenDrawLog { get; set; }

        #endregion
    }
}
