
using Calzaditos.Database;
using Calzaditos.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Calzaditos.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(CalzaditosDbContext context) : base(context)
        {
            
        }
        public async Task<bool> LoginUser(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userName);
            if (user == null)
            { 
                return false;
            }

            return VerifyPassword(password, user.PasswordHash, user.PasswordSalt);
        }

        public async Task<bool> RegisterUser(string userName, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Email == userName))
            { 
                return false;
            }                

            CreatePasswordHash(password, out string hash, out string salt);

            var user = new User
            {
                Email = userName,
                PasswordHash = hash,
                PasswordSalt = salt,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = Convert.ToBase64String(hmac.Key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            passwordHash = Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            using var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(computedHash) == storedHash;
        }
    }
}
