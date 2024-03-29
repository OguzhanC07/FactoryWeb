using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FactoryWebAPI.Client.Models
{
    public class ProductUpdateModel{
        public int Id { get; set; }
        
        [Required(ErrorMessage="İsim alanı boş geçilemez")]
        public string Name { get; set; }
        
        [Required(ErrorMessage="Açıklama alanı boş geçilemez")]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}