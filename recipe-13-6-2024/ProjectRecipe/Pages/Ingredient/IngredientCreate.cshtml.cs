using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Ingredient
{
    [Authorize(policy: "user")] // Authenticated
    public class IngredientCreateModel : PageModel
    {
        //private IIngredientsServices _servicos = new IngredientsServices();

        private IIngredientsServices _servicos;
        public IngredientCreateModel(IIngredientsServices servicos)
        {
            _servicos = servicos;
        }

        [BindProperty]
        public Ingredients novoDado { set; get; }
        public int idRecipe2 { get; set; }
        public void OnGet(int id)
        {
            idRecipe2 = id;
            novoDado = new Ingredients();
        }

        public IActionResult OnPost(int idRecipe)
        {
            //string idVolta = Request.Form["IdRecipe"];  // for funciona se tiver name no imput
            _servicos.Add(novoDado);
            return RedirectToPage("/Ingredient/Ingredients", new { id = idRecipe });
           
        }
    }
}
