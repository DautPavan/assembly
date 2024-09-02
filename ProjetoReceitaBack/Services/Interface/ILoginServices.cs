using ProjectRecipeBack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipeBack.Services.Interface
{
    public interface ILoginServices
    {
        Task<bool> Login(string email, string senha);
        Task Logout();
        void Register(Users registerDto);

    }
}
