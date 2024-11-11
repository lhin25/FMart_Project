using DataAccess.DataContext;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class NoteDetailRepository : GenericRepository<NoteDetail>, INoteDetailRepository
    {
        public NoteDetailRepository(ApplicationContext context) : base(context) { }
    }
}
