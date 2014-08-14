using NLayer.WPFMVVM.ViewModel;
using System.Windows;

namespace NLayer.WPFMVVM.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }
    }
}
