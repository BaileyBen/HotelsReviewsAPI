﻿using HotelReviewsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelReviewsAPI.Data
{
    public class HotelReviewsDbContext : DbContext
    {
        public HotelReviewsDbContext(DbContextOptions<HotelReviewsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
