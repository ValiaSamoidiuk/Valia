using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Update(TEntity entity);
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity item, CancellationToken cancellationToken);
        TEntity Remove(TEntity entity);
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}