using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Service;

namespace PRN221_FMart_Project.Pages.Areas.Staffs
{
    public class DashboardModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IInvoiceService _invoiceService;

        public DashboardModel(
            ICustomerService customerService, IInvoiceService invoiceService)
        {
            _customerService = customerService;
            _invoiceService = invoiceService;
        }

        public int NumberOfOrders { get; set; } = 0;
        public int TotalCustomers { get; set; } = 0;
        public decimal Revenue { get; set; } = 0;
        public decimal Profit { get; set; } = 0;
        public async Task<IActionResult> OnGetAsync()
        {
            TotalCustomers = await _customerService.GetTotalCustomers();
            NumberOfOrders = await _invoiceService.GetNumberInvoices();
            Revenue = _invoiceService.GetRevenue();
            Profit = _invoiceService.GetProfit();
            return Page();
        }
    }
}
