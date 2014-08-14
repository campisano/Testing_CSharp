using NLayer.Domain.Entity;
using NLayer.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NLayer.Domain.InMemoryRepository
{
    public class InMemoryLogRepository : I_LogRepository
    {
        private IList<Log> _logs;

        #region Constructors

        public InMemoryLogRepository(IList<Log> logs)
        {
            _logs = new List<Log>();

            foreach (var item in logs)
            {
                _logs.Add(item);
            }
        }

        #endregion

        #region I_LogRepository Methods

        public Log GetLog(string name)
        {
            return GetAllLogs().Where(l => l.Name.Equals(name)).Single();
        }

        public IEnumerable<Log> GetAllLogs()
        {
            return _logs;
        }

        public IEnumerable<Log> SearchLogsByName(string name, bool partialName = false, bool caseSensitive = true)
        {
            IEnumerable<Log> logs;

            if (!partialName)
            {
                if (caseSensitive)
                {
                    logs = GetAllLogs().Where(l => l.Name.Equals(name));
                }
                else
                {
                    logs = GetAllLogs().Where(l => l.Name.ToUpper().Equals(name.ToUpper()));
                }
            }
            else
            {
                if (caseSensitive)
                {
                    logs = GetAllLogs().Where(l => l.Name.Contains(name));
                }
                else
                {
                    logs = GetAllLogs().Where(l => l.Name.ToUpper().Contains(name.ToUpper()));
                }
            }

            return logs;
        }

        public void AddLog(Log log)
        {
            _logs.Add(log);
        }

        #endregion
    }
}
