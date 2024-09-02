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
    public class UserUpdateModel : PageModel
    {
        //private IUsersServices _servicos = new UsersServices();
        private IUsersServices _servicos;
        public UserUpdateModel(IUsersServices servicos)
        {
            _servicos = servicos;
        }

        [BindProperty]

        public Users novoDado { set; get; }

        public void OnGet(int id)
        {
            novoDado = _servicos.Get(id);
        }
        public IActionResult OnPost()
        {
            _servicos.Update(novoDado);
            return RedirectToPage("/User/Users");

        }
    }
}
