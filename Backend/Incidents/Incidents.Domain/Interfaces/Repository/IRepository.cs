using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;

namespace Incidents.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId> 
    {
        Task<TEntity> FindById(TId id);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task<bool> Contains(TEntity entity);

    }
}
