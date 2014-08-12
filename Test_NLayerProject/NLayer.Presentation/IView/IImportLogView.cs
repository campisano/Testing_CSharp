using NLayer.Common.Pattern.Command;

namespace NLayer.Presentation.IView
{
    public interface IImportLogView
    {
        string InputFilePath { get; set; }
        string LogName { get; set; }
        ICommand DoImport { get; set; }
        string MessageResult { get; set; }
    }
}
