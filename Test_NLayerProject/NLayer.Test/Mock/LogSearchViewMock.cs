using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;
using System.Collections.Generic;

namespace NLayer.Test.Mock
{
    public class LogSearchViewMock : I_LogSearchView
    {
        #region Properties

        public string SearchQuery { get; set; }
        public I_Command DoReset { get; set; }
        public I_Command DoSearch { get; set; }
        public IList<string> SearchResults { get; set; }

        #endregion
    }
}
