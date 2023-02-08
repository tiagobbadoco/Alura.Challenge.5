using System.Linq.Expressions;

namespace Alura.Challenge.Infrastructure.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> List();
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        T Insert(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}