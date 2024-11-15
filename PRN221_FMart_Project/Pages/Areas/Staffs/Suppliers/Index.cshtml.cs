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

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public IndexModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public Pagination<Supplier> Supplier { get;set; } = default!;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync()
        {
            Supplier = await _supplierService.GetPagination(PageIndex - 1, PageSize);
        }
    }
}
