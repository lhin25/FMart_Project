using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<int> GetTotalCustomers();
    }
}
