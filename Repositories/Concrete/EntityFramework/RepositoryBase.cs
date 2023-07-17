using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories.Concrete.Context;

namespace Repositories.Concrete.EntityFramework
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _context;
        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        } 

        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (trackChanges == true)
            {
                return _context.Set<T>();
            }

            return _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges == true)
            {
                return _context.Set<T>().Where(expression).SingleOrDefault();
            }
            return _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}
