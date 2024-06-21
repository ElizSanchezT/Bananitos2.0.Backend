using Calzaditos.Database;

namespace Calzaditos.Repositories
{
    public class BaseRepository
    {
        protected readonly CalzaditosDbContext _context;

        public BaseRepository(CalzaditosDbContext context)
        {
            _context = context;
        }
    }
}
