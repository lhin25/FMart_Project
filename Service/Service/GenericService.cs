using DataAccess.Repository;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public abstract Task Add(T entity);

        public abstract Task Delete(object? id);

        public abstract Task<ICollection<T>>? GetAll();

        public abstract Task<T>? GetById(object? id);

        public abstract Task<Pagination<T>> GetPagination(int pageIndex, int pageSize);

        public abstract Task Update(T entity);
    }
}
