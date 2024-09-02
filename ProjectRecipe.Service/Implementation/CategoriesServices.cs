using ProjectRecipe.Model;
using ProjectRecipe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipe.Service
{
    public class CategoriesServices : ICategoriesServices
    {

        private readonly ICategories Instance;
        public CategoriesServices(ICategories  categoriesRepository)
        {
            Instance = categoriesRepository;
        }

        // anterio a imnjeçao de dependencia 
        //public readonly CategoriesRepository Instance = new CategoriesRepository();
        public int Add(Categories categoria)
        {
            

            if (categoria == null)
            {
                return -1;
            }

            return Instance.Add(categoria); 

        }

        public bool Delete(int id)
        {
            if(id <= 0)
            {
                return false;
            }

            return Instance.Delete(id);
        }

        public bool DeleteId(int id)
        {
            return Delete(id);
        }

        public Categories Get(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            return Instance.Get(id);    
        }

        public List<Categories> GetAll()
        {
            return Instance.GetAll();
        }

        public Categories Update(Categories categoria)
        {
            if(categoria == null)
            {
                return null;
            }

            return Instance.Update(categoria);      
        }
    }
}
