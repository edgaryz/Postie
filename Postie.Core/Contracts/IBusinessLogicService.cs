using Postie.Core.Models;

namespace Postie.Core.Contracts
{
    public interface IBusinessLogicService
    {
        Task<List<Post>> GetAllPosts();
        Task<List<Post>> GetPostsByUser(User user);
        Task CreatePost(Post post);
        Task UpdatePost(int id, Post updatedPost);
        Task DeletePost(int id);
        Task<List<Post>> GetPostsByTitleOrContent(string searchContent = null);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task<User> GetUserByEmail(string email);
        Task<List<Post>> GetPagedPosts(int pageNumber, int pageSize);
        Task<int> GetTotalPostsCount();
    }
}
