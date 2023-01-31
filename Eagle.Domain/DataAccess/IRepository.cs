using Eagle.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eagle.Domain.DataAccess
{
    public interface IRepository<T> where T : EntityDM
    {
        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(int id);

        void Delete(IEnumerable<int> ids);

        Task<IEnumerable<T>> GetsAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(int id);

    }
}
