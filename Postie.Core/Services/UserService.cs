using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.Core.Services
{
    public class UserService : IUserService
    {
        public readonly IUserDbRepository _userDbRepository;
        public UserService(IUserDbRepository userDbRepository)
        {
            _userDbRepository = userDbRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userDbRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userDbRepository.GetUserById(id);
        }

        public async Task CreateUser(User user)
        {
            await _userDbRepository.CreateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userDbRepository.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userDbRepository.DeleteUser(id);
        }
    }
}
