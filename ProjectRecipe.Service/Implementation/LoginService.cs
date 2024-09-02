using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using ProjectRecipe.Model;
using ProjectRecipe.Repository;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Repository.Interface;
//using ProjectRecipeBack.Repository.Repository;
//using ProjectRecipeBack.Services.Interface;


namespace ProjectRecipe.Service
{
    public class LoginService : ILoginServices
    {
        // instalar nugpacket  Microsoft.AspNetCore.Authentication.Cookies
        //private readonly IUsersServices _Service = new UsersServices(); // mudar para injeção de depência

        private readonly IHttpContextAccessor _accessor;
        private readonly IUsersServices _Service;
        private readonly IPasswordHasher<Users> _hasher;   // usar criptogafia

       public LoginService(IHttpContextAccessor accessor, IPasswordHasher<Users> hasher, IUsersServices service)
       {
            _accessor = accessor;
            _Service = service;
            _hasher = hasher;
        }

        public async Task<bool> Login(string email, string senha)
        {
            // achar usuario na base pelo email
            var userLogin = _Service.LoginEmailUsers(email);
            if (userLogin.Email is null)
            {   
                return false; 
            }

            // verificar senha com hashed
            PasswordVerificationResult senhaOK = _hasher.VerifyHashedPassword(userLogin, userLogin.Password, senha);
            if (senhaOK == PasswordVerificationResult.Failed)
            {
                return false;
            }

            //verificar senha sem hasck
            //if (!userLogin.Password.Equals(senha))
            //{
            //    return false;
            //}

            var claims = new List<Claim>()
            {
                new("sub", userLogin.Id.ToString()),
                new("id", userLogin.Id.ToString()),
                new("name", userLogin.Name),
                new("email", userLogin.Email),
                new("role", userLogin.UserType.ToString()),
                new("roleid", ((int)userLogin.UserType).ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            await _accessor.HttpContext.SignInAsync(claimsPrincipal);

            return true;
        }

        public async Task Logout()
        {
            await _accessor.HttpContext.SignOutAsync();
        }

        public void Register(Users registro)
        {
            registro.Password = _hasher.HashPassword(registro, registro.Password);
            int cadastoruUser = _Service.Add(registro);
        }
    }
}

