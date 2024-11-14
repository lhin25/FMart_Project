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

namespace PRN221_FMart_Project.Pages.Areas.Staffs.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public Pagination<Customer> Customer { get;set; } = default!;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync()
        {
            Customer = await _customerService.GetPagination(PageIndex - 1, PageSize);
        }
    }
}
