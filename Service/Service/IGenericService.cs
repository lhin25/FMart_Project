using DataAccess.Utils;
using System.Linq.Expressions;

namespace Service.Service
{
    public interface IGenericService<T> where T : class
    {
        public Task<IEnumerable<T>>? GetAll();
        public Task<Pagination<T>> GetPagination(int pageIndex, int pageSize);
        public Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        public Task<bool> Add(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(object? id);
        
    }
}
