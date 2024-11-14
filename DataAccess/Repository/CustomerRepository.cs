using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context) { }

        public async Task<int> GetTotalCustomers()
        {
            return await _context.Customers.CountAsync();
        }
    }
}
