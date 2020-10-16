using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryWebAPI.WebApi.Models
{
    public class ProductAddModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }
    }
}
