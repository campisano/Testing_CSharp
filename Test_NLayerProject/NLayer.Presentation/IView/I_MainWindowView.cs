using NLayer.Common.Pattern.Command;

namespace NLayer.Presentation.IView
{
    public interface I_MainWindowView
    {
        I_Command DoOpenLogSearch { get; set; }
        I_Command DoOpenLogImport { get; set; }
        I_Command DoOpenLogList { get; set; }
        I_Command DoOpenLogDraw { get; set; }
        I_Command DoOpenLogChangeDisplayProps { get; set; }
    }
}
