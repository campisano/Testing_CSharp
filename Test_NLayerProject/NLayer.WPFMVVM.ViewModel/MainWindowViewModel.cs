using NLayer.Common.MVVM;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using MVVMCommand = System.Windows.Input;

namespace NLayer.WPFMVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject, IMainWindowView
    {
        #region Properties

        private MVVMCommand.ICommand _onOpenCustomerSearch;
        public MVVMCommand.ICommand OnOpenCustomerSearch
        {
            get { return _onOpenCustomerSearch ?? (_onOpenCustomerSearch = new RelayCommand(param => DoOpenCustomerSearch.Execute())); }
        }

        private MVVMCommand.ICommand _onOpenImportLog;
        public MVVMCommand.ICommand OnOpenImportLog
        {
            get { return _onOpenImportLog ?? (_onOpenImportLog = new RelayCommand(param => DoOpenImportLog.Execute())); }
        }

        private MVVMCommand.ICommand _onOpenLogList;
        public MVVMCommand.ICommand OnOpenLogList
        {
            get { return _onOpenLogList ?? (_onOpenLogList = new RelayCommand(param => DoOpenLogList.Execute())); }
        }

        private MVVMCommand.ICommand _onOpenDrawLog;
        public MVVMCommand.ICommand OnOpenDrawLog
        {
            get { return _onOpenDrawLog ?? (_onOpenDrawLog = new RelayCommand(param => DoOpenDrawLog.Execute())); }
        }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            new MainWindowPresenter(this);
        }

        #endregion

        #region IMainWindowView

        public Common.Pattern.Command.ICommand DoOpenCustomerSearch { get; set; }
        public Common.Pattern.Command.ICommand DoOpenImportLog { get; set; }
        public Common.Pattern.Command.ICommand DoOpenLogList { get; set; }
        public Common.Pattern.Command.ICommand DoOpenDrawLog { get; set; }

        #endregion
    }
}
