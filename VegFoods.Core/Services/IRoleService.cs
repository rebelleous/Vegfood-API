using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.Models;

namespace VegFoods.Core.Services
{
    public interface IRoleService : IService<Role>
    {
        Task<Role> FindByName(string roleName);
    }
}
