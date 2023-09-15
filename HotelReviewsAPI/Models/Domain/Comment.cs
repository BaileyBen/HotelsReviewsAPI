namespace HotelReviewsAPI.Models.Domain
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }

        public Guid ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
