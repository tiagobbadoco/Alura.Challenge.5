using System.Linq;
using System.Linq.Expressions;
using Alura.Challenge.Infrastructure.Data.Context;
using Alura.Challenge.Infrastructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Alura.Challenge.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AluraFlixContext _context;

        public Repository(AluraFlixContext context)
        {
            _context = context;
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public T Insert(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}