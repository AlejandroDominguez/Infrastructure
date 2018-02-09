using CrossCutting.Core.Domain;
using CrossCutting.Core.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossCutting.Core.Repository
{
    public interface IRepository<T, TKey> where T : IEntity<TKey>
    {
        Task<IEntity<TKey>> GetFirstOrDefaultAsync(ISpecification<T> filter);

        Task<IEntity<TKey>> GetFirstAsync(ISpecification<T> filter);

        Task<IEnumerable<IEntity<TKey>>> GetAsync(ISpecification<T> filter);

        Task<IEntity<TKey>> GetByIdAsync(TKey id);

        Task<IEntity<TKey>> DeleteAsync(T entiry);

        Task<IEntity<TKey>> InsertAsync(T entiry);

    }
}
