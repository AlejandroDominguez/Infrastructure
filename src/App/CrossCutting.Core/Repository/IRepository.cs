using CrossCutting.Core.Domain;

namespace CrossCutting.Core.Repository
{
    public interface IRepository<T, TKey> where T : IEntity<TKey>
    {
    }
}
