using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        Task<T> GetById(object? id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
