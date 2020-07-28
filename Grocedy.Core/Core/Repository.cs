using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Grocedy.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Grocedy.Core.Core
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected GrocedyContext context;
        public Repository(GrocedyContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            var result=await context.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await context.Set<T>().AsQueryable().AsNoTracking().ToListAsync();
            
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>()
                                .AsQueryable()
                                .AsNoTracking()
                                .Where(predicate)
                                .ToListAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            return await context.FindAsync<T>(id);
        }

        public virtual async  Task<T> Get(long id)
        { 
            return await context.FindAsync<T>(id);
        }

        public virtual async Task<T> Single(Expression<Func<T, bool>> preficate)
        {
            return await context.Set<T>().AsQueryable().AsNoTracking().Where(preficate).SingleOrDefaultAsync();
        }

        public virtual  T Update(T entity)
        {
           return context.Update<T>(entity).Entity;
             
        }



    }
}
