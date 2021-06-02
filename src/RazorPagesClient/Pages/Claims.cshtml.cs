using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesClient.Pages
{
    [Authorize(Roles = "admin")]
    public class ClaimsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
