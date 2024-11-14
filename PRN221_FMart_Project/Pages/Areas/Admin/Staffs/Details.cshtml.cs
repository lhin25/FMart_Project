using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using DataAccess.Models;

namespace PRN221_FMart_Project.Pages.Areas.Admin.Staffs
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.DataContext.ApplicationContext _context;

        public DetailsModel(DataAccess.DataContext.ApplicationContext context)
        {
            _context = context;
        }

        public Staff Staff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }
            else
            {
                Staff = staff;
            }
            return Page();
        }
    }
}
