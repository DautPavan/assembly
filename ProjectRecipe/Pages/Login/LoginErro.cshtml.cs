using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectRecipe.Pages.Login
{
    public class LoginErroModel : PageModel
    {
        public string msgErro {  get; set; } 
        public void OnGet(string mensagemError)
        {
            msgErro = mensagemError;

        }
    }
}
