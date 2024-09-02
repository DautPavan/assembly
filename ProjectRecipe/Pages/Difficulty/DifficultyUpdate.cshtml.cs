using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using ProjectRecipe.Model;
using ProjectRecipe.Service;


//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Difficulty
{
    [Authorize(policy: "gestor")] // Authenticated
    public class DifficultyUpdateModel : PageModel
    {
        private readonly IDifficultiesServices _servicos;

        [BindProperty]
        public Difficulties novoDado { set; get; }

        public DifficultyUpdateModel(IDifficultiesServices dificuldadeServices)
        {
            _servicos = dificuldadeServices;
        }


       // private IDifficultiesServices _servicos = new DifficultiesServices();

        public void OnGet(int id)
        {
            novoDado = _servicos.Get(id);
        }
        public IActionResult OnPost()
        {
            _servicos.Update(novoDado);
            return RedirectToPage("/Difficulty/Difficulties");

        }

    }
}
