using Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using DataAccess.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PRN221_FMart_Project.SignalR;
using Microsoft.AspNetCore.SignalR;
using Net.payOS;
using Net.payOS.Types;
using PRN221_FMart_Project.TempModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PRN221_FMart_Project.Pages.Areas.Staff
{
    [Authorize(Roles = "Cashier")]
    public class SaleModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IHubContext<SignalrServer> _signalrServer;
        private readonly PayOS _payOS;

        public SaleModel(
            ICustomerService customerService,
            IProductService productService,
            IInvoiceService invoiceService,
            IInvoiceDetailService invoiceDetailService,
            IHubContext<SignalrServer> signalrServer,
            PayOS payOS)
        {
            _customerService = customerService;
            _productService = productService;
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
            _signalrServer = signalrServer;
            _payOS = payOS;
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
        public IEnumerable<Customer> Customers { get; set; } = default!;
        public Pagination<Product> Products { get; set; } = default!;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 18;
        [BindProperty]
        public string? CartContainer { get; set; } = string.Empty;
        public async Task<IActionResult> OnGetAsync()
        {
            var products = await _productService.GetPagination(PageIndex - 1, PageSize);
            Products = products;
            var customers = await _customerService.GetAll();
            Customers = customers;
            var allProducts = await _productService.GetAllIgnoredIncluded();
            ViewData["CustomerList"] = JsonConvert.SerializeObject(Customers);
            ViewData["ProductList"] = JsonConvert.SerializeObject(allProducts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return Page();
        }

        public async Task<IActionResult> OnGetGetCustomerAsync()
        {
            Customers = await _customerService.GetAll();
            ViewData["CustomerList"] = JsonConvert.SerializeObject(Customers);
            return new JsonResult(Customers);
        }

        public async Task<IActionResult> OnPostAddNewCustomerAsync(string name, string phone)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                return new JsonResult
                    (new { success = false, message = "Invalid data!" });
            }
            var _customer = await _customerService.GetByPhoneNumber(phone);
            if (_customer != null)
            {
                return new JsonResult
                    (new { success = false, message = "Customer already exist!" });
            }
            else
            {
                var new_customer = new Customer
                {
                    FullName = name,
                    PhoneNumber = phone
                };
                var isAdd = await _customerService.Add(new_customer);
                if (!isAdd)
                {
                    return new JsonResult
                    (new { success = false, message = "Customer already exist!" });
                }
                else
                {
                    await _signalrServer.Clients.All.SendAsync("LoadCustomer");
                    return new JsonResult
                            (new { success = true, message = "New customer added successfully!" });
                }

            }
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            try
            {
                var cart = JsonConvert.DeserializeObject<CartContainer>(CartContainer);

                if (cart == null)
                {
                    return BadRequest("An error has occured.");
                }
                if (cart.CustomerId != null)
                {
                    Guid customerId = (Guid)(cart.CustomerId);

                    var invoice = new Invoice
                    {
                        InvoiceId = Guid.NewGuid(),
                        StaffId = Guid.Parse(HttpContext.Session.GetString("StaffId")),
                        CustomerId = customerId,
                        CreatedAt = DateTime.Now
                    };
                    var isAddInvoice = await _invoiceService.Add(invoice);
                    if (!isAddInvoice)
                    {
                        return BadRequest("An error has occured.");
                    }

                    Guid invoiceId = invoice.InvoiceId;
                    HttpContext.Session.SetString("CurrentInvoiceId", invoiceId.ToString());
                    HttpContext.Session.SetString("CustomerId", customerId.ToString());

                    foreach (var item in cart.Items)
                    {
                        var invoiceDetail = new InvoiceDetail
                        {
                            InvoiceId = invoiceId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity
                        };
                        var isAddInvoiceDt = await _invoiceDetailService.Add(invoiceDetail);
                        if (!isAddInvoiceDt)
                        {
                            return BadRequest("An error has occured.");
                        }
                    }

                    try
                    {
                        int code = int.Parse(DateTime.Now.ToString("MMddHHmmss"));
                        ItemData item = new ItemData(customerId.ToString(), 1, (int)Math.Round(cart.Total));
                        List<ItemData> items = new List<ItemData> { item };

                        string returnUrl = "https://localhost:7107/Areas/Staff/Sale";
                        PaymentData paymentData = new PaymentData(code, (int)Math.Round(cart.Total), "Checkout for #" + invoiceId.ToString(), items, returnUrl, returnUrl);
                        CreatePaymentResult paymentResult = await _payOS.createPaymentLink(paymentData);
                        return Redirect(paymentResult.checkoutUrl);
                    }
                    catch (Exception)
                    {
                        return Content("Error payment link");
                    }

                }
                else
                {
                    var invoice = new Invoice
                    {
                        InvoiceId = Guid.NewGuid(),
                        StaffId = Guid.Parse(HttpContext.Session.GetString("StaffId")),
                        CreatedAt = DateTime.Now
                    };
                    var isAddInvoice = await _invoiceService.Add(invoice);
                    if (!isAddInvoice)
                    {
                        return BadRequest("An error has occured.");
                    }

                    Guid invoiceId = invoice.InvoiceId;
                    HttpContext.Session.SetString("CurrentInvoiceId", invoiceId.ToString());

                    foreach (var item in cart.Items)
                    {
                        var invoiceDetail = new InvoiceDetail
                        {
                            InvoiceId = invoiceId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity
                        };
                        var isAddInvoiceDt = await _invoiceDetailService.Add(invoiceDetail);
                        if (!isAddInvoiceDt)
                        {
                            return BadRequest("An error has occured.");
                        }
                    }

                    try
                    {
                        int code = int.Parse(DateTime.Now.ToString("MMddHHmmss"));
                        ItemData item = new ItemData(invoiceId.ToString(), 1, (int)Math.Round(cart.Total));
                        List<ItemData> items = new List<ItemData> { item };

                        string returnUrl = "https://prn221fmartproject20241111115319.azurewebsites.net/Areas/Staff/Sale";
                        PaymentData paymentData = new PaymentData(code, (int)Math.Round(cart.Total), "Checkout", items, returnUrl, returnUrl);
                        CreatePaymentResult paymentResult = await _payOS.createPaymentLink(paymentData);
                        return Redirect(paymentResult.checkoutUrl);
                    }
                    catch (Exception ex)
                    {
                        return Content("Error payment link", ex.Message);
                    }
                }
            }
            catch (JsonException)
            {
                return BadRequest("An error has occured.");
            }
        }
    }
}
