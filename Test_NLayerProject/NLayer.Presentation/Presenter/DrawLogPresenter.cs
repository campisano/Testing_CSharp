using NLayer.Common.Pattern.Command;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Domain.Service.SystemOperation.Response;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Presentation.Presenter
{
    public class DrawLogPresenter
    {
        private LogService _service;
        private IDrawLogView _view;

        #region Constructors

        public DrawLogPresenter(IDrawLogView view)
        {
            _service = LogService.Instance;
            _view = view;
            _view.Name = string.Empty;
            _view.DoDraw = new SimpleCommand(DrawLog);
            _view.Color = string.Empty;
            _view.Thickness = 0;
            _view.Points = new List<KeyValuePair<double, double>>();
        }

        #endregion

        #region Methods

        public void DrawLog()
        {
            _view.Points.Clear();

            DrawLogResponse resp = _service.GetDrawLog(_view.Name);
            _view.Name = resp.Name;
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
