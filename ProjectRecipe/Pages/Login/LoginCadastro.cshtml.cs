using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;


//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

namespace ProjectRecipe.Pages.Login
{
    public class LoginUtilizadorModel : PageModel
    {
        //private readonly IUsersServices usersServices = new UsersServices(); // usar injeção de dependência
        // public ILoginServices _services = new LoginService();

        private readonly IUsersServices usersServices;
        public readonly ILoginServices _serviceLogin;
        public LoginUtilizadorModel(IUsersServices usersServices, ILoginServices serviceLogin)
        {
            this.usersServices = usersServices;
            _serviceLogin = serviceLogin;
        }

        public Users usuario = new Users(); 

        public void OnGet()
        {
        }
        public IActionResult OnPost(string Name, string Email, string Phone, string Password)
        {
            //Checar se o email está em uso
            bool emaiLiberado = false;

            emaiLiberado = usersServices.LoginEmail(Email);
            if(emaiLiberado) 
            {
                usuario.Name = Name;
                usuario.Email = Email;
                usuario.Phone = Phone;
                usuario.Password = Password;
                usuario.UserType = UserTypeEnum.user;

                //usersServices.Add(usuario);

                _serviceLogin.Register(usuario);

            }else
            {
                return RedirectToPage("/Login/LoginErro", new { mensagemError = "Email já cadastrado na base de dados - tente outro" });

            }

            return RedirectToPage("/Login/LoginUser");

        }
    }
}
