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
using Microsoft.AspNetCore.Authorization;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Products
{
    [Authorize(Roles = "ShopManager")]
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.Get(filter: m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isDeleted = await _productService.Delete(id);
            if (!isDeleted)
            {
                ModelState.AddModelError(string.Empty, "Unable to delete. Please try again.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
