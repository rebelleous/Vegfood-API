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
    public class CategoryService : Service<Category>, ICategoryService
    {
        
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }

        public async Task<Category> GetAllWithRecipesAsync(int CategoryID)
        {
            return await _unitOfWork.Categories.GetAllWithRecipesAsync(CategoryID);        
        }
    }
}
