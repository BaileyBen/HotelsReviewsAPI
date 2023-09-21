using Microsoft.AspNetCore.Identity;

namespace HotelReviewsAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
