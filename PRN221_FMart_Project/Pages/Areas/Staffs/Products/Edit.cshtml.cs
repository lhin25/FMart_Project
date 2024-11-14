using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Service.Service;
using Microsoft.AspNetCore.Hosting;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Products
{
    [Authorize(Roles = "ShopManager")]
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService,
            IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [BindProperty]
        public IFormFile? File { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  await _productService.Get(filter: m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
           ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryName");
           ViewData["SupplierId"] = new SelectList(await _supplierService.GetAll(), "SupplierId", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryName");
                ViewData["SupplierId"] = new SelectList(await _supplierService.GetAll(), "SupplierId", "CompanyName");
                return Page();
            }

            if(File != null)
            {
                string folder = "/img/product/";
                folder += Guid.NewGuid().ToString() + "_" + File.FileName;
                Product.ProductImg = folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await File.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }

            try
            {
                var isUpdated = await _productService.Update(Product);
                if (!isUpdated)
                {
                    ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryName");
                    ViewData["SupplierId"] = new SelectList(await _supplierService.GetAll(), "SupplierId", "CompanyName");
                    ModelState.AddModelError(string.Empty, "Unable to update. Please try again.");
                    return Page();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
