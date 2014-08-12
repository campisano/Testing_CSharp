using NLayer.Domain.Entity;
using System.Collections.Generic;

namespace NLayer.Domain.Repository
{
    public interface ILogRepository
    {
        IEnumerable<Log> GetAllLogs();
        Log GetLog(string name);
        void AddLog(Log log);
    }
}
