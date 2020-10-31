using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Interfaces
{
    public interface IDealerService : IGenericService<Dealer>
    {
        Task<List<Dealer>> GetDealersByAppUserId(int appUserId);
    }
}
