using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.DataContext;
using DataAccess.Models;
using Service.Service;

namespace PRN221_FMart_Project.Pages.Areas.Admin.StaffManagement
{
    public class CreateModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IRoleService _roleService;

        public CreateModel(IStaffService staffService, IRoleService roleService)
        {
            _staffService = staffService;
            _roleService = roleService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
        ViewData["RoleId"] = new SelectList(await _roleService.GetAll(), "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public Staff Staff { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var isAdd = await _staffService.Add(Staff);

            return RedirectToPage("./Index");
        }
    }
}
