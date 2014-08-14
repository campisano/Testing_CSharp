using NLayer.Common.Pattern.Command;

namespace NLayer.Presentation.IView
{
    public interface I_LogImportView
    {
        string InputFilePath { get; set; }
        string LogName { get; set; }
        I_Command DoImport { get; set; }
        string MessageResult { get; set; }
    }
}
