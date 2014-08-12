using System.Collections.Generic;

namespace NLayer.Presentation.IView
{
    public interface ILogListView
    {
        IList<string> Logs { get; set; }
    }
}
