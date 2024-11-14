using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationContext context) : base(context) { }

        public async Task<int> GetNumberInvoices()
        {
            return await _context.Invoices.CountAsync();
        }

        public decimal GetProfit()
        {
            decimal totalRetail = 0;
            decimal totalimport = 0;
            foreach (var item in _context.InvoiceDetails.Include(p => p.Product))
            {
                totalimport += item.Quantity * item.Product.ImportPrice;
                totalRetail += item.Quantity * item.Product.RetailPrice;
            };
            return (totalRetail - totalimport);
        }

        public decimal GetRevenue()
        {
            decimal totalRetail = 0;
            foreach (var item in _context.InvoiceDetails.Include(p => p.Product))
            {
                totalRetail += item.Quantity * item.Product.RetailPrice;
            };
            return (totalRetail);
        }
    }
}
