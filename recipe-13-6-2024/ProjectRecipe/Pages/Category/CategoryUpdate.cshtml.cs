using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;


//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Category
{
    [Authorize(policy: "gestor")] // Authenticated
    public class CategoryUpdateModel : PageModel
    {
        private readonly ICategoriesServices _servicos;
        //private ICategoriesServices _servicos = new CategoriesServices();

        [BindProperty]
        public Categories novoDado { set; get; }

        public CategoryUpdateModel(ICategoriesServices categoriaServices)
        {
            _servicos = categoriaServices;
        }

        public void OnGet(int id)
        {
            novoDado = _servicos.Get(id);
        }
        public IActionResult OnPost()
        {
            _servicos.Update(novoDado);
            return RedirectToPage("/Category/Categories");

        }
    }
}
