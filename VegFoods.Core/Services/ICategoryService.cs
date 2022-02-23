using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.Models;

namespace VegFoods.Core.Services
{
    public interface ICategoryService :IService<Category>
    {
        Task<Category> GetAllWithRecipesAsync(int CategoryID);
    }
}
