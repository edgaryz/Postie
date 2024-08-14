using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.Core.Services
{
    public class BusinessLogicService : IBusinessLogicService
    {
        public readonly IPostRepository _postService;
        public readonly IUserService _userService;
        public BusinessLogicService(IPostRepository postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        //Post
        public async Task<List<Post>> GetAllPosts()
        {
            return await _postService.GetAllPosts();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _postService.GetPostById(id);
        }

        public async Task CreatePost(Post post)
        {
            await _postService.CreatePost(post);
        }

        public async Task UpdatePost(Post post)
        {
            await _postService.UpdatePost(post);
        }

        public async Task DeletePost(int id)
        {
            await _postService.DeletePost(id);
        }

        //User
        public async Task<List<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        public async Task CreateUser(User user)
        {
            await _userService.CreateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userService.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
        }

    }
}
