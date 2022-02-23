using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.UnitOfWork;

namespace VegFoods.Services.Services
{
    public class RecipeService : Service<Recipe>, IRecipeService
    {
        public RecipeService(IUnitOfWork unitOfWork, IRepository<Recipe> repository) : base(unitOfWork, repository)
        {

        }
        public Task<IEnumerable<Recipe>> GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> GetWithIngreById(int Recipeid)
        {
            return await _unitOfWork.Recipes.GetWithIngreById(Recipeid);
        }

        

        public async Task<IEnumerable<Recipe>> GetAllWithIngredientsAsync()
        {
            return await _unitOfWork.Recipes.GetAllWithIngredientsAsync();
        }

        public async Task<IEnumerable<Recipe>> GetAllWithIngredient()
        {
            return await _unitOfWork.Recipes.GetAllWithIngredient();
        }
    }
}
