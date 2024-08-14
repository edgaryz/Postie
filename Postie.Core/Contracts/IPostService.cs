using Postie.Core.Models;

namespace Postie.Core.Contracts
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(int id);
    }
}
