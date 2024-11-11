using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class InvoiceDetailRepository : GenericRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(ApplicationContext context) : base(context) { }
    }
}
