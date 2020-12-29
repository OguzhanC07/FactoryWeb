using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Interfaces
{
    public interface IForgotPasswordService : IGenericService<ForgotPassword>
    {
        public string GenerateRandomPass();
        public Task MakeAllCodesFalseAsync(int appuserId);
        public Task<bool> GetCodeAsync(int appuserId,string code);
    }
}
