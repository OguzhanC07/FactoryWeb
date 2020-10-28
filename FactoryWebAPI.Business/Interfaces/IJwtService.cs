using FactoryWebAPI.Business.Settings;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser, List<AppRole> roles);
    }
}
