using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.FrontEnd.Pages
{
    public class IndexModel : PageModel

    {
        public readonly IBusinessLogicService _businessLogicService;
        public List<Post> allPosts;

        public IndexModel (IBusinessLogicService businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }

        public async Task OnGet()
        {
            allPosts = await _businessLogicService.GetAllPosts();
        }
    }
}