using NLayer.Common.Pattern.Command;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Domain.Service.SystemOperation.Response;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Presentation.Presenter
{
    public class LogDrawPresenter
    {
        private LogService _service;
        private I_LogDrawView _view;

        #region Constructors

        public LogDrawPresenter(I_LogDrawView view)
        {
            _service = LogService.Instance;
            _view = view;
            _view.LogName = string.Empty;
            _view.DoDraw = new SimpleCommand(LogDraw);
            _view.Color = string.Empty;
            _view.Thickness = 0;
            _view.Points = new List<KeyValuePair<double, double>>();
        }

        #endregion

        #region Methods

        public void LogDraw()
        {
            _view.Points.Clear();

            LogDrawResponse resp = _service.GetLogDraw(_view.LogName);
            _view.LogName = resp.Name;
            _view.Color = resp.Color;
            _view.Thickness = resp.Thickness;

            foreach (var item in resp.Values)
            {
                //TODO [CMP] essa cópia é feita várias vezes e não precisa, estabelecer uma estratégia
                _view.Points.Add(new KeyValuePair<double, double>(item.Key, item.Value));
            }
        }

        #endregion
    }
}
