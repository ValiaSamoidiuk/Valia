using DAL.Contexts;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    ///<inheritdoc cref="IRepository{TEntity}"/>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;
        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return _entities.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            return _entities.Update(entity)?.Entity;
        }

        public TEntity Insert(TEntity entity)
        {
            return _entities.Add(entity)?.Entity;
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return (await _entities.AddAsync(entity, cancellationToken)).Entity;
        }

        public TEntity Remove(TEntity entity)
        {
            return _entities.Remove(entity)?.Entity;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
