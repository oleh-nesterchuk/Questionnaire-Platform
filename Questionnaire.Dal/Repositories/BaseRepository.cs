using Questionnaire.Core.Abstractions;
using Questionnaire.Core.Abstractions.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Dal.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected readonly QuestionnaireDbContext _context;

        public BaseRepository(QuestionnaireDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            return await GetByIdAsync(entity.Id);
        }

        public virtual void DeleteById(TKey id)
        {
            _context.Set<TEntity>().Remove(new TEntity { Id = id });
        }
    }
}
