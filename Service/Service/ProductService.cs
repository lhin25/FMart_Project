using DataAccess.Models;
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
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(IGetRepository getRepository) : base(getRepository) { }

        public override Task<bool> Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<Product> Get(Expression<Func<Product, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Product>>? GetAll()
        {
            var products = await GetRepository.ProductRepository.GetAllAsync(includeProperties: "Category,Supplier");
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllIgnoredIncluded()
        {
            var products = await GetRepository.ProductRepository.GetAllAsync();
            return products;
        }

        public override async Task<Pagination<Product>> GetPagination(int pageIndex, int pageSize)
        {
            var listProducts = await GetAll();
            return await GetRepository.ProductRepository.ToPagination(listProducts, pageIndex, pageSize);
        }

        public override Task<bool> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
