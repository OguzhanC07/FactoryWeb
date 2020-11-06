using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DTO.DTOs.OrderDetailDtos
{
    public class OrderDetailListDto
    {
        public int Id { get; set; }
        public int NumberOfOrders { get; set; }
        public DateTime BuyTime { get; set; } = DateTime.Now;

        public string ProductName { get; set; }
        public string DealerName { get; set; }
    }
}
