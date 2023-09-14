namespace HotelReviewsAPI.Models.Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        // Foreign key for Hotel
        public int HotelId { get; set; }
        // Navigation property for hotel
        public Hotel Hotel { get; set; }

        // Foreign key for User (assuming a User model)
        public int UserId { get; set; }
        // Navigation property for user
        public User User { get; set; }
    }
}
