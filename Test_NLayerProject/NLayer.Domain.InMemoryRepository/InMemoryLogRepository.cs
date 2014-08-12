using NLayer.Domain.Entity;
using NLayer.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NLayer.Domain.InMemoryRepository
{
    public class InMemoryLogRepository : ILogRepository
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

        #region Methods

        public IEnumerable<Log> GetAllLogs()
        {
            return _logs;
        }

        public void AddLog(Log log)
        {
            _logs.Add(log);
        }

        public Log GetLog(string name)
        {
            return GetAllLogs().Where(l => l.Name.Equals(name)).Single();
        }

        #endregion
    }
}
