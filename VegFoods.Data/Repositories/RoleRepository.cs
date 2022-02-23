using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        // return await _appDbContext.Categories.Include(a => a.Recipes).SingleOrDefaultAsync(a => a.Id == CategoryID);

        public async Task<Role> FindByName(string roleName)
        {
            return await _appDbContext.Roles.SingleOrDefaultAsync(a => a.Name == roleName);
        }
    }
}
