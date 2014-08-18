using Microsoft.Win32;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System;
using System.Windows;

namespace NLayer.WPFMVP
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

        private void OnChooseFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".dat";
            dlg.Filter = "SestTR exported dataset (.dat)|*.dat";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                xamlPath.Text = dlg.FileName;
            }
            else
            {
                xamlPath.Text = string.Empty;
            }
        }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
