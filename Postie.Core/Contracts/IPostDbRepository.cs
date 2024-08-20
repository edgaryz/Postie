using Postie.Core.Models;

namespace Postie.Core.Contracts
{
    public interface IPostDbRepository
    {
        Task<List<Post>> GetAllPosts();
        Task<List<Post>> GetPostsByUser(User user);
        Task CreatePost(Post post);
        Task UpdatePost(int id, Post updatedPost);
        Task DeletePost(int id);
        Task<List<Post>> GetPostsByTitleOrContent(string searchContent = null);
        Task<List<Post>> GetPagedPosts(int pageNumber, int pageSize);
        Task<int> GetTotalPostsCount();
    }
}
