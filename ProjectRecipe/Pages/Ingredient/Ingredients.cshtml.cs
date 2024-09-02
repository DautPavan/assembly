using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Repository.Interface;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Ingredient
{
    [Authorize(policy: "user")] // Authenticated
    public class IngredientsModel : PageModel
    {
        private readonly IIngredientsServices novoIngrediente;

        public IngredientsModel(IIngredientsServices novoIngrediente)
        {
            this.novoIngrediente = novoIngrediente;
        }

       // private IIngredientsServices novoIngrediente = new IngredientsServices();
        public int IdRecipeSelecionada { get; set; }    
        public List<Ingredients> ListaIngredientes = new List<Ingredients>();

        public void OnGet(int id)
        {
            IdRecipeSelecionada = id;

            ListaIngredientes = novoIngrediente.GetAllIdRecipe(id);
        }

        public IActionResult OnPost(string IdDeletar)
        {
            string idRecipe = Request.Form["id-recipe"];
            int deletar = Convert.ToInt32(IdDeletar);

            if (deletar > 0)
            { 
                var deletadoOk = novoIngrediente.Delete(deletar);
                if (deletadoOk == false)
                {
                    //Fazer rotina de tratamento de erro
                }
            }
            return RedirectToPage("/Ingredient/Ingredients", new { id = idRecipe });
            //return RedirectToPage("/Ingredient/Ingredients");
        }
    }
}
