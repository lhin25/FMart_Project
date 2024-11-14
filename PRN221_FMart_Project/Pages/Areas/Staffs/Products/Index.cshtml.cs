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

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Products
{
    [Authorize(Roles = "ShopManager")]
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public Pagination<Product> Product { get;set; } = default!;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync()
        {
            Product = await _productService.GetPagination(PageIndex - 1, PageSize);
        }
    }
}
