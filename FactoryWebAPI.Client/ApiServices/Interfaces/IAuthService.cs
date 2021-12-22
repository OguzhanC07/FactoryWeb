using System.Threading.Tasks;
using FactoryWebAPI.Client.Models;

namespace FactoryWebAPI.Client.ApiServices.Interfaces
{
    public interface IAuthService{
        Task<string> SignIn(AppUserLoginModel model);
        Task<string> SignUp(AppUserRegisterModel model);
        Task<bool> ForgotMyPass(ForgotPasswordModel model);
        Task<bool> ResetPassword(ResetPasswordModel model);
    }
}