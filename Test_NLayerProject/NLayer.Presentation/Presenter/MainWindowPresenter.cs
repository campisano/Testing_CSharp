using NLayer.Common.MVVM;
using NLayer.Common.Pattern;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;

namespace NLayer.Presentation.Presenter
{
    public class MainWindowPresenter
    {
        private IDialogService _service;
        private IMainWindowView _view;

        #region Constructors

        public MainWindowPresenter(IMainWindowView view)
        {
            _service = IODContainer.Instance.Resolve<IDialogService>(typeof(IDialogService));
            _view = view;
            _view.DoOpenCustomerSearch = new SimpleCommand(OpenCustomerSearch);
            _view.DoOpenImportLog = new SimpleCommand(OpenImportLog);
            _view.DoOpenLogList = new SimpleCommand(OpenLogList);
            _view.DoOpenDrawLog = new SimpleCommand(OpenDrawLog);
        }

        #endregion

        #region Methods

        public void OpenCustomerSearch()
        {
            _service.ShowWindow(typeof(ICustomerSearchView), false);
        }

        public void OpenImportLog()
        {
            _service.ShowWindow(typeof(IImportLogView), false);
        }

        public void OpenLogList()
        {
            _service.ShowWindow(typeof(ILogListView), false);
        }

        public void OpenDrawLog()
        {
            _service.ShowWindow(typeof(IDrawLogView), false);
        }

        #endregion
    }
}
