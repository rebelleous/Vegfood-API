using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.Models;

namespace VegFoods.Core.IRepositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
       
        Task<Category> GetAllWithRecipesAsync(int CategoryID);
       
    }
}
