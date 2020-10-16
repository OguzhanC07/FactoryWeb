using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRoleRepository : EfGenericRepository<AppUserRole>, IAppUserRoleDal
    {
    }
}
