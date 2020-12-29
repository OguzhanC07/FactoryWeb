using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Concrete
{
    public class ForgotPasswordManager : GenericManager<ForgotPassword>, IForgotPasswordService
    {
        private readonly IGenericDal<ForgotPassword> _genericDal;
        public ForgotPasswordManager(IGenericDal<ForgotPassword> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }

        public string GenerateRandomPass()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        public async Task MakeAllCodesFalseAsync(int appuserId)
        {
           var codes= await _genericDal.GetAllByFilter(I => I.isActive == true && I.AppUserId == appuserId);
            foreach (var item in codes)
            {
                item.isActive = false;
                await _genericDal.UpdateAsync(item);
            }
        }

        public async Task<bool> GetCodeAsync(int appuserId, string code)
        {
            var forgotPassword =await _genericDal.GetByFilter(I => I.AppUserId==appuserId && I.isActive == true);
            if (code==forgotPassword.Code)
            {
                forgotPassword.isActive = false;
                await _genericDal.UpdateAsync(forgotPassword);
                return true;
            }
            else
            {
                return false;
            }
        
        }
    }
}
