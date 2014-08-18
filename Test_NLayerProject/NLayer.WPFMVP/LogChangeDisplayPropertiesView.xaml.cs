using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NLayer.WPFMVP
{
    public partial class LogChangeDisplayPropertiesView : Window, I_LogChangeDisplayPropertiesView, I_LogListView
    {
        #region Constructores

        public LogChangeDisplayPropertiesView()
        {
            InitializeComponent();

            new LogChangeDisplayPropertiesPresenter(this);
            new LogListPresenter(this);
        }

        #endregion

        #region Methods

        private void OnChange(object sender, RoutedEventArgs e)
        {
            DoChange.Execute();
        }

        #endregion

        #region I_LogChangeDisplayPropertiesView

        public string LogName { get { return (string)xamlLogName.SelectedValue; } set { xamlLogName.SelectedValue = value; } }
        public string LogColor { get { return (string)xamlLogColor.SelectedValue; } set { xamlLogColor.SelectedValue = value; } }
        public int LogThickness { get { return int.Parse((string)xamlLogThickness.SelectedValue); } set { xamlLogThickness.SelectedValue = value; } }
        public I_Command DoChange { get; set; }

        #endregion

        #region I_LogListView

        public IList<string> Logs
        {
            get { return (IList<string>)xamlLogName.ItemsSource; }
            set { xamlLogName.ItemsSource = new ObservableCollection<string>(value); }
        }

        #endregion
    }
}
