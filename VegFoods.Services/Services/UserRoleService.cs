using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.UnitOfWork;

namespace VegFoods.Services.Services
{
    public class UserRoleService : Service<UserRole> , IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork, IRepository<UserRole> repository) : base(unitOfWork, repository)
        {

        }
    }
}
