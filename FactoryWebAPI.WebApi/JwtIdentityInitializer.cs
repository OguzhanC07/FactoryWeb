﻿using FactoryWebAPI.Business.Interfaces;
using System.Threading.Tasks;
using FactoryWebAPI.Business.StringInfo;

namespace FactoryWebAPI.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByNameAsync(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.AddAsync(new Entities.Concrete.AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByNameAsync(RoleInfo.Member);
            if (memberRole==null)
            {
                await appRoleService.AddAsync(new Entities.Concrete.AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByEmailorUserName("admin@gmail.com");
            if (adminUser == null)
            {
                string password =appUserService.CreateHashPassword("1");

                await appUserService.AddAsync(new Entities.Concrete.AppUser
                {
                    FullName = "admin",
                    UserName = "admin",
                    Password = password,
                    Email = "admin@gmail.com",
                    ImagePath = "default.jpg"
                });

                var role = await appRoleService.FindByNameAsync(RoleInfo.Admin);
                var admin = await appUserService.FindByEmailorUserName("admin");

                await appUserRoleService.AddAsync(new Entities.Concrete.AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
