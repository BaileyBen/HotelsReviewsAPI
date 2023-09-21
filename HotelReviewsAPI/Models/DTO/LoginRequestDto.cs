using System.ComponentModel.DataAnnotations;

namespace HotelReviewsAPI.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }
    }
}
