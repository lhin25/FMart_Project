using DataAccess.Models;
using DataAccess.Utils;

namespace DataAccess.DataContext
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if(context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category{ CategoryName = "Nước uống"},
                    new Category{ CategoryName = "Dụng cụ và đồ dùng nhà bếp"},
                    new Category{ CategoryName = "Dầu gội - Sữa tắm"},
                    new Category{ CategoryName = "Snacks"},
                    new Category{ CategoryName = "Rau củ"},
                    new Category{ CategoryName = "Thịt"}
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            if (context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { RoleId = 0, RoleName = "Admin" },
                    new Role { RoleId = 1, RoleName = "Quản lý cửa hàng" },
                    new Role { RoleId = 2, RoleName = "Thủ kho" },
                    new Role { RoleId = 3, RoleName = "Thu ngân" }
                };
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            if (context.Staffs.Any())
            {
                Cryptography cryptography = new Cryptography();
                var staffs = new List<Staff>
                {
                    new Staff { Email = "admin@gmail.com", FullName = "Admin", HashPassword = cryptography.Encrypt("admin123"), PhoneNumber = "0123456789", RoleId = 0, StartDate = new DateTime(2024, 9, 15) },
                    new Staff { Email = "lhin1605@gmail.com", FullName = "Le Thu Hien", HashPassword = cryptography.Encrypt("lhin25"), PhoneNumber = "0865409129", RoleId = 1, StartDate = new DateTime(2024, 9, 15) },
                    new Staff { Email = "stockkeeper@gmail.com", FullName = "Stockkeeper 1", HashPassword = cryptography.Encrypt("stockkeeper1"), PhoneNumber = "0987654321", RoleId = 2, StartDate = new DateTime(2024, 9, 16) },
                    new Staff { Email = "cashier@gmail.com", FullName = "Cashier 1", HashPassword = cryptography.Encrypt("cashier1"), RoleId = 3, StartDate = new DateTime(2024, 9, 17) }
                };
                context.Staffs.AddRange(staffs);
                context.SaveChanges();
            }

            if(context.Suppliers.Any())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { CompanyName = "Công ty TNHH Nestlé Việt Nam", PhoneNumber = "02839113737", Email = "consumer.services@vn.nestle.com", Address = "KCN Biên hòa 2, P. Long Bình, TP. Biên Hoà, Đồng Nai"},
                    new Supplier{ CompanyName = "Công ty TNHH URC Việt Nam", Email = "info@urcvn.com"}
                };
            }

            if (context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product{ ProductName = "MAGGI Nước tương thanh dịu 450ml", SupplierId = context.Suppliers.First(s => s.CompanyName == "Công ty TNHH Nestlé Việt Nam").SupplierId, Barcode = "8934804043647", CategoryId = context.Categories.First(c => c.CategoryName == "Kitchenware and Dinnerware").CategoryId, ImportPrice = 20000, RetailPrice = 21400 },
                    new Product{ ProductName = "MAGGI Nước tương đậm đặc 700ml", SupplierId = context.Suppliers.First(s => s.CompanyName == "Công ty TNHH Nestlé Việt Nam").SupplierId, Barcode = "8934804020402", CategoryId = context.Categories.First(c => c.CategoryName == "Kitchenware and Dinnerware").CategoryId, ImportPrice = 35000, RetailPrice = 37400 },
                    new Product{ ProductName = "C2 Trà đen hương dâu anh đào Freeze 455ml", SupplierId = context.Suppliers.First(s => s.CompanyName == "Công ty TNHH URC Việt Nam").SupplierId, Barcode = "8934564600869", CategoryId = context.Categories.First(c => c.CategoryName == "Beverages").CategoryId, ImportPrice = 8000, RetailPrice = 10400}
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
