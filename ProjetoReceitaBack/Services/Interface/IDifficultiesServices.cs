﻿using ProjectRecipeBack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipeBack.Services.Interface
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
