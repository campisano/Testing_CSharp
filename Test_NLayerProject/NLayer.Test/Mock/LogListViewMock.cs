using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Test.Mock
{
    public class LogListViewMock : I_LogListView
    {
        #region Properties

        public IList<string> Logs { get; set; }

        #endregion
    }
}
