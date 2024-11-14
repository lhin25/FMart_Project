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

        public override async Task<bool> Add(Product entity)
        {
            try
            {
                var isExisted = await GetRepository.ProductRepository.GetById(entity.ProductId);
                if (isExisted != null)
                {
                    return false;
                }
                await GetRepository.ProductRepository.CreateAsync(entity);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("An error has occured.");
            }
        }

        public override async Task<bool> Delete(object? id)
        {
            return await GetRepository.ProductRepository.DeleteProduct((Guid)id);
        }

        public override async Task<Product> Get(Expression<Func<Product, bool>> filter, string? includeProperties = null)
        {
            var product = await GetRepository.ProductRepository.GetAsync(filter, includeProperties);
            return product;
        }

        public override async Task<IEnumerable<Product>>? GetAll()
        {
            var products = await GetRepository.ProductRepository.GetAllAsync(filter: i => i.IsActive == true && i.IsDeleted == false, includeProperties: "Category,Supplier");
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllIgnoreActive()
        {
            var products = await GetRepository.ProductRepository.GetAllAsync(filter: i => i.IsDeleted == false, includeProperties: "Category,Supplier");
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllIgnoredStatus()
        {
            var products = await GetRepository.ProductRepository.GetAllAsync(includeProperties: "Category,Supplier");
            return products;
        }

        public override async Task<Pagination<Product>> GetPagination(int pageIndex, int pageSize)
        {
            var listProducts = await GetAll();
            return await GetRepository.ProductRepository.ToPagination(listProducts, pageIndex, pageSize);
        }

        public override async Task<bool> Update(Product entity)
        {
            try
            {
                var pro = await GetRepository.ProductRepository.GetAsync(filter: p => p.ProductId == entity.ProductId);
                if (pro == null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.ProductRepository.UpdateAsync(pro);
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception("An error has occured.");
            }
        }
    }
}
