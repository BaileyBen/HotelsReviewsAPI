namespace HotelReviewsAPI.Models.DTO
{
    public class UpdateReviewRequestDto
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
    }
}
