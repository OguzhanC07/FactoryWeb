using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Interfaces
{
    public interface IMailService 
    {
        //Task SendEmailAsync(string toemail, string subject, string body);
        Task SendWelcomeMailAsync(string username,string toemail);
    }
}
