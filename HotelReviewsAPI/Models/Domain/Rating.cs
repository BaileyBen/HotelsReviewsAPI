namespace HotelReviewsAPI.Models.Domain
{
    public class Rating
    {
        public Guid RatingId { get; set; }
        public int Value { get; set; }

        // Foreign key for Review
        public Guid ReviewId { get; set; }
        // Navigation property for review
        public Review Review { get; set; }
    }
}
