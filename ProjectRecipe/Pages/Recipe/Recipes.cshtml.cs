using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Domain.Enum;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Recipe
{
    [Authorize(policy: "user")] // Authenticated
    public class RecipesModel : PageModel
    {

        //private IRecipesServices novoReceita = new RecipesServices();
        private IRecipesServices novoReceita;

        public RecipesModel(IRecipesServices novoReceita)
        {
            this.novoReceita = novoReceita;
        }

        public List<Recipes> ListaReceitas = new List<Recipes>();
        public void OnGet()
        {
            int idUser = 0;
            int userCargo = 0;

            var tipoUser = User.FindFirst("roleid");
            if (tipoUser != null)
            {
                userCargo = int.Parse(tipoUser.Value);
            }

            if (userCargo == (int) UserTypeEnum.user)
            {
                List<Recipes> ListaGeral = new List<Recipes>();
                var userLogado = User.FindFirst("id");
                if (userLogado != null)
                {
                    idUser = int.Parse(userLogado.Value);
                }
                ListaGeral = novoReceita.GetAll();

                for (int i = 0; i < ListaGeral.Count; i++)
                {
                    if (ListaGeral[i].IdUser == idUser)
                    {
                        ListaReceitas.Add(ListaGeral[i]);
                    }
                }
            }
            else
            {
                ListaReceitas = novoReceita.GetAll();
            }

            
        }

        public IActionResult OnPost(string IdDeletar)
        {
            int deletar = Convert.ToInt32(IdDeletar);

            if (deletar > 0)
            {
                var deletadoOk = novoReceita.Delete(deletar);
                if (deletadoOk == false)
                {
                    //Fazer rotina de tratamento de erro
                }
            }

            return RedirectToPage("/Recipe/Recipes");
        }
    }
}
