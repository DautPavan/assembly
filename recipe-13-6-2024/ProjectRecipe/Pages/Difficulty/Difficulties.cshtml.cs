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
    public class DifficultiesModel : PageModel
    {
        public List<Difficulties> ListaGeral = new List<Difficulties>();

        private readonly IDifficultiesServices novoItem;
        public DifficultiesModel(IDifficultiesServices dificuldadeServices)
        {
            novoItem = dificuldadeServices;
        }


       // private IDifficultiesServices novoItem = new DifficultiesServices();

        public void OnGet()
        {
            ListaGeral = novoItem.GetAll();
        }

        public IActionResult OnPost(string IdDeletar)
        {
            int deletar = Convert.ToInt32(IdDeletar);

            if (deletar > 0)
            {
                var deletadoOk = novoItem.Delete(deletar);
                if (deletadoOk == false)
                {
                    //Fazer rotina de tratamento de erro
                }
            }

            return RedirectToPage("/Difficulty/Difficulties");
        }
    }
}
