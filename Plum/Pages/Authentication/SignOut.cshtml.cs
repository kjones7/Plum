using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Plum.Pages.Authentication
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties { RedirectUri = returnUrl };

            const string scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            return SignOut(properties, scheme);
        }
    }
}