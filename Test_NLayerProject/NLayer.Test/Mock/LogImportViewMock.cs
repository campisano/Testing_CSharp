using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;

namespace NLayer.Test.Mock
{
    public class LogImportViewMock : I_LogImportView
    {
        #region Properties

        public string InputFilePath { get; set; }
        public string LogName { get; set; }
        public I_Command DoImport { get; set; }
        public string MessageResult { get; set; }

        #endregion
    }
}
