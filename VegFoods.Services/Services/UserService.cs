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
    public class UserService : Service<User>, IUserService
    {

        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {

        }

        //   return await _unitOfWork.Categories.GetAllWithRecipesAsync(CategoryID);        

        public async Task<bool> CheckPassword(User user)
        {
            return await _unitOfWork.Users.CheckPassword(user);
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await _unitOfWork.Users.FindByUserName(userName);
        }

        public async Task<List<Role>> GetRolesByUserName(string userName)
        {
            return await _unitOfWork.Users.GetRolesByUserName(userName);
        }
    }
}
