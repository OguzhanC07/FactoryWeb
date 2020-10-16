using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Concrete
{
    public class ProductManager : GenericManager<Product>
    {
        IGenericDal<Product> _genericDal;
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
