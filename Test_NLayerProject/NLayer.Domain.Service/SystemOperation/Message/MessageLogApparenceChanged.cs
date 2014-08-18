namespace NLayer.Domain.Service.SystemOperation.Message
{
    public class MessageLogApparenceChanged
    {
        private string _logName;

        public MessageLogApparenceChanged(string logName)
        {
            this._logName = logName;
        }

        public string getLogName()
        {
            return _logName;
        }
    }
}
