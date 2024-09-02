using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain.Enum;
//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

namespace ProjectRecipe.Pages.Favorites
{
    [Authorize(policy: "user")] // Authenticated
    public class FavoriteModel : PageModel
    {

        //private IRecipesServices novoReceita = new RecipesServices();

        public List<Recipes> ListaReceita = new List<Recipes>();
        private IRecipesServices novoReceita;

        public FavoriteModel(IRecipesServices _novoReceita)
        {
            novoReceita = _novoReceita;
        }

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
                        ListaReceita.Add(ListaGeral[i]);
                    }
                }
            }
            else
            {
                ListaReceita = novoReceita.GetAll();
            }
        }

        public IActionResult OnPost(int idAvaliar)
        {
            FavoriteEnum favorito = FavoriteEnum.Favorite;

            if (Request.Form.ContainsKey("Favorite"))
            {
                favorito = FavoriteEnum.NoFavorite;
            }

            Recipes mudarEval;
            mudarEval = novoReceita.Get(idAvaliar);
            mudarEval.Favorite = favorito;
            novoReceita.Update(mudarEval);

            return RedirectToPage("/Favorites/Favorite");
        }
    }
}
