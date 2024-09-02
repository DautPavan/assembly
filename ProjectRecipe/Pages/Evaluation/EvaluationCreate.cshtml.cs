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
    public class EvaluationCreateModel : PageModel
    {

        private readonly IEvaluationServices _servicos;
        public EvaluationCreateModel(IEvaluationServices evalutionServices)
        {
            _servicos = evalutionServices;
        }

        //private IEvaluationServices _servicos = new EvaluationsServices();
        [BindProperty]
        public Evaluations novoDado { set; get; }
        public void OnGet()
        {
            novoDado = new Evaluations();
        }

        public IActionResult OnPost()
        {
            _servicos.Add(novoDado);
            return RedirectToPage("/Evaluation/Evaluations");
        }
    }
}
