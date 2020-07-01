using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Core.Abstractions.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void DeleteById(TKey id);
    }
}
