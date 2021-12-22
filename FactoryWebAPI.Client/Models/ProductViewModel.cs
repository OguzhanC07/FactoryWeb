using Microsoft.AspNetCore.Http;

namespace FactoryWebAPI.Client.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public bool IsVisible { get; set; }
    }

}