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
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IRepository<Role> repository) : base(unitOfWork, repository)
        {

        }


        public async Task<Role> FindByName(string roleName)
        {
            return await _unitOfWork.Roles.FindByName(roleName);
        }
    }
}
