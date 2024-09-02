using ProjectRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipe.Service
{
    public interface IDifficultiesServices
    {
        public int Add(Difficulties dificuldade);
        public List<Difficulties> GetAll();
        public Difficulties Get(int id);
        public Difficulties Update(Difficulties dificuldade);
        public bool DeleteId(int id);
        public bool Delete(int id);
    }
}
