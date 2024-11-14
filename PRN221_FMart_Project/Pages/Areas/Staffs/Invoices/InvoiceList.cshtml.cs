using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Invoices
{
    [Authorize(Roles = "ShopManager,Cashier")]
    public class InvoiceListModel : PageModel
    {
        private readonly DataAccess.DataContext.ApplicationContext _context;

        public InvoiceListModel(DataAccess.DataContext.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Invoice = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Staff).ToListAsync();
        }
    }
}
