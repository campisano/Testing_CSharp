using NLayer.Common.MVVM;
using NLayer.Common.Pattern;
using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;

namespace NLayer.Presentation.Presenter
{
    public class MainWindowPresenter
    {
        private I_DialogService _service;
        private I_MainWindowView _view;

        #region Constructors

        public MainWindowPresenter(I_MainWindowView view)
        {
            _service = IODContainer.Instance.Resolve<I_DialogService>(typeof(I_DialogService));
            _view = view;
            _view.DoOpenLogSearch = new SimpleCommand(OpenLogSearch);
            _view.DoOpenLogImport = new SimpleCommand(OpenLogImport);
            _view.DoOpenLogList = new SimpleCommand(OpenLogList);
            _view.DoOpenLogDraw = new SimpleCommand(OpenLogDraw);
            _view.DoOpenLogChangeDisplayProps = new SimpleCommand(OpenLogChangeDisplayProps);
        }

        #endregion

        #region Methods

        public void OpenLogSearch()
        {
            _service.ShowWindow(typeof(I_LogSearchView), false);
        }

        public void OpenLogImport()
        {
            _service.ShowWindow(typeof(I_LogImportView), false);
        }

        public void OpenLogList()
        {
            _service.ShowWindow(typeof(I_LogListView), false);
        }

        public void OpenLogDraw()
        {
            _service.ShowWindow(typeof(I_LogDrawView), false);
        }

        public void OpenLogChangeDisplayProps()
        {
            _service.ShowWindow(typeof(I_LogChangeDisplayPropertiesView), false);
        }

        #endregion
    }
}
