using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Test_CustomGridAlternatingColor
{
    public class AlternatingColorGrid : Grid
    {
        #region Properties

        public static readonly DependencyProperty OddRowColorProperty =
            DependencyProperty.Register("OddRowColor", typeof(Brush), typeof(AlternatingColorGrid), new UIPropertyMetadata(Brushes.Transparent));

        public Brush OddRowColor
        {
            get { return (Brush)GetValue(OddRowColorProperty); }
            set { SetValue(OddRowColorProperty, value); }
        }

        public static readonly DependencyProperty EvenRowColorProperty =
            DependencyProperty.Register("EvenRowColor", typeof(Brush), typeof(AlternatingColorGrid), new UIPropertyMetadata(Brushes.Transparent));

        public Brush EvenRowColor
        {
            get { return (Brush)GetValue(EvenRowColorProperty); }
            set { SetValue(EvenRowColorProperty, value); }
        }

        public bool ShowCustomGridLines
        {
            get { return (bool)GetValue(ShowCustomGridLinesProperty); }
            set { SetValue(ShowCustomGridLinesProperty, value); }
        }

        public static readonly DependencyProperty ShowCustomGridLinesProperty =
            DependencyProperty.Register("ShowCustomGridLines", typeof(bool), typeof(AlternatingColorGrid), new UIPropertyMetadata(false));

        public Brush GridLineBrush
        {
            get { return (Brush)GetValue(GridLineBrushProperty); }
            set { SetValue(GridLineBrushProperty, value); }
        }

        public static readonly DependencyProperty GridLineBrushProperty =
            DependencyProperty.Register("GridLineBrush", typeof(Brush), typeof(AlternatingColorGrid), new UIPropertyMetadata(Brushes.Black));

        public double GridLineThickness
        {
            get { return (double)GetValue(GridLineThicknessProperty); }
            set { SetValue(GridLineThicknessProperty, value); }
        }

        public static readonly DependencyProperty GridLineThicknessProperty =
            DependencyProperty.Register("GridLineThickness", typeof(double), typeof(AlternatingColorGrid), new UIPropertyMetadata(1.0));
        #endregion

        protected override void OnRender(DrawingContext dc)
        {
            if (!(OddRowColor.Equals(Brushes.Transparent) && EvenRowColor.Equals(Brushes.Transparent)))
            {
                int i = 0;

                foreach (var rowDefinition in RowDefinitions)
                {
                    ++i;
                    dc.DrawRectangle((i % 2 == 0) ? (OddRowColor) : (EvenRowColor), null, new Rect(0, rowDefinition.Offset, ActualWidth, ActualHeight));
                }
            }


            if (ShowCustomGridLines)
            {
                foreach (var rowDefinition in RowDefinitions)
                {
                    dc.DrawLine(new Pen(GridLineBrush, GridLineThickness), new Point(0, rowDefinition.Offset), new Point(ActualWidth, rowDefinition.Offset));
                }

                foreach (var columnDefinition in ColumnDefinitions)
                {
                    dc.DrawLine(new Pen(GridLineBrush, GridLineThickness), new Point(columnDefinition.Offset, 0), new Point(columnDefinition.Offset, ActualHeight));
                }
                dc.DrawRectangle(Brushes.Transparent, new Pen(GridLineBrush, GridLineThickness), new Rect(0, 0, ActualWidth, ActualHeight));
            }

            base.OnRender(dc);
        }
        static AlternatingColorGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AlternatingColorGrid), new FrameworkPropertyMetadata(typeof(AlternatingColorGrid)));
        }
    }
}
