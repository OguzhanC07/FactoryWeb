using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Concrete
{
    public class OrderDetailManager : GenericManager<OrderDetail> , IOrderDetailService
    {
        private readonly IGenericDal<OrderDetail> _genericDal;
        public OrderDetailManager(IGenericDal<OrderDetail> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
