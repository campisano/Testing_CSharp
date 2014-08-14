using Infragistics.Controls.Charts;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace NLayer.WPFMVP
{
    public partial class LogDrawView : Window, I_LogDrawView
    {
        #region Constructors

        public LogDrawView()
        {
            InitializeComponent();

            new LogDrawPresenter(this);
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

        public string LogName { get { return xamlLogName.Text; } set { xamlLogName.Text = value; } }
        public I_Command DoDraw { get; set; }
        public string Color { get; set; }
        public int Thickness { get; set; }
        public IList<KeyValuePair<double, double>> Points { get; set; }

        #endregion
    }
}
