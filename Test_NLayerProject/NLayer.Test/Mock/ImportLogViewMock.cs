using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;

namespace NLayer.Test.Mock
{
    public class ImportLogViewMock : IImportLogView
    {
        #region Properties

        public string InputFilePath { get; set; }
        public string LogName { get; set; }
        public ICommand DoImport { get; set; }
        public string MessageResult { get; set; }

        #endregion
    }
}
