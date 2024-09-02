using ProjectRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectRecipe.Repository
{
    public interface IEvaluations
    {
        public int Add(Evaluations avaliacao);
        public List<Evaluations> GetAll();
        public Evaluations Get(int id);
        public Evaluations Update(Evaluations avaliacao);
        public bool DeleteId(int id);
        public bool Delete(int id);
        public List<Evaluations> GetAllRecipeApproved(int id);

    }
}
