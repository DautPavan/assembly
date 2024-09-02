using ProjectRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipe.Service
{
    public interface IRecipesServices
    {
        public int Add(Recipes receita);
        public List<Recipes> GetAll();
        public Recipes Get(int id);
        public Recipes Update(Recipes receita);
        public bool DeleteId(int id);
        public bool Delete(int id);
        public List<Recipes> GetAllApproved();

    }
}
