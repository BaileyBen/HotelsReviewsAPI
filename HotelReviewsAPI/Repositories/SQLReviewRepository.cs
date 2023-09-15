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

        public async Task<Review> DeleteAsync(Guid id)
        {
            var existingReview = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.UserId == id);

            if (existingReview == null)
            {
                return null;
            }
            _dbContext.Reviews.Remove(existingReview);
            await _dbContext.SaveChangesAsync();

            return existingReview;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _dbContext.Reviews.Include("User").Include("Hotel").AsQueryable().ToListAsync();
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await _dbContext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
        }

        public async Task<Review> UpdateAsync(Guid id, Review review)
        {
            var existingReview = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);

            if (existingReview == null) {
                return null;
            }

            existingReview.Rating = review.Rating;
            existingReview.Comment = review.Comment;
            existingReview.ReviewDate = review.ReviewDate;
            
            await _dbContext.SaveChangesAsync();

            return existingReview;
        }
    }
}
