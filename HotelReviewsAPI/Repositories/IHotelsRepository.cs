using HotelReviewsAPI.Models.Domain;

namespace HotelReviewsAPI.Repositories
{
    public interface IHotelsRepository
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(Guid id);
        Task<Hotel> CreateAsync(Hotel hotel);
        Task<Hotel> UpdateAsync(Guid id, Hotel hotel);
        Task<Hotel> DeleteAsync(Guid id);
    }
}
