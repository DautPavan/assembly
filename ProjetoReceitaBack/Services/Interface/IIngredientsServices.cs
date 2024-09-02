﻿using ProjectRecipeBack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipeBack.Services.Interface
{
    public interface IIngredientsServices
    {
        public int Add(Ingredients ingrediente);
        public List<Ingredients> GetAll();
        public Ingredients Get(int id);
        public Ingredients Update(Ingredients ingrediente);
        public bool DeleteId(int id);
        public bool Delete(int id);
        public List<Ingredients> GetAllIdRecipe(int IdRecipe);

    }
}
