using Postie.Core.Models;

namespace Postie.Core.Contracts
{
    public interface IUserDbRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
