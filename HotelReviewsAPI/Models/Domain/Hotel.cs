using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace HotelReviewsAPI.Models.Domain
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }

        // Navigation property for reviews
        public List<Review> Reviews { get; set; }
    }
}
