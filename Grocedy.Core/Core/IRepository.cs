using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Grocedy.Core.Core
{
    public interface IRepository<T>
    {
       Task<T> Add(T entity);
        T Update(T entity);
        Task<T> Get(long id);
        Task<T> Single(Expression<Func<T,bool>> preficate);
        Task<IEnumerable<T>> All();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

    }
}
