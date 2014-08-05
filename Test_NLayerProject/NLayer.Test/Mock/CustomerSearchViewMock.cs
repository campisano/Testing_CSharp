using NLayer.Common.Pattern.Command;
using NLayer.Presentation;
using System.Collections.Generic;

namespace NLayer.Test.Mock
{
    public class CustomerSearchViewMock : ICustomerSearchView
    {
        #region Properties

        public string SearchQuery { get; set; }
        public ICommand DoReset { get; set; }
        public ICommand DoSearch { get; set; }
        public IList<string> SearchResults { get; set; }

        #endregion
    }
}
