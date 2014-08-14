using NLayer.Common.Pattern.Command;
using System.Collections.Generic;

namespace NLayer.Presentation.IView
{
    public interface I_LogDrawView
    {
        string LogName { get; set; }
        I_Command DoDraw { get; set;} 
        string Color { get; set; }
        int Thickness { get; set; }
        IList<KeyValuePair<double, double>> Points { get; set; }
    }
}
