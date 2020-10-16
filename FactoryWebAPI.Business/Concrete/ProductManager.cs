using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IGenericDal<Product> _genericDal;
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
