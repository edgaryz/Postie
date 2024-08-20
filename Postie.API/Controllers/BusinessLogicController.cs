using Microsoft.AspNetCore.Mvc;
using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.API.Controllers
{
    public class BusinessLogicController : Controller
    {
        private readonly IBusinessLogicService _businessLogicService;
        public BusinessLogicController(IBusinessLogicService businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }

        //Posts
        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var allPosts = await _businessLogicService.GetAllPosts();
                return Ok(allPosts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts(int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                var pagedPosts = await _businessLogicService.GetPagedPosts(pageNumber, pageSize);
                var totalPostsCount = await _businessLogicService.GetTotalPostsCount();
                return Ok(new { posts = pagedPosts, totalCount = totalPostsCount });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Enternal server error");
            }
        }

        [HttpPost("GetPostsByUser")]
        public async Task<IActionResult> GetPostsByUser([FromBody] User user)
        {
            try
            {
                var post = await _businessLogicService.GetPostsByUser(user);
                return Ok(post);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            try
            {
                await _businessLogicService.CreatePost(post);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating a post: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }

                return Problem();
            }
        }

        [HttpPatch("UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Post updatedPost)
        {
            try
            {
                await _businessLogicService.UpdatePost(id, updatedPost);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error while updating the post: ", ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating the post: ", ex.Message);
                return Problem();
            }
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _businessLogicService.DeletePost(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting the post: ", ex.Message);
                return NotFound();
            }
        }

        [HttpGet("GetPostsByTitleOrContent/{searchContent}")]
        public async Task<IActionResult> GetPostsByTitleOrContent(string searchContent = null)
        {
            try
            {
                var postByTitleOrContent = await _businessLogicService.GetPostsByTitleOrContent(searchContent);
                return Ok(postByTitleOrContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        //Users
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var allUsers = await _businessLogicService.GetAllUsers();
                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _businessLogicService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                await _businessLogicService.CreateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                await _businessLogicService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _businessLogicService.DeleteUser(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
