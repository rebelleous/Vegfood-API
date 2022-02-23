using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.Models;


namespace VegFoods.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> FindByUserName(string userName);
        Task<bool> CheckPassword(User user);
        Task<List<Role>> GetRolesByUserName(string userName);
    }
}
