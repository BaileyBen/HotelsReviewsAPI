namespace HotelReviewsAPI.Models.DTO
{
    public class AddHotelRequestDto
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
    }
}
