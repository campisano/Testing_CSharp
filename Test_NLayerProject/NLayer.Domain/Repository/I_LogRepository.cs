using NLayer.Domain.Entity;
using System.Collections.Generic;

namespace NLayer.Domain.Repository
{
    public interface I_LogRepository
    {
        Log GetLog(string name);
        IEnumerable<Log> GetAllLogs();
        IEnumerable<Log> SearchLogsByName(string name, bool partialName = false, bool caseSensitive = true);
        void AddLog(Log log);
    }
}
