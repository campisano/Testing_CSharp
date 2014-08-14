using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Test.Mock
{
    public class LogDrawViewMock : I_LogDrawView
    {
        #region Properties

        public string LogName { get; set; }
        public I_Command DoDraw { get; set; }
        public string Color { get; set; }
        public int Thickness { get; set; }
        public IList<KeyValuePair<double, double>> Points { get; set; }

        #endregion
    }
}
