using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.Core.Services
{
    public class PostService : IPostService
    {
        public readonly IPostDbRepository _postDbRepository;
        public PostService(IPostDbRepository postDbRepository)
        {
            _postDbRepository = postDbRepository;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _postDbRepository.GetAllPosts();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _postDbRepository.GetPostById(id);
        }

        public async Task CreatePost(Post post)
        {
            await _postDbRepository.CreatePost(post);
        }

        public async Task UpdatePost(Post post)
        {
            await _postDbRepository.UpdatePost(post);
        }

        public async Task DeletePost(int id)
        {
            await _postDbRepository.DeletePost(id);
        }
    }
}
