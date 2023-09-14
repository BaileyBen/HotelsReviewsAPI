﻿namespace HotelReviewsAPI.Models.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // Navigation property for reviews
        public List<Review> Reviews { get; set; }
    }
}
