using NLayer.Domain.Entity;

namespace NLayer.Domain.Repository
{
    public interface ILogApparenceRepository
    {
        LogApparence GetLogApparence(string name);
    }
}
