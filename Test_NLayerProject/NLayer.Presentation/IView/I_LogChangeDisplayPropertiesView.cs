using NLayer.Common.Pattern.Command;

namespace NLayer.Presentation.IView
{
    public interface I_LogChangeDisplayPropertiesView
    {
        string LogName { get; set; }
        string LogColor { get; set; }
        int LogThickness { get; set; }
        I_Command DoChange { get; set; }
    }
}
