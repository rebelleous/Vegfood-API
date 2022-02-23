using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.UnitOfWork;

namespace VegFoods.Services.Services
{
    public class IngredientService : Service<Ingredient>, IingredientService
    {
        public IngredientService(IUnitOfWork unitOfWork, IRepository<Ingredient> repository) : base(unitOfWork, repository)
        {

        }
    }
}
