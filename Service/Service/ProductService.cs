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

        public override Task Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override async Task<ICollection<Product>>? GetAll(Expression<Func<Product, bool>>? filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, string includeProperties = "")
        {
            var products = await GetRepository.ProductRepository.GetAllAsync(filter, orderBy, includeProperties);
            return products;
        }

        public override Task<Product>? GetById(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<Pagination<Product>> GetPagination(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
