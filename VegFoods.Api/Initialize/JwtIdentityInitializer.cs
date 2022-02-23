using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.StringInfos;

namespace VegFoods.Api.Initialize
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            //ilgili rol varmı?
            var adminRole = await roleService.FindByName(RoleInfo.Admin);
            if (adminRole == null)
            {
                await roleService.AddAsync(new Role
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await roleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await roleService.AddAsync(new Role
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await userService.FindByUserName("admin");
            if (adminUser == null)
            {
                await userService.AddAsync(new User
                {
                    FullName = "Mert Aktas",
                    UserName = "admin",
                    Password = "admin"
                });

                var role = await roleService.FindByName(RoleInfo.Admin);
                var admin = await userService.FindByUserName("admin");

                await userRoleService.AddAsync(new UserRole
                {
                    UserId = admin.Id,
                    RoleId = role.Id
                });
            }
        }
    }
}
