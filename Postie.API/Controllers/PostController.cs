using Microsoft.AspNetCore.Mvc;
using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.API.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var allPosts = await _postService.GetAllPosts();
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
                var post = await _postService.GetPostById(id);
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
                await _postService.CreatePost(post);
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
                await _postService.UpdatePost(post);
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
                await _postService.DeletePost(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
