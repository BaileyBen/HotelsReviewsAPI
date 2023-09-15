using HotelReviewsAPI.Models.Domain;
using System.Text.Json.Serialization;

namespace HotelReviewsAPI.Models.DTO
{
    public class ReviewDto
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public Hotel Hotel { get; set; }

        public User User { get; set; }
    }
}
