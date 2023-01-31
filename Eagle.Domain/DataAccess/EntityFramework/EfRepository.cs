using Eagle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Eagle.Domain.DataAccess.EntityFramework
{
    public class EfRepository<T> : IRepository<T> where T : EntityDM
    {
        private readonly DbSet<T> _dbSet;

        public EfRepository(DbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
