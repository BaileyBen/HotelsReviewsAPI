using HotelReviewsAPI.Models.Domain;

namespace HotelReviewsAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image>Upload(Image image);
    }
}
