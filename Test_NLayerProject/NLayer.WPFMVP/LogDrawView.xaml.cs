using Infragistics.Controls.Charts;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace NLayer.WPFMVP
{
    public partial class LogDrawView : Window, I_LogDrawView, I_LogListView
    {
        ScatterLineSeries _serie;

        #region Constructors

        public LogDrawView()
        {
            InitializeComponent();

            _serie = new ScatterLineSeries();
            _serie.MarkerType = MarkerType.None;
            _serie.YMemberPath = "Key";
            _serie.XMemberPath = "Value";
            _serie.XAxis = xamlXAxis;
            _serie.YAxis = xamlYAxis;
            xamDataChart.Series.Add(_serie);

            new LogDrawPresenter(this);
            new LogListPresenter(this);
        }

        #endregion

        #region Methods

        private void OnDraw(object sender, RoutedEventArgs e)
        {
            DoDraw.Execute();
        }

        #endregion

        #region I_LogDrawView

        public string LogName { get { return (string)xamlLogName.SelectedValue; } set { xamlLogName.SelectedValue = value; } }
        public I_Command DoDraw { get; set; }
        public string Color { get { return _serie.Brush.ToString(); } set { _serie.Brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value)); } }
        public int Thickness { get { return (int)_serie.Thickness; } set { _serie.Thickness = value; } }
        public IList<KeyValuePair<double, double>> Points { get { return (IList<KeyValuePair<double, double>>)_serie.ItemsSource; } set { _serie.ItemsSource = new ObservableCollection<KeyValuePair<double, double>>(value); } }

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
