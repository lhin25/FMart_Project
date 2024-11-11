using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationContext context) : base(context) { }
    }
}
