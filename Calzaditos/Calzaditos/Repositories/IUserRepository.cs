using Calzaditos.Models;

namespace Calzaditos.Repositories
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(string userName, string fullName, string password);
        Task<User?> LoginUser(string userName, string password);

        public Task<User?> GetUser(int userId);
    }
}
