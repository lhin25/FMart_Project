using DataAccess.Utils;
using System.Linq.Expressions;

namespace Service.Service
{
    public interface IGenericService<T> where T : class
    {
        public Task<ICollection<T>>? GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        public Task<Pagination<T>> GetPagination(int pageIndex, int pageSize);
        public Task<T>? GetById(object? id);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(object? id);
        
    }
}
