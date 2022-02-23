using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
  public class IngredientRepository: Repository<Ingredient> , IingredientRepository
    {

        public IngredientRepository(AppDbContext dbContext) : base(dbContext)
        {

        }


    }
}
