using HotelReviewsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelReviewsAPI.Data
{
    public class HotelReviewsDbContext : DbContext
    {
        public HotelReviewsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var users = new List<User>()
            {
                new User()
                {
                    UserId = Guid.Parse("3de7d22e-1a86-4c3d-898e-b1c63f0ed000"),
                    Username = "Ben",
                    Email = "Okay@hotmail.com"
                }         
            };
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
