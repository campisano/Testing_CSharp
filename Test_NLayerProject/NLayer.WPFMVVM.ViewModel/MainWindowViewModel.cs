using NLayer.Common.MVVM;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using System.Windows.Input;

namespace NLayer.WPFMVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject, I_MainWindowView
    {
        #region Properties

        private ICommand _onOpenLogSearch;
        public ICommand OnOpenLogSearch
        {
            get { return _onOpenLogSearch ?? (_onOpenLogSearch = new RelayCommand(param => DoOpenLogSearch.Execute())); }
        }

        private ICommand _onOpenLogImport;
        public ICommand OnOpenLogImport
        {
            get { return _onOpenLogImport ?? (_onOpenLogImport = new RelayCommand(param => DoOpenLogImport.Execute())); }
        }

        private ICommand _onOpenLogList;
        public ICommand OnOpenLogList
        {
            get { return _onOpenLogList ?? (_onOpenLogList = new RelayCommand(param => DoOpenLogList.Execute())); }
        }

        private ICommand _onOpenLogDraw;
        public ICommand OnOpenLogDraw
        {
            get { return _onOpenLogDraw ?? (_onOpenLogDraw = new RelayCommand(param => DoOpenLogDraw.Execute())); }
        }

        private ICommand _onOpenLogChangeDisplayProps;
        public ICommand OnOpenLogChangeDisplayProps
        {
            get { return _onOpenLogChangeDisplayProps ?? (_onOpenLogChangeDisplayProps = new RelayCommand(param => DoOpenLogChangeDisplayProps.Execute())); }
        }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            new MainWindowPresenter(this);
        }

        #endregion

        #region I_MainWindowView

        public I_Command DoOpenLogSearch { get; set; }
        public I_Command DoOpenLogImport { get; set; }
        public I_Command DoOpenLogList { get; set; }
        public I_Command DoOpenLogDraw { get; set; }
        public I_Command DoOpenLogChangeDisplayProps { get; set; }

        #endregion
    }
}
