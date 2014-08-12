using NLayer.Domain.Entity;
using NLayer.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NLayer.Domain.InMemoryRepository
{
    public class InMemoryLogApparenceRepository : ILogApparenceRepository
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

        #region Methods

        public LogApparence GetLogApparence(string name)
        {
            return _logApparences.Where(c => c.Name.Equals(name)).Single();
        }

        #endregion
    }
}
