using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Windows;

namespace NLayer.WPF
{
    public partial class ImportLogView : Window, IImportLogView
    {
        #region Constructors

        public ImportLogView()
        {
            InitializeComponent();

            new ImportLogPresenter(this);
        }

        #endregion

        #region Methods

        private void OnImport(object sender, RoutedEventArgs e)
        {
            DoImport.Execute();
        }

        #endregion

        #region IImportLogView

        public string InputFilePath { get { return xamlPath.Text; } set { xamlPath.Text = value; } }
        public string LogName { get { return xamlName.Text; } set { xamlName.Text = value; } }
        public Common.Pattern.Command.ICommand DoImport { get; set; }
        public string MessageResult { get { return xamlMessage.Text; } set { xamlMessage.Text = value; } }

        #endregion
    }
}
