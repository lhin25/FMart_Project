using DataAccess.Utils;

namespace Service.Service
{
    public interface IGenericService<T> where T : class
    {
        public Task<ICollection<T>>? GetAll();
        public Task<Pagination<T>> GetPagination(int pageIndex, int pageSize);
        public Task<T>? GetById(object? id);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(object? id);
        
    }
}
