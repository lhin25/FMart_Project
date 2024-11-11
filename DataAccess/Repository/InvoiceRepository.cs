using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationContext context) : base(context) { }
    }
}
