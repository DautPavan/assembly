using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;
//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;
using System.Collections.Generic;

namespace ProjectRecipe.Pages.Recipe
{
    [Authorize(policy: "user")] // Authenticated
    public class RecipeCreateModel : PageModel
    {
        //private IRecipesServices _servicos = new RecipesServices();
        //private IDifficultiesServices _difficulties = new DifficultiesServices();
        //private ICategoriesServices _categories = new CategoriesServices();

        private ICategoriesServices _categories;
        private IDifficultiesServices _difficulties;
        private IRecipesServices _servicos;
        public RecipeCreateModel(ICategoriesServices categoriaServices, IDifficultiesServices difficulties, IRecipesServices servicos)
        {
            _categories = categoriaServices;
            _difficulties = difficulties;
            _servicos = servicos;
        }


        [BindProperty]
        public Recipes novoDado { set; get; }
        public List<Difficulties> dadosDifficulty { set; get; }
        public List<Categories> dadosCategory { set; get; }

        //construtor
        public void OnGet()
        {
            dadosDifficulty = _difficulties.GetAll();

            dadosCategory = _categories.GetAll();   

            novoDado = new Recipes();
        }

        public IActionResult OnPost()
        {
            _servicos.Add(novoDado);
            return RedirectToPage("/Recipe/Recipes");
        }
    }
}
