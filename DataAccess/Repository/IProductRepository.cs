using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<bool> DeleteProduct(Guid productId);
    }
}
