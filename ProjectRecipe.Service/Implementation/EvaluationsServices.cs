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



namespace ProjectRecipe.Service
{
    public class EvaluationsServices : IEvaluationServices
    {
        //public readonly EvaluationsRepository Instance = new EvaluationsRepository();

        private readonly IEvaluations Instance;
        public EvaluationsServices(IEvaluations _Repository)
        {
            Instance = _Repository;
        }

        public int Add(Evaluations avaliacao)
        {
            if (avaliacao == null)
            {
                return -1;
            }

            return Instance.Add(avaliacao);
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

        public Evaluations Get(int id)
        {
            if(id<=0)
            {
                return null;
            }

            return Instance.Get(id);
        }

        public List<Evaluations> GetAll()
        {
            return Instance.GetAll();
        }

        public List<Evaluations> GetAllRecipeApproved(int id)
        {
            return Instance.GetAllRecipeApproved(id);   
        }

        public Evaluations Update(Evaluations avaliacao)
        {
            if(avaliacao == null)
            {
                return null;
            }

            return Instance.Update(avaliacao);
        }
    }
}
