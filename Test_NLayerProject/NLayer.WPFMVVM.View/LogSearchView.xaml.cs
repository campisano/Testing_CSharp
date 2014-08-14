using NLayer.WPFMVVM.ViewModel;
using System.Windows;

namespace NLayer.WPFMVVM.View
{
    public partial class LogSearchView : Window
    {
        #region Constructors

        public LogSearchView()
        {
            InitializeComponent();

            DataContext = new LogSearchViewModel();
        }

        #endregion
    }
}
