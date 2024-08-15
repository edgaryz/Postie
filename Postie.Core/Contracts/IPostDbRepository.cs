using Postie.Core.Models;

namespace Postie.Core.Contracts
{
    public interface IPostDbRepository
    {
        Task<List<Post>> GetAllPosts();
        Task<List<Post>> GetPostsByUser(User user);
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(int id);
    }
}
