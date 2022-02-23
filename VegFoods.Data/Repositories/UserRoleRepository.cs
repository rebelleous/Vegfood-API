using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
   public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserRoleRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
