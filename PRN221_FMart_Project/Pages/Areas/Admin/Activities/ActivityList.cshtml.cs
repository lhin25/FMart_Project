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
using Microsoft.AspNetCore.Authorization;

namespace PRN221_FMart_Project.Pages.Areas.Admin.Activities
{
    [Authorize(Roles = "Admin")]
    public class ActivityListModel : PageModel
    {
        private readonly IActivityService _activityService;

        public ActivityListModel(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public IEnumerable<Activity> Activity { get;set; } = default!;
        [BindProperty(SupportsGet = true, Name = "PageIndex")]
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages;

        public async Task<IActionResult> OnGetAsync()
        {
            var activity = await _activityService.GetPagination(PageIndex - 1, PageSize);
            if(activity != null)
            {
                TotalPages = activity.TotalPagesCount;
                Activity = activity.Items.ToList();
            }
            return Page();
        }
    }
}
