using NLayer.Common.Pattern.Command;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;

namespace NLayer.Presentation.Presenter
{
    public class ImportLogPresenter
    {
        private LogService _service;
        private IImportLogView _view;

        #region Constructors

        public ImportLogPresenter(IImportLogView view)
        {
            _service = LogService.Instance;
            _view = view;
            _view.InputFilePath = string.Empty;
            _view.LogName = string.Empty;
            _view.DoImport = new SimpleCommand(ImportOperation);
            _view.MessageResult = string.Empty;
        }

        #endregion

        #region Methods

        public void ImportOperation()
        {
            string logName = _view.LogName.Trim();
            string inputFilePath = _view.InputFilePath.Trim();

            if (logName.Equals(string.Empty))
            {
                _view.MessageResult = "Choose a log name!";
            }
            else if (!_service.IsNewLogNameValid(logName))
            {
                _view.MessageResult = "Log name invalid!";
            }
            else if (!_service.IsImportLogFilePathValid(inputFilePath))
            {
                _view.MessageResult = "Log file path invalid!";
            }
            else
            {
                if (_service.Import(inputFilePath, logName))
                {
                    _view.MessageResult = "Log imported: " + _service.GetLogPointsNum(logName) + " points.";
                }
                else
                {
                    _view.MessageResult = "Log import error!";
                }
            }
        }

        #endregion
    }
}
