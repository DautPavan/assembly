using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Repository;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Domain.Enum;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Recipes> ListaReceita;

        //private readonly IRecipesServices _recipesServices = new RecipesServices();
        private readonly IRecipesServices _recipesServices;

        public IndexModel(ILogger<IndexModel> logger, IRecipesServices recipesServices)
        {
            _logger = logger;
            _recipesServices = recipesServices;
        }

        public void OnGet()
        {
           
            //ListaReceita = _recipesServices.GetAll();
            ListaReceita = _recipesServices.GetAllApproved();

        }
    }
}