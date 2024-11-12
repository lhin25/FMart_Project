using DataAccess.DataContext;
using DataAccess.Models;
using DataAccess.Utils;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(ApplicationContext context) : base(context) { }

        public async Task<Staff?> Login(string email, string password)
        {
            Cryptography crypt = new Cryptography();
            string decryptPass = crypt.Encrypt(password);
            var _staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Email == email && s.HashPassword == decryptPass);
            return _staff;
        }
    }
}
