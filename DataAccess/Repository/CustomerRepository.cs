using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context) { }
    }
}
