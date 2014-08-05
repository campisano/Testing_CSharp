using NLayer.WPFMVVM.ViewModel;
using System.Windows;

namespace NLayer.WPFMVVM.View
{
    public partial class CustomerSearchView : Window
    {
        #region Constructors

        public CustomerSearchView()
        {
            InitializeComponent();

            DataContext = new CustomerSearchViewModel();
        }

        #endregion
    }
}
