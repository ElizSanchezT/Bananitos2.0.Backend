using Calzaditos.Models;

namespace Calzaditos.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product?> GetProduct(int id);
    }
}
