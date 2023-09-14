using HotelReviewsAPI.Data;
using HotelReviewsAPI.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HotelReviewsAPI.Repositories
{
    public class SQLHotelRepository : IHotelsRepository
    {
        private readonly HotelReviewsDbContext _dbContext;

        public SQLHotelRepository(HotelReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            return await _dbContext.Hotels.Include("Reviews").AsQueryable().ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(Guid id)
        {
            return await _dbContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);
        }
    }
}
