using System.ComponentModel.DataAnnotations;

namespace FactoryWebAPI.Client.Models
{
    public class AppUserLoginModel
    {
        [Required(ErrorMessage="Email alanı boş geçilemez")]
        public string Email { get; set; }
        
        [Required(ErrorMessage="Şifre alanı boş geçilemez")]
        public string Password { get; set; }
    }
}