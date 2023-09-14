namespace HotelReviewsAPI.Models.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        // Foreign key for Review
        public int ReviewId { get; set; }
        // Navigation property for review
        public Review Review { get; set; }
    }
}
