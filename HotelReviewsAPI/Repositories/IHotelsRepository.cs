using HotelReviewsAPI.Models.Domain;

namespace HotelReviewsAPI.Repositories
{
    public interface IHotelsRepository
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(Guid id);
    }
}
