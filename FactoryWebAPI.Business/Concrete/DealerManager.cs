using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Concrete
{
    public class DealerManager : GenericManager<Dealer>,IDealerService
    {
        private readonly IGenericDal<Dealer> _genericDal;
        public DealerManager(IGenericDal<Dealer> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
