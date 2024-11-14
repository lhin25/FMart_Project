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

namespace PRN221_FMart_Project.Pages.Areas.Admin.StaffManagement
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly DataAccess.DataContext.ApplicationContext _context;

        public IndexModel(DataAccess.DataContext.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Staff = await _context.Staffs
                .Include(s => s.Role).ToListAsync();
        }
    }
}
