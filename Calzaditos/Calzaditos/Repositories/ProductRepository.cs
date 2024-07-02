using Calzaditos.Database;
using Calzaditos.Models;
using Microsoft.EntityFrameworkCore;

namespace Calzaditos.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(CalzaditosDbContext context) : base(context)
        {
        }

        public Task<Product?> GetProduct(int id) =>
            _context.Products
               .Include(x => x.Sizes)
               .Where(x => x.Id == id && x.DeletedAt == null)
               .FirstOrDefaultAsync();
        

        public Task<List<Product>> GetProducts() => 
            _context.Products
                .Include(x => x.Sizes)
                .Where(x => x.DeletedAt == null)
                .ToListAsync();
    }
}
