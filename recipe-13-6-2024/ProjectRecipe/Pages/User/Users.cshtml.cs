using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.User
{
    [Authorize(policy: "admin")] // Authenticated
    public class UsersModel : PageModel
    {
        //private IUsersServices novoUsuario = new UsersServices();
        private IUsersServices novoUsuario;
        public UsersModel(IUsersServices novoUsuario)
        {
            this.novoUsuario = novoUsuario;
        }

        public List<Users> ListaUsuarios = new List<Users>();
        public void OnGet()
        {
            ListaUsuarios = novoUsuario.GetAll();
        }

        public IActionResult OnPost(string IdDeletar)
        {
            int deletar = Convert.ToInt32(IdDeletar);

            if(deletar > 0)
            {
                var deletadoOk = novoUsuario.Delete(deletar);
                if(deletadoOk == false)
                {
                    //Fazer rotina de tratamento de erro
                }
            }

            return RedirectToPage("/User/Users");
        }
    }
}
