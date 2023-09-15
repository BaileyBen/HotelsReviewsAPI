using System.Text.Json.Serialization;

namespace HotelReviewsAPI.Models.Domain
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }


        public Guid HotelId { get; set; }

        [JsonIgnore]
        public Hotel Hotel { get; set; }


        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
