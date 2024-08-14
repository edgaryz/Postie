using Postie.Core.Models;

namespace Postie.Core.Contracts
{
    public interface IBusinessLogicService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(int id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
