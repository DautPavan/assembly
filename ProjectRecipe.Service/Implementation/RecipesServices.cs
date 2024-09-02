//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Repository.Interface;
//using ProjectRecipeBack.Repository.Repository;
//using ProjectRecipeBack.Services.Interface;

using ProjectRecipe.Model;
using ProjectRecipe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectRecipe.Model;
using ProjectRecipe.Repository;

namespace ProjectRecipe.Service
{
    public class RecipesServices : IRecipesServices
    {

        private readonly IRecipes Instance;
        public RecipesServices(IRecipes recipesRepository)
        {
            Instance = recipesRepository;
        }

//        public readonly RecipesRepository Instance = new RecipesRepository();
        public int Add(Recipes receita)
        {
            if (receita == null)
            {
                return -1;
            }

            return Instance.Add(receita);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            return Instance.Delete(id);
        }

        public bool DeleteId(int id)
        {
            return Delete(id);
        }

        public Recipes Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return Instance.Get(id);
        }

        public List<Recipes> GetAll()
        {
            return Instance.GetAll();
        }

        public Recipes Update(Recipes receita)
        {
            if (receita == null)
            {
                return null;
            }

            return Instance.Update(receita);
        }
        public List<Recipes> GetAllApproved()
        {
            List<Recipes> recipesAprovados = new List<Recipes>();

            List<Recipes> recipesTotal = new List<Recipes>();

            recipesTotal = Instance.GetAll();

            for(int i = 0; i < recipesTotal.Count; i++) 
            {
                if (recipesTotal[i].Approval == ApprovalEnum.Approved)
                {
                    recipesAprovados.Add(recipesTotal[i]);
                }
            }

            return recipesAprovados;

        }
    }
}
