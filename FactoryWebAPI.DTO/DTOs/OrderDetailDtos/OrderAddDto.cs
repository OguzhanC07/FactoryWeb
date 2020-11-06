using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DTO.DTOs.OrderDetailDtos
{
    public class OrderAddDto
    {
        public int NumberOfOrders { get; set; }
        public DateTime BuyTime { get; set; }
        public int ProductId { get; set; }
        public int DealerId { get; set; }
    }
}
