using Postie.Core.Contracts;
using Postie.Core.Models;
using Postie.Core.Repositories;

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

        public async Task<List<Post>> GetPostsByUser(User user)
        {
            return await _postService.GetPostsByUser(user);
        }

        public async Task CreatePost(Post post)
        {
            await _postService.CreatePost(post);
        }

        public async Task UpdatePost(int id, Post updatedPost)
        {
            await _postService.UpdatePost(id, updatedPost);
        }

        public async Task DeletePost(int id)
        {
            await _postService.DeletePost(id);
        }

        public async Task<List<Post>> GetPostsByTitleOrContent(string searchContent = null)
        {
            return await _postService.GetPostsByTitleOrContent(searchContent);
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

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userService.GetUserByEmail(email);
        }
    }
}
