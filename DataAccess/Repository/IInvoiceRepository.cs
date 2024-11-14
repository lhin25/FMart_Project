using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        public Task<int> GetNumberInvoices();
        public decimal GetRevenue();
        public decimal GetProfit();
    }
}
