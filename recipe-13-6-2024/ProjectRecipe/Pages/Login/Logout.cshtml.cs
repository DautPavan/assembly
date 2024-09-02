using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Service;
//using ProjectRecipeBack.Services.Interface;

namespace ProjectRecipe.Pages.Login
{
    public class LogoutModel : PageModel
    {
        private readonly ILoginServices _authService;

        public LogoutModel(ILoginServices authService)
        {
            this._authService = authService;
        }

        public async Task<IActionResult> OnGet()
        {
            await _authService.Logout();
            // envia para o index
            return Redirect("/Index");
        }
    }
}
