//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Repository.Repository;
//using ProjectRecipeBack.Services.Interface;

using ProjectRecipe.Model;
using ProjectRecipe.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ProjectRecipe.Service
{
    public class UsersServices : IUsersServices
    {
        //public readonly UsersRepository Instance = new UsersRepository();

        private readonly IUsers Instance;
        public UsersServices(IUsers usersRepository)
        {
            Instance = usersRepository;
        }
        public int Add(Users usuario)
        {
            if (usuario == null)
            {
                return -1;
            }

            //usuario.Password = _senhaCripto.HashPassword(usuario, usuario.Password);
            return Instance.Add(usuario);

        }

        public bool Delete(int id)
        {
            if (id<=0)
            {
                return false;
            }

            return Instance.Delete(id); 
        }

        public bool DeleteId(int id)
        {
            return Delete(id);
        }

        public Users Get(int id)
        {
            if(id<=0)
            {
                return null;
            }

            return Instance.Get(id);
        }

        public List<Users> GetAll()
        {
            return Instance.GetAll();
        }

        public bool LoginEmail(string email)
        {
            return Instance.LoginEmail(email);
        }

        public Users LoginEmailUsers(string email)
        {
            return Instance.LoginEmailUsers(email);
        }

        public Users LoginUser(string email, string senha)
        {
            return Instance.LoginUser(email, senha);
        }

        public Users Update(Users usuario)
        {
            if(usuario == null)
            {
                return null;
            }

            return Instance.Update(usuario);
        }
    }
}
