using System.Linq.Expressions;

namespace CleanApp.Application.Contracts.Persistence
{
    public interface IGenericRepository<T, TId> where T : class where TId : struct
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(TId id);
        ValueTask<T?> GetbyIdAsync(int Id);
        ValueTask AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
