using HotelReviewsAPI.Models.Domain;

namespace HotelReviewsAPI.Models.DTO
{
    public class ReviewDto
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }


        public Hotel Hotel { get; set; }

        // Foreign key for User
        public User User { get; set; }
    }
}
