using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfForgotPasswordRepository : EfGenericRepository<ForgotPassword>, IForgotPasswordDal
    {
      
    }
}
