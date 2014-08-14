using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Presentation.Presenter
{
    public class LogListPresenter
    {
        private LogService _service;
        private I_LogListView _view;

        #region Constructors

        public LogListPresenter(I_LogListView view)
        {
            _service = LogService.Instance;
            _view = view;
            _view.Logs = new List<string>();
            Open();
        }

        #endregion

        #region Methods

        public void Open()
        {
            _view.Logs.Clear();

            foreach (var item in _service.GetAllLogNames())
            {
                _view.Logs.Add(item);
            }
        }

        #endregion
    }
}
