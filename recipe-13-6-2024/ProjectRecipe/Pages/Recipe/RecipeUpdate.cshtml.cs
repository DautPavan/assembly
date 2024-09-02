using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectRecipe.Model;
using ProjectRecipe.Service;


//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Recipe
{
    [Authorize(policy: "user")] // Authenticated
    public class RecipeUpdateModel : PageModel
    {
        //private IRecipesServices _servicos = new RecipesServices();
        //private IDifficultiesServices _difficulties = new DifficultiesServices();
        //private ICategoriesServices _categories = new CategoriesServices();

        private IRecipesServices _servicos;
        private ICategoriesServices _categories;
        private IDifficultiesServices _difficulties;
        public RecipeUpdateModel(ICategoriesServices categoriaServices, IDifficultiesServices difficulties, IRecipesServices servicos)
        {
            _categories = categoriaServices;
            _difficulties = difficulties;
            _servicos = servicos;
        }

        [BindProperty]
        public Recipes novoDado { set; get; }
        public List<Difficulties> dadosDifficulty { set; get; }
        public List<Categories> dadosCategory { set; get; }


        public void OnGet(int id)
        {
            dadosDifficulty = _difficulties.GetAll();

            dadosCategory = _categories.GetAll();

            novoDado = _servicos.Get(id);
        }
        public IActionResult OnPost()
        {
            _servicos.Update(novoDado);
            return RedirectToPage("/Recipe/Recipes");

        }
    }
}
