using HotelReviewsAPI.Data;
using HotelReviewsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelReviewsAPI.Repositories
{
    public class SQLReviewRepository : IReviewsRepository
    {
        private readonly HotelReviewsDbContext _dbContext;

        public SQLReviewRepository(HotelReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            await _dbContext.AddAsync(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _dbContext.Reviews.Include("User").Include("Hotel").AsQueryable().ToListAsync();
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await _dbContext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
        }
    }
}
