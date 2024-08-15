using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.FrontEnd.Pages
{
    public class UsersModel : PageModel
    {
        public readonly IBusinessLogicService _businessLogicService;

        public UsersModel(IBusinessLogicService businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }

        [BindProperty]
        public User User { get; set; }
        public List<Post> AllPostsByUser { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User != null)
            {
                AllPostsByUser = await _businessLogicService.GetPostsByUser(User);

                return Page();
            }
            return null;
        }
    }
}