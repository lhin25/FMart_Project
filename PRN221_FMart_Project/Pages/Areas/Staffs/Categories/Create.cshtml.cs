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
using Service.Service;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Categories
{
    [Authorize(Roles = "ShopManager,Stockkeeper")]
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IActivityService _activityService;

        public CreateModel(ICategoryService categoryService,
            IActivityService activityService)
        {
            _activityService = activityService;
            _categoryService = categoryService;
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

            var isAdd = await _categoryService.Add(Category);
            if (!isAdd)
            {
                ModelState.AddModelError(string.Empty, "Unable to create. Please try again.");
                return Page();
            }
            Activity activity = new Activity
            {
                StaffId = Guid.Parse(HttpContext.Session.GetString("StaffId")),
                Time = DateTime.Now,
                Description = "Added new category " + Category.CategoryName + "."
            };
            var isAddAct = await _activityService.Add(activity);
            return RedirectToPage("./Index");
        }
    }
}
