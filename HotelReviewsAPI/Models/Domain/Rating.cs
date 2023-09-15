namespace HotelReviewsAPI.Models.Domain
{
    public class Rating
    {
        public Guid RatingId { get; set; }
        public int Value { get; set; }

        public Guid ReviewId { get; set; }


        public Review Review { get; set; }
    }
}
