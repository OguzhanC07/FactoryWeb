using FactoryWebAPI.DTO.DTOs.AppUserDtos;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByEmailandUserName(string email,string username);
        string CreateHashPassword(string password);
        Task<bool> CheckHashPassword(AppUserLoginDto appUser);
       
        //it can be changeable
        Task<AppRole> GetRolesByUserName(string username);
    }
}
