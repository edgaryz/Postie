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

        public async Task<List<Post>> GetPostsByUser(User user)
        {
            return await _postDbRepository.GetPostsByUser(user);
        }

        public async Task CreatePost(Post post)
        {
            var user = await _userService.GetUserByEmail(post.User.Email);
            if(user == null)
            {
                user = new User
                {
                    Name = post.User.Name,
                    Email = post.User.Email
                };
                await _userService.CreateUser(user);
            }

            post.User = user;
            await _postDbRepository.CreatePost(post);
        }

        public async Task UpdatePost(int id, Post updatedPost)
        {
            await _postDbRepository.UpdatePost(id, updatedPost);
        }

        public async Task DeletePost(int id)
        {
            await _postDbRepository.DeletePost(id);
        }

        public async Task<List<Post>> GetPostsByTitleOrContent(string searchContent = null)
        {
            if(searchContent == null)
            {
                return await _postDbRepository.GetAllPosts();
            }

            return await _postDbRepository.GetPostsByTitleOrContent(searchContent);
        }
    }
}
