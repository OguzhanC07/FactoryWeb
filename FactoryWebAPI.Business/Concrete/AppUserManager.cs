using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.DTO.DTOs;
using FactoryWebAPI.DTO.DTOs.AppUserDtos;
using FactoryWebAPI.Entities.Concrete;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal,IGenericDal<AppUser> genericDal): base(genericDal)
        {
            _appUserDal=appUserDal;
            _genericDal = genericDal;
        }


        public async Task<AppUser> FindByEmailorUserName(string value)
        {
            return await _appUserDal.GetByFilter(I=>I.Email==value || I.UserName==value);
        }
        public async Task<bool> CheckHashPassword(AppUserLoginDto appUser)
        {
            var user =await _appUserDal.GetByFilter(I => I.Email == appUser.Email || I.UserName==appUser.Email && I.Password == appUser.Password);
            return user.Password == appUser.Password;
        }

        public string CreateHashPassword(string password)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();

            mD5.ComputeHash(Encoding.ASCII.GetBytes(password));
            byte[] result = mD5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public async Task<List<AppRole>> GetRolesByEmail(string email)
        {
            return await _appUserDal.GetRolesByEmail(email);
        }
    }
}
