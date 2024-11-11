using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context) { }
    }
}
