using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DTO.DTOs.DealerDtos
{
    public class DealerListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AppUserId { get; set; }

    }
}
