using Calzaditos.Database;
using Calzaditos.Models;
using Microsoft.EntityFrameworkCore;

namespace Calzaditos.Repositories
{
    public class CartRepository : BaseRepository
    {
        public CartRepository(CalzaditosDbContext context) : base(context)
        {

        }

        public async Task<Cart?> GetCart(int id) => 
            await _context.Carts
                .Include(c => c.Products)
                    .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<bool> AddProduct(int userId, int productId, int units)
        {
            try
            {
                var userExists = await _context.Users.AnyAsync(x => x.Id == userId && x.DeletedAt == null); //TODO remover validación cuando haya autenticación y autorización
                var productExists = await _context.Products.AnyAsync(p => p.Id == productId && p.DeletedAt == null);
                
                if (!userExists || !productExists) 
                {
                    return false;
                }

                var cart = await _context.Carts
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.DeletedAt == null);

                if(cart is null) 
                {
                    cart = new Cart { UserId = userId };
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                }                

                var product = new ProductCart 
                { 
                    CartId = cart.Id,
                    ProductId = productId,
                    Units = units                    
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
