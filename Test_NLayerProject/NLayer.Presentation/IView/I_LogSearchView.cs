using NLayer.Common.Pattern.Command;
using System.Collections.Generic;

namespace NLayer.Presentation.IView
{
    public interface I_LogSearchView
    {
        string SearchQuery { get; set; }
        I_Command DoReset { get; set; }
        I_Command DoSearch { get; set; }
        IList<string> SearchResults { get; set; }
    }
}
