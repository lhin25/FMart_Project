using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.DataContext;
using DataAccess.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Service.Service;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Products
{
    [Authorize(Roles = "ShopManager")]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IActivityService _activityService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService,
            IActivityService activityService,
            IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _activityService = activityService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> OnGetAsync()
        {
        ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryName");
        ViewData["SupplierId"] = new SelectList(await _supplierService.GetAll(), "SupplierId", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [BindProperty]
        public IFormFile? File { get; set; } = default!;

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
            var isAdd = await _productService.Add(Product);
            if (!isAdd)
            {
                ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "CategoryId", "CategoryName");
                ViewData["SupplierId"] = new SelectList(await _supplierService.GetAll(), "SupplierId", "CompanyName");
                ModelState.AddModelError(string.Empty, "Unable to create. Please try again.");
                return Page();
            }
            Activity invoiceAct = new Activity()
            {
                StaffId = Guid.Parse(HttpContext.Session.GetString("StaffId")),
                Time = DateTime.Now,
                Description = "Account " + HttpContext.Session.GetString("StaffEmail") + " added new product #" + Product.ProductId.ToString() + "."
            };
            var isAddActi = await _activityService.Add(invoiceAct);
            return RedirectToPage("./Index");
        }
    }
}
