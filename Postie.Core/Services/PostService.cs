using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.Core.Services
{
    public class PostService : IPostRepository
    {
        public readonly IPostDbRepository _postDbRepository;
        public readonly IUserService _userService;
        public PostService(IPostDbRepository postDbRepository, IUserService userService)
        {
            _postDbRepository = postDbRepository;
            _userService = userService;
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
            var user = await _userService.GetUserById(post.User.Id);
            post.User = user;
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
