using NLayer.Common.Pattern.Command;
using System.Collections.Generic;

namespace NLayer.Presentation.IView
{
    public interface ICustomerSearchView
    {
        string SearchQuery { get; set; }
        ICommand DoReset { get; set; }
        ICommand DoSearch { get; set; }
        IList<string> SearchResults { get; set; }
    }
}
