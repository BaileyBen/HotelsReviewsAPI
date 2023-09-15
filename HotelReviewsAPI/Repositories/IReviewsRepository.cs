using HotelReviewsAPI.Models.Domain;

namespace HotelReviewsAPI.Repositories
{
    public interface IReviewsRepository
    {
        Task<List<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(Guid id);
        Task<Review> CreateAsync(Review review);
        Task<Review> UpdateAsync(Guid id, Review review);
        Task<Review> DeleteAsync(Guid id); 
    }
}
