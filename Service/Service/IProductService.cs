using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IProductService : IGenericService<Product>
    {
        public Task<IEnumerable<Product>> GetAllIgnoredStatus();
        public Task<IEnumerable<Product>> GetAllIgnoreActive();
    }
}
