namespace HotelReviewsAPI.Models.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
