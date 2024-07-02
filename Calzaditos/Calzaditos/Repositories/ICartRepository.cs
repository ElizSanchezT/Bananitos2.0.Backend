using Calzaditos.Models;

namespace Calzaditos.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetCart(int id);
        Task<bool> AddProduct(int userId, int productId, int units, int selectedSize);
        Task<bool> RemoveProduct(int userId, int productId);
        Task<bool> EmptyCart(int userId);
        Task<bool> DeleteCart(int userId);
        Task<PromoCode?> GetCupon(string cupon);
    }
}
