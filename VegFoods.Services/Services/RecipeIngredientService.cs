using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.UnitOfWork;

namespace VegFoods.Services.Services
{
   public class RecipeIngredientService : Service<RecipeIngredient> , IRecipeIngredientService
    {
        public RecipeIngredientService(IUnitOfWork unitOfWork, IRepository<RecipeIngredient> repository) : base(unitOfWork, repository)
        {

        }
    }
}
