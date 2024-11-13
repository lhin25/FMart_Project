using DataAccess.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Service.Service;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PRN221_FMart_Project.Pages
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IStaffService _staffService;
        public LoginModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [Required]
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        public bool RememberMe { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(string ReturnUrl = null)
        {
            TempData["returnURL"] = ReturnUrl;

            var reStaffId = Request.Cookies["ReStaffId"];
            if (!string.IsNullOrEmpty(reStaffId))
            {
                var _staff = await _staffService.GetById(Guid.Parse(reStaffId));
                if (_staff == null) return Page();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim("StaffId", _staff.StaffId.ToString())
                };

                string areaName = string.Empty;
                switch (_staff.RoleId)
                {
                    case 0:
                        areaName = "Admin";
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                        break;
                    case 1:
                        areaName = "Staff";
                        claims.Add(new Claim(ClaimTypes.Role, "ShopManager"));
                        break;
                    case 2:
                        areaName = "Staff";
                        claims.Add(new Claim(ClaimTypes.Role, "Stockkeeper"));
                        break;
                    case 3:
                        areaName = "Staff";
                        claims.Add(new Claim(ClaimTypes.Role, "Cashier"));
                        break;
                    default: break;
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("IsSignIn", "true");
                HttpContext.Session.SetString("FullName", _staff.FullName);
                HttpContext.Session.SetString("Staff", JsonConvert.SerializeObject(_staff));
                return RedirectToPage("/Areas/" + areaName + "/Index", new { area = areaName });
            }
            else
            {
                Response.Cookies.Delete("ReStaffId");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ErrorMessage = "";
                var staff = await _staffService.Login(Email, Password);
                if (staff != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Email),
                        new Claim("StaffId", staff.StaffId.ToString())
                    };

                    string areaName = string.Empty;

                    if (staff.RoleId == 0)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                        areaName = "Admin";
                    }
                    else
                    {
                        areaName = "Staff";
                        switch (staff.RoleId)
                        {
                            case 1:
                                claims.Add(new Claim(ClaimTypes.Role, "ShopManager"));
                                break;
                            case 2:
                                claims.Add(new Claim(ClaimTypes.Role, "Stockkeeper"));
                                break;
                            case 3:
                                claims.Add(new Claim(ClaimTypes.Role, "Cashier"));
                                break;
                            default: break;
                        }
                    }

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if (RememberMe)
                    {
                        CookieOptions options = new()
                        {
                            Expires = DateTimeOffset.UtcNow.AddDays(7),
                            HttpOnly = true
                        };
                        Response.Cookies.Append("ReStaffId", staff.StaffId.ToString(), options);
                    }

                    HttpContext.Session.SetString("IsSignIn", "true");
                    HttpContext.Session.SetString("FullName", staff.FullName);
                    HttpContext.Session.SetString("Staff", JsonConvert.SerializeObject(staff));

                    if (TempData["returnURL"] != null)
                    {
                        string pageURL = (string)TempData["returnURL"];
                        return Redirect(pageURL);
                    }
                    
                    return RedirectToPage("/Areas/" + areaName + "/Index", new { area = areaName });
                }
                else
                {
                    ErrorMessage = "Invalid Login! Please try again.";
                    return Page();
                }
            }
            else return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("ReStaffId");
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
