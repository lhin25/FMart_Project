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

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IActivityService _activityService;

        public CreateModel(ICustomerService customerService,
            IActivityService activityService)
        {
            _customerService = customerService;
            _activityService = activityService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var isAdd = await _customerService.Add(Customer);
            if (!isAdd)
            {
                ModelState.AddModelError(string.Empty, "Unable to create. Please try again.");
                return Page();
            }
            Activity activity = new Activity
            {
                StaffId = Guid.Parse(HttpContext.Session.GetString("StaffId")),
                Time = DateTime.Now,
                Description = "Added new customer " + Customer.PhoneNumber + "."
            };
            var isAddAct = await _activityService.Add(activity);
            return RedirectToPage("./Index");
        }
    }
}
