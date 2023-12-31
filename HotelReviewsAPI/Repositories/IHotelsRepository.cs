﻿using HotelReviewsAPI.Models.Domain;

namespace HotelReviewsAPI.Repositories
{
    public interface IHotelsRepository
    {
        Task<List<Hotel>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool? isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<Hotel> GetByIdAsync(Guid id);
        Task<Hotel> CreateAsync(Hotel hotel);
        Task<Hotel> UpdateAsync(Guid id, Hotel hotel);
        Task<Hotel> DeleteAsync(Guid id);
    }
}
