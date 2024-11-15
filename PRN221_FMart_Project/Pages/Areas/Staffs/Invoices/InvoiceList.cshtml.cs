using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Service.Service;
using DataAccess.Utils;

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Invoices
{
    [Authorize(Roles = "ShopManager,Cashier")]
    public class InvoiceListModel : PageModel
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceListModel(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Pagination<Invoice> Invoice { get;set; } = default!;
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;

        public async Task OnGetAsync()
        {
            Invoice = await _invoiceService.GetPagination(PageIndex - 1, PageSize);
        }
    }
}
