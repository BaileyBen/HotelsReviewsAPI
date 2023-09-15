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

        public async Task<Hotel> CreateAsync(Hotel hotel)
        {
            await _dbContext.AddAsync(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> DeleteAsync(Guid id)
        {
            var existingHotel = await _dbContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);

            if (existingHotel == null)
            {
                return null;
            }
            _dbContext.Remove(existingHotel);
            await _dbContext.SaveChangesAsync();

            return existingHotel;
        }

        public async Task<List<Hotel>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            var hotels = _dbContext.Hotels.Include("Reviews").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    hotels = hotels.Where(x => x.Name.Contains(filterQuery));
                }
              
            }
            //return await _dbContext.Hotels.Include("Reviews").AsQueryable().ToListAsync();
            return await hotels.ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(Guid id)
        {
            return await _dbContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);
        }

        public async Task<Hotel> UpdateAsync(Guid id, Hotel hotel)
        {
            var existingHotel = await _dbContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);

            if (existingHotel == null)
            {
                return null;
            }

            existingHotel.Name = hotel.Name;
            existingHotel.Location = hotel.Location;
            existingHotel.Contact = hotel.Contact;

            await _dbContext.SaveChangesAsync();
            return existingHotel;

        }
    }
}
