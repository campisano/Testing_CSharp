using NLayer.Common.Pattern.Command;

namespace NLayer.Presentation.IView
{
    public interface IMainWindowView
    {
        ICommand DoOpenCustomerSearch { get; set; }
        ICommand DoOpenImportLog { get; set; }
        ICommand DoOpenLogList { get; set; }
        ICommand DoOpenDrawLog { get; set; }
    }
}
