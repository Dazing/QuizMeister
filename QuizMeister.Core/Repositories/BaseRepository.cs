using Microsoft.EntityFrameworkCore;

namespace QuizMeister.Core.Repositories
{
    public class BaseRepository<TContext> where TContext : DbContext
    {
        protected readonly TContext _context;

        protected BaseRepository(TContext context)
        {
            _context = context;
        }
    }

}
