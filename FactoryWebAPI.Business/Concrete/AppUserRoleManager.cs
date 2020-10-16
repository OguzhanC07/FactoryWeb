using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Concrete
{
    public class AppUserRoleManager  : GenericManager<AppUserRole> , IAppUserRoleService
    {
        private readonly IGenericDal<AppUserRole> _genericDal;
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
