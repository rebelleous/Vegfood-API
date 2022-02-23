using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
    public class RecipeIngredientRepository : Repository<RecipeIngredient>, IRecipeIngredientRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public RecipeIngredientRepository(AppDbContext context) : base(context)
        {

        }
    }
}
