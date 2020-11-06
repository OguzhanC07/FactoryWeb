using FactoryWebAPI.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryWebAPI.DataAccess.Interfaces
{
    public interface IDealerDal : IGenericDal<Dealer>
    {
        Task<List<OrderDetail>> GetAllOrders();
    }
}
