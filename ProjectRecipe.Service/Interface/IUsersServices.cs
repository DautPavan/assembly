using ProjectRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipe.Service
{
    public interface IUsersServices
    {
        public int Add(Users usuario);
        public List<Users> GetAll();
        public Users Get(int id);
        public Users Update(Users usuario);
        public bool DeleteId(int id); 
        public bool Delete(int id);
        public Users LoginUser(string email, string senha);
        public bool LoginEmail(string email);
        public Users LoginEmailUsers(string email);

    }
}
