using NLayer.Domain.Entity;

namespace NLayer.Domain.Repository
{
    public interface I_LogApparenceRepository
    {
        LogApparence GetLogApparence(string name);
    }
}
