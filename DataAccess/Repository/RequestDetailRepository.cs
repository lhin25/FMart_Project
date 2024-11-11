using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class RequestDetailRepository : GenericRepository<RequestDetail>, IRequestDetailRepository
    {
        public RequestDetailRepository(ApplicationContext context) : base(context) { }
    }
}
