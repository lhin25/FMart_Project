using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context) { }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            try
            {
                Product? availProd = await _context.Products.FirstOrDefaultAsync(i => i.ProductId == productId && i.IsActive == true && i.IsDeleted == false);
                if(availProd != null)
                {
                    availProd.IsDeleted = true;
                    availProd.IsActive = false;

                    _context.Products.Update(availProd);
                    await _context.SaveChangesAsync();
                    return true;
                } return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
