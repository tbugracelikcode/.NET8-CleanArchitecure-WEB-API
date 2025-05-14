using System.Linq.Expressions;

namespace App.Repositories
{
    public interface IGenericRepository<T, TId> where T : class where TId : struct
    {
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(TId id);
        ValueTask<T?> GetbyIdAsync(int Id);
        ValueTask AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
