using NLayer.Common.Pattern.Command;
using NLayer.Presentation.IView;

namespace NLayer.Test.Mock
{
    public class LogChangeDisplayPropertiesViewMock : I_LogChangeDisplayPropertiesView
    {
        public string LogName { get; set; }
        public string LogColor { get; set; }
        public int LogThickness { get; set; }
        public I_Command DoChange { get; set; }
    }
}
