using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Concrete
{
    public class DealerManager : GenericManager<Dealer>
    {
        IGenericDal<Dealer> _genericDal;
        public DealerManager(IGenericDal<Dealer> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
