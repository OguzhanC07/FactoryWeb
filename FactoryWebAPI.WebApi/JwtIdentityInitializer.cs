using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.Business.StringInfo.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

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

            var adminUser = await appUserService.FindByEmailorUserName("oguzhancan2009@gmail.com");
            var adminUser1 = await appUserService.FindByEmailorUserName("onurgoz98@gmail.com");
            if (adminUser == null && adminUser1 == null)
            {
                string password =appUserService.CreateHashPassword("1");

                await appUserService.AddAsync(new Entities.Concrete.AppUser
                {
                    FullName = "Oğuzhan",
                    UserName = "admin",
                    Password = password,
                    Email = "oguzhancan2009@gmail.com",
                    ImagePath = "default.jpg"
                });
                await appUserService.AddAsync(new Entities.Concrete.AppUser
                {
                    FullName = "Onur",
                    UserName = "admincik",
                    Password = password,
                    Email = "onurgoz98@gmail.com",
                    ImagePath = "default.jpg"
                });

                var role = await appRoleService.FindByNameAsync(RoleInfo.Admin);
                var admin = await appUserService.FindByEmailorUserName("admin");
                var admin1 = await appUserService.FindByEmailorUserName("admincik");

                await appUserRoleService.AddAsync(new Entities.Concrete.AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });

                await appUserRoleService.AddAsync(new Entities.Concrete.AppUserRole
                {
                    AppUserId = admin1.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
