using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Concrete
{
    public class DealerManager : GenericManager<Dealer>,IDealerService
    {
        private readonly IGenericDal<Dealer> _genericDal;
        private readonly IDealerDal _dealerDal;
        public DealerManager(IDealerDal dealerDal,IGenericDal<Dealer> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _dealerDal = dealerDal;
        }

        public new async Task<List<Dealer>> GetAllAsync()
        {
            return await _dealerDal.GetAllByFilter(I => I.IsVisible == true);
        }

        public async Task<List<OrderDetail>> GetAllOrders()
        {
            return await _dealerDal.GetAllOrders();
        }

        public async Task<List<Dealer>> GetDealersByAppUserId(int appUserId)
        {
            return await _dealerDal.GetAllByFilter(I => I.AppUserId == appUserId && I.IsVisible==true);
        }
       
    }
}
