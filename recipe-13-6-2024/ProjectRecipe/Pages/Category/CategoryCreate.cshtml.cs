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

    public class CategoryCreateModel : PageModel
    {
        private readonly ICategoriesServices _servicos;
        //private ICategoriesServices _servicos = new CategoriesServices();

        [BindProperty]
        public Categories novoDado { set; get; }

        public CategoryCreateModel(ICategoriesServices categoriaServices)
        {
            _servicos  = categoriaServices;
        }


        public void OnGet()
        {
            novoDado = new Categories();
        }
        public IActionResult OnPost() 
        {
            _servicos.Add(novoDado);
            return RedirectToPage("/Category/Categories");

        }
    }
}
