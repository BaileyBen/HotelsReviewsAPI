using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text.Json.Serialization;

namespace HotelReviewsAPI.Models.Domain
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }

        // Navigation property for reviews
        [JsonIgnore]
        public List<Review> Reviews { get; set; }
    }
}

