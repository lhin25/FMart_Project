using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using DataAccess.Models;
using Service.Service;
using DataAccess.Utils;

namespace PRN221_FMart_Project.Pages.Areas.Staff.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public Pagination<Category> Category { get;set; } = default!;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 15;

        public async Task<IActionResult> OnGetAsync()
        {
            Category = await _categoryService.GetPagination(PageIndex - 1, PageSize);
            return Page();
        }
    }
}
