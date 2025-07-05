namespace Calzaditos.Repositories
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(string userName, string fullName, string password);
        Task<bool> LoginUser(string userName, string password);
    }
}
