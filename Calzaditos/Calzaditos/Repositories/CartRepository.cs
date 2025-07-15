using Calzaditos.Database;
using Calzaditos.Models;
using Microsoft.EntityFrameworkCore;

namespace Calzaditos.Repositories
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(CalzaditosDbContext context) : base(context)
        {

        }

        public async Task<Cart?> GetCart(int userId) => 
            await _context.Carts
                .Include(c => c.Products)
                    .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

        public async Task<PromoCode?> GetCupon(string cupon) =>
            await _context.PromoCodes
             .FirstOrDefaultAsync(c => c.Code == cupon);

        public async Task<bool> AddProduct(int userId, int productId, int units, int selectedSize)
        {
            try
            {
                var userExists = await _context.Users.AnyAsync(x => x.Id == userId && x.DeletedAt == null); //TODO remover validación cuando haya autenticación y autorización
                var productExists = await _context.Products.AnyAsync(p => p.Id == productId && p.DeletedAt == null);

                if (!userExists || !productExists)
                {
                    return false;
                }

                if (units == 0)
                {
                    return await RemoveProduct(userId,productId);
                }

                var cart = await _context.Carts
                    .Include(x => x.Products)
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.DeletedAt == null);

                if (cart is null)
                {
                    cart = new Cart { UserId = userId };
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                }

                if (cart.Products.Any(x => x.ProductId == productId))
                {
                    var existingProduct = cart.Products.First(p => p.ProductId == productId);
                    _context.Remove(existingProduct);                    
                }

                var product = new ProductCart
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Units = units,
                    SelectedSize = selectedSize
                };
                _context.Add(product);                              

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //TODO Agregar logging
                return false;
            }
        }

        public async Task<bool> RemoveProduct(int userId, int productId) 
        {
            try
            {
                var userExists = await _context.Users.AnyAsync(x => x.Id == userId && x.DeletedAt == null);
                var cart = await _context.Carts
                    .Include(c => c.Products)
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.DeletedAt == null);

                if (!userExists || cart is null)
                {
                    return false;
                }                

                var product = cart.Products.FirstOrDefault(p => p.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //TODO Agregar logging
                return false;
            }
        }

        public async Task<bool> EmptyCart(int userId)
        {
            try
            {
                var userExists = await _context.Users.AnyAsync(x => x.Id == userId && x.DeletedAt == null);
                var cart = await _context.Carts
                    .Include(c => c.Products)
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.DeletedAt == null);

                if (!userExists || cart is null)
                {
                    return false;
                }                         

                foreach(var product in cart.Products) 
                {
                    _context.Remove(product);
                }
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //TODO Agregar logging
                return false;
            }
        }

        public async Task<bool> DeleteCart(int userId)
        {
            try
            {
                var userExists = await _context.Users.AnyAsync(x => x.Id == userId && x.DeletedAt == null);
                var cart = await _context.Carts
                    .AsTracking()
                    .Include(c => c.Products)
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.DeletedAt == null);

                if (!userExists || cart is null)
                {
                    return false;
                }

                cart.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //TODO Agregar logging
                return false;
            }
        }
    }
}
