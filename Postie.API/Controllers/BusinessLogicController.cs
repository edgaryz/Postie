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
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await _businessLogicService.GetPostById(id);
                return Ok(post);
            }
            catch
            {
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
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost([FromBody] Post post)
        {
            try
            {
                await _businessLogicService.UpdatePost(post);
                return Ok();
            }
            catch
            {
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
            catch
            {
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
            catch
            {
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
            catch
            {
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
            catch
            {
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
            catch
            {
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
