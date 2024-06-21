using Calzaditos.Database;
using Calzaditos.Models;

namespace Calzaditos.Repositories
{
    public class CartRepository : BaseRepository
    {
        public CartRepository(CalzaditosDbContext context) : base(context)
        {

        }

        public Cart? GetCart(int id) => _context.Carts.FirstOrDefault(c => c.Id == id);
    }
}
