using FactoryWebAPI.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Entities.Concrete
{
    public class OrderDetail : ITable
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }

        public int NumberOfOrders { get; set; }
    }
}
