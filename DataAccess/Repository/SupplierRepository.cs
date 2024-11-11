using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationContext context) : base(context) { }
    }
}
