using System.Linq.Expressions;

namespace CodeVidyalaya.Clean.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includePrperties = null);
        Task<List<T>> GetAllAsync(string? includePrperties = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includePrperties = null);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}