using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Test_IDataErrorInfo
{
    public partial class MainWindow : Window, IDataErrorInfo
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        public string Text { get; set; }

        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get {
                return (Text == "" ? "Text" : null);
            }
        }
    }
}