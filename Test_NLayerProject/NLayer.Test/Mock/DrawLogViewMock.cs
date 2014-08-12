using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Test.Mock
{
    public class DrawLogViewMock : IDrawLogView
    {
        #region Properties

        public string Name { get; set; }
        public ICommand DoDraw { get; set; }
        public string Color { get; set; }
        public int Thickness { get; set; }
        public IList<KeyValuePair<double, double>> Points { get; set; }

        #endregion
    }
}
