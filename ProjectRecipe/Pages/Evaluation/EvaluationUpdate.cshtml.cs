using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Evaluation
{
    [Authorize(policy: "gestor")] // Authenticated
    public class EvaluationUpdateModel : PageModel
    {

        private readonly IEvaluationServices _servicos;
        public EvaluationUpdateModel(IEvaluationServices evalutionServices)
        {
            _servicos = evalutionServices;
        }

        //private IEvaluationServices _servicos = new EvaluationsServices();

        [BindProperty]

        public Evaluations novoDado { set; get; }

        public void OnGet(int id)
        {
            novoDado = _servicos.Get(id);
        }
        public IActionResult OnPost()
        {
            _servicos.Update(novoDado);
            return RedirectToPage("/Evaluation/Evaluations");

        }
    }
}
