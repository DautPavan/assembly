using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;


//using ProjectRecipeBack.Domain.Enum;
//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

using Microsoft.AspNetCore.Authorization;

namespace ProjectRecipe.Pages.PublishRecipe
{
    [Authorize(policy: "gestor")] // Authenticated
    public class PublishRecModel : PageModel
    {

        //private IRecipesServices novoReceita = new RecipesServices();

        private IRecipesServices novoReceita;

        public PublishRecModel(IRecipesServices novoReceita)
        {
            this.novoReceita = novoReceita;
        }

        public List<Recipes> ListaReceita = new List<Recipes>();
        public void OnGet()
        {
            ListaReceita = novoReceita.GetAll();
        }

        public IActionResult OnPost(int idAvaliar)
        {
            ApprovalEnum aprovado = ApprovalEnum.Approved;

            if (Request.Form.ContainsKey("aprovado"))
            {
                aprovado = ApprovalEnum.NoApproved;
            }

            Recipes mudarEval;
            mudarEval = novoReceita.Get(idAvaliar);
            mudarEval.Approval = aprovado;
            novoReceita.Update(mudarEval);

            return RedirectToPage("/PublishRecipe/PublishRec");
        }
    }
}
