using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Categories
{
    [Authorize(Roles = "ShopManager,Stockkeeper")]
    public class CreateModel : PageModel
    {
        private readonly DataAccess.DataContext.ApplicationContext _context;

        public CreateModel(DataAccess.DataContext.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
