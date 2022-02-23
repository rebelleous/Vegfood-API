using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.Models;

namespace VegFoods.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByUserName(string userName);
        Task<bool> CheckPassword(User user);
        Task<List<Role>> GetRolesByUserName(string userName);

    }
}
