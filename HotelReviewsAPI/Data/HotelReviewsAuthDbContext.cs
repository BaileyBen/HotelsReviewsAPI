using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReviewsAPI.Data
{
    public class HotelReviewsAuthDbContext : IdentityDbContext
    {
        public HotelReviewsAuthDbContext(DbContextOptions<HotelReviewsAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "5e71c517-dfc3-4316-840f-f852dd087d4c";
            var writerRoleId = "9344c05e-5c9d-4f99-8063-c1671993c3de";

            var roles = new List<Microsoft.AspNetCore.Identity.IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
