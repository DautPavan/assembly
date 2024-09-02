using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.User
{
    [Authorize(policy: "admin")] // Authenticated
    public class UsersCreateModel : PageModel
    {
        //private IUsersServices _servicos = new UsersServices();
        private IUsersServices _servicos;
        public UsersCreateModel(IUsersServices servicos)
        {
            _servicos = servicos;
        }

        [BindProperty]

        public Users novoDado { set; get; }
        public void OnGet()
        {
            novoDado = new Users();
        }

        public IActionResult OnPost()
        {
            _servicos.Add(novoDado);
            return RedirectToPage("/User/Users");
        }
    }
}
