using DataAccess.Repository;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public abstract class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGetRepository GetRepository;
        protected GenericService(IGetRepository getRepository)
        {
            this.GetRepository = getRepository;
        }

        public abstract Task<bool> Add(T entity);

        public abstract Task<bool> Delete(object? id);

        public abstract Task<IEnumerable<T>>? GetAll();
        public abstract Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null);

        public abstract Task<Pagination<T>> GetPagination(int pageIndex, int pageSize);

        public abstract Task<bool> Update(T entity);
    }
}
