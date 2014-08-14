using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Windows;

namespace NLayer.WPF
{
    public partial class LogImportView : Window, I_LogImportView
    {
        #region Constructors

        public LogImportView()
        {
            InitializeComponent();

            new LogImportPresenter(this);
        }

        #endregion

        #region Methods

        private void OnImport(object sender, RoutedEventArgs e)
        {
            DoImport.Execute();
        }

        #endregion

        #region I_LogImportView

        public string InputFilePath { get { return xamlPath.Text; } set { xamlPath.Text = value; } }
        public string LogName { get { return xamlName.Text; } set { xamlName.Text = value; } }
        public I_Command DoImport { get; set; }
        public string MessageResult { get { return xamlMessage.Text; } set { xamlMessage.Text = value; } }

        #endregion
    }
}
