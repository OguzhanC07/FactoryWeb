using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IGenericDal<Product> _genericDal;
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal, IGenericDal<Product> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _productDal = productDal;
        }

        public new async Task<List<Product>> GetAllAsync()
        {
            return await _productDal.GetAllByFilter(I => I.IsVisible == true);
        }
    }
}
