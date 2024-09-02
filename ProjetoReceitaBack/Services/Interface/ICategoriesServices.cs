using ProjectRecipeBack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipeBack.Services.Interface
{
    public interface ICategoriesServices
    {
        public int Add(Categories categoria);
        public List<Categories> GetAll();
        public Categories Get(int id);
        public Categories Update(Categories categoria);
        public bool DeleteId(int id);
        public bool Delete(int id);
    }
}
