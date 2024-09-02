using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using ProjectRecipe.Model;
using ProjectRecipe.Service;


//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Domain.Enum;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.PublishEvalution
{
    [Authorize(policy: "gestor")] // Authenticated
    public class PublishModel : PageModel
    {
        public List<Evaluations> ListaAvaliacao = new List<Evaluations>();
        //private IEvaluationServices novoAvaliacao = new EvaluationsServices();

        private readonly IEvaluationServices novoAvaliacao;
        public PublishModel(IEvaluationServices evalutionServices)
        {
            novoAvaliacao = evalutionServices;
        }

        public void OnGet()
        {
            ListaAvaliacao = novoAvaliacao.GetAll();
        }

        public IActionResult OnPost(int idAvaliar)
        {
            ApprovalEnum aprovado = ApprovalEnum.Approved;

            if (Request.Form.ContainsKey("aprovado"))
            {
                aprovado = ApprovalEnum.NoApproved;
            }

            Evaluations mudarEval;
            mudarEval = novoAvaliacao.Get(idAvaliar);
            mudarEval.Approval = aprovado;
            novoAvaliacao.Update(mudarEval);

            return RedirectToPage("/PublishEvalution/Publish");
        }
    }
}
