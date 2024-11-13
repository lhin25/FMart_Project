using Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_FMart_Project.Pages.Areas.Staff
{
    [Authorize(Roles = "Cashier")]
    public class SaleModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        
        public SaleModel(
            ICustomerService customerService,
            IProductService productService)
        {
            _customerService = customerService;
            _productService = productService;
        }
        [Required(ErrorMessage = "You must provide a phone number")]
        [BindProperty]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "You must provide customer name")]
        [BindProperty]
        public string? FullName { get; set; } = string.Empty;
        [BindProperty]
        public Invoice Invoice { get; set; } = default!;
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        [BindProperty]
        public ICollection<InvoiceDetail>? InvoiceDetails { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
    }
}
