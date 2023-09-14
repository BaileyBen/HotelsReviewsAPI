namespace HotelReviewsAPI.Models.Domain
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Value { get; set; }

        // Foreign key for Review
        public int ReviewId { get; set; }
        // Navigation property for review
        public Review Review { get; set; }
    }
}
