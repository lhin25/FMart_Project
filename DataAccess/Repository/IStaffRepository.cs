using DataAccess.Models;

namespace DataAccess.Repository
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        public Task<Staff?> Login(string email, string password);
    }
}
