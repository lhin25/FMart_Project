using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using DataAccess.Models;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.DataContext.ApplicationContext _context;

        public IndexModel(DataAccess.DataContext.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Supplier = await _context.Suppliers.ToListAsync();
        }
    }
}
