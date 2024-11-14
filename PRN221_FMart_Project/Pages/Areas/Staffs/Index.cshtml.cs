using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_FMart_Project.Pages.Areas.Staffs
{
    public class IndexModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            return RedirectToPage("/Areas/Staffs/Dashboard", new { area = "Staffs" });
        }
    }
}
