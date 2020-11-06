using FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Context;
using FactoryWebAPI.DataAccess.Interfaces;
using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDealerRepository : EfGenericRepository<Dealer> , IDealerDal
    {
        public async Task<List<OrderDetail>> GetAllOrders()
        {
            using var context = new FactoryDbContext();
            return await context.Dealers.Join(context.OrderDetails, d => d.Id, od => od.DealerId, (dealer, order) => new
            {
                dealer = dealer,
                order = order
            }).Join(context.Products, two => two.order.ProductId, p => p.Id, (twotable, prodct) => new
            {
                dealer = twotable.dealer,
                order = twotable.order,
                product = prodct
            }).Select(I => new OrderDetail
            {
                Dealer=I.dealer,
                Product=I.product,
                BuyTime = I.order.BuyTime,
                NumberOfOrders = I.order.NumberOfOrders,
            }).ToListAsync();
        }
    }

    public class OrderInformations
    {
        public string ProductName { get; set; }
        public string DealerName { get; set; }
        public int NumberOfOrders { get; set; }
        public DateTime BuyTime { get; set; }
    }
}
