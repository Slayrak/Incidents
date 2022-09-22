using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Incidents.Domain.Entities;
using Incidents.Domain.Interfaces.Repository;

namespace Incidents.Infrastructure.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        public IncidentsDbContext _dbContext;

        public Repository(IncidentsDbContext incidentsDb)
        {
            _dbContext = incidentsDb;
        }

        public virtual async Task<TEntity> FindById(TId id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> Contains(TEntity entity)
        {
            return await _dbContext
                .Set<TEntity>()
                .ContainsAsync(entity);
        }

    }
}
