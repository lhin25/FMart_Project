using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context) { }
    }
}
