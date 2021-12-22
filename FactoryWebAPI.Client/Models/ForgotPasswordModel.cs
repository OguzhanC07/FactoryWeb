using System.ComponentModel.DataAnnotations;

namespace FactoryWebAPI.Client.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Email alanı boş olamaz")]
        public string Email { get; set; }
    }
}