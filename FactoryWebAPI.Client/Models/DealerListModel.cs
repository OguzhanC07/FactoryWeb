using System.ComponentModel.DataAnnotations;

namespace FactoryWebAPI.Client.Models
{
    public class DealerListModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="İsim alanı boş geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage="Adres alanı boş geçilemez")]
        public string Address { get; set; }
        [Required(ErrorMessage = "E-mail alanı boş geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş geçilemez")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public string City { get; set; }
        public string District { get; set; }
        public int AppUserId { get; set; }
    }
}