using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Windows;

namespace NLayer.WPFMVP
{
    public partial class MainWindow : Window, I_MainWindowView
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            new MainWindowPresenter(this);
        }

        #endregion

        #region Methods

        private void OnOpenLogSearch(object sender, RoutedEventArgs e)
        {
            DoOpenLogSearch.Execute();
        }

        private void OnOpenLogImport(object sender, RoutedEventArgs e)
        {
            DoOpenLogImport.Execute();
        }

        private void OnOpenLogList(object sender, RoutedEventArgs e)
        {
            DoOpenLogList.Execute();
        }

        private void OnOpenLogDraw(object sender, RoutedEventArgs e)
        {
            DoOpenLogDraw.Execute();
        }

        #endregion

        #region I_MainWindowView

        public I_Command DoOpenLogSearch { get; set; }
        public I_Command DoOpenLogImport { get; set; }
        public I_Command DoOpenLogList { get; set; }
        public I_Command DoOpenLogDraw { get; set; }

        #endregion
    }
}
