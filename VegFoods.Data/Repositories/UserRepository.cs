using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Role>> GetRolesByUserName(string userName)
        {
           
            return await _appDbContext.Users.Join(_appDbContext.UserRoles, u => u.Id, ur => ur.UserId, (user, userRole) => new
            {
                user = user,
                userRole = userRole
            }).Join(_appDbContext.Roles, two => two.userRole.RoleId, r => r.Id, (twoTable, role) => new
            {
                user = twoTable.user,
                userRole = twoTable.userRole,
                role = role
            }).Where(I => I.user.UserName == userName).Select(I => new Role
            {
                Id = I.role.Id,
                Name = I.role.Name
            }).ToListAsync();
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(a => a.UserName == userName);
        }

        public async Task<bool> CheckPassword(User user)
        {
            var AppUser = await _appDbContext.Users.SingleOrDefaultAsync(x => x.UserName == user.UserName);
            return AppUser.Password == user.Password ? true : false;
        }
    }
}
