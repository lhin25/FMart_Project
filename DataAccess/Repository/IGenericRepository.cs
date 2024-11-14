using DataAccess.Utils;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        Task<T> GetById(object? id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<Pagination<T>> ToPagination(IEnumerable<T> list, int pageIndex = 0, int pageSize = 10, params Expression<Func<T, object>>[] includes);
    }
}
