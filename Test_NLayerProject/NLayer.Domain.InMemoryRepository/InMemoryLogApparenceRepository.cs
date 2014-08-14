using NLayer.Domain.Entity;
using NLayer.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NLayer.Domain.InMemoryRepository
{
    public class InMemoryLogApparenceRepository : I_LogApparenceRepository
    {
        private IList<LogApparence> _logApparences;

        #region Constructors

        public InMemoryLogApparenceRepository(IList<Log> logs)
        {
            _logApparences = new List<LogApparence>();

            foreach (var item in logs)
            {
                _logApparences.Add(new LogApparence(item.Name, "Black", 1));
            }
        }

        #endregion

        #region I_LogApparenceRepository Methods

        public LogApparence GetLogApparence(string name)
        {
            LogApparence app;

            if (_logApparences.Where(c => c.Name.Equals(name)).Count() == 0)
            {
                app = new LogApparence(name, "Black", 1);
                _logApparences.Add(app);
            }
            else
            {
                app = _logApparences.Where(c => c.Name.Equals(name)).Single();
            }

            return app;
        }

        #endregion
    }
}
