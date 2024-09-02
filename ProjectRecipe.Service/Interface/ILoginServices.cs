using ProjectRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipe.Service
{
    public interface ILoginServices
    {
        Task<bool> Login(string email, string senha);
        Task Logout();
        void Register(Users registerDto);

    }
}
