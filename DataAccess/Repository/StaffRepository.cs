using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(ApplicationContext context) : base(context) { }
    }
}
