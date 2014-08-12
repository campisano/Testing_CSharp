using NLayer.Common.Pattern.Command;
using System.Collections.Generic;

namespace NLayer.Presentation.IView
{
    public interface IDrawLogView
    {
        string Name { get; set; }
        ICommand DoDraw { get; set;} 
        string Color { get; set; }
        int Thickness { get; set; }
        IList<KeyValuePair<double, double>> Points { get; set; }
    }
}
