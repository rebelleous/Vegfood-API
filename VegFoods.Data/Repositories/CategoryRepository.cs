using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
   public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(AppDbContext context):base(context)
        {
            
        }

        public async Task<Category> GetAllWithRecipesAsync(int CategoryID)
        {
            

            // return await _context.Categories.Include(a=> a.Recipes).SingleOrDefault(a=> a.Id == CategoryID);
            return await _appDbContext.Categories.Include(a => a.Recipes).SingleOrDefaultAsync(a => a.Id == CategoryID);
        }
    }
}
