using Infragistics.Controls.Charts;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NLayer.WPFMVP
{
    public partial class LogDrawView : Window, I_LogDrawView, I_LogListView
    {
        #region Constructors

        public LogDrawView()
        {
            InitializeComponent();

            new LogDrawPresenter(this);
            new LogListPresenter(this);
        }

        #endregion

        #region Methods

        private void OnDraw(object sender, RoutedEventArgs e)
        {
            DoDraw.Execute();

            xamDataChart.Series.Clear();
            ScatterLineSeries serie = new ScatterLineSeries();
            serie.ItemsSource = Points;
            serie.YMemberPath = "Key";
            serie.XMemberPath = "Value";
            serie.XAxis = xamlXAxis;
            serie.YAxis = xamlYAxis;
            xamDataChart.Series.Add(serie);
        }

        #endregion

        #region I_LogDrawView

        public string LogName { get { return (string)xamlLogName.SelectedValue; } set { xamlLogName.SelectedValue = value; } }
        public I_Command DoDraw { get; set; }
        public string Color { get; set; }
        public int Thickness { get; set; }
        public IList<KeyValuePair<double, double>> Points { get; set; }

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
