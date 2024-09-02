using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using ProjectRecipe.Model;
using ProjectRecipe.Service;

//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Services.Services;
//using ProjectRecipeBack.Repository.Repository;

using System.Runtime.CompilerServices;
//using ProjectRecipeBack.Repository.Interface;


namespace ProjectRecipe.Pages.Login
{
    public class LoginUserModel : PageModel
    {
        // grupo para autenticaçoes IOC
        private readonly ILoginServices _authenticationService;
        //private readonly IUsers _Repository;
        //private readonly IUsersServices _Service;


        //public Users usuario = new Users();

        //public LoginUserModel(ILoginServices authenticationService, IUsers Repository, IUsersServices Service)
        public LoginUserModel(ILoginServices authenticationService)
        {
            this._authenticationService = authenticationService;
            //_Repository = Repository;
            //_Service = Service;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string Email, string Password)
        {
            var isSuccess = await _authenticationService.Login(Email, Password);
            if (!isSuccess)
            {
                return RedirectToPage("/Login/LoginErro", new { mensagemError = "Usuario nao cadastrado ou Senha errada" });
            }
            return Redirect("/Index");

        }




        /* OLD antes IOC e microsoft autorizaçao  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private readonly IUsersServices usersServices = new UsersServices();
        public Users usuario = new Users();

        public void OnGet()
        {
        }
        public IActionResult OnPost(string Email, string Password) 
        {
            usuario = usersServices.LoginUser(Email, Password); 

            if(usuario != null)
            {
                // fazer rotina pra logar
                Console.WriteLine("logado");
            }
            else
            {
                return RedirectToPage("/Login/LoginErro", new { mensagemError = "Usuario nao cadastrado ou Senha errada" });

            }

            return RedirectToPage("/Index");

        }    
        >>>> OLD antes IOC e microsoft autorizaçao >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        */


    }
}
