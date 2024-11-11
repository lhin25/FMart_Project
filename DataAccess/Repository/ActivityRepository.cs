using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationContext context) : base(context) { }
    }
}
