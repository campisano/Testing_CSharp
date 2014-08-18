namespace NLayer.Domain.Service.SystemOperation.Message
{
    public class MessageLogImported
    {
        private string _logName;

        public MessageLogImported(string logName)
        {
            this._logName = logName;
        }

        public string getLogName()
        {
            return _logName;
        }
    }
}
