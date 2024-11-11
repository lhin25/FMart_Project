using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationContext context) : base(context) { }
    }
}
