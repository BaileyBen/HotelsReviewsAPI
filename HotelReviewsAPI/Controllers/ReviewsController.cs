using AutoMapper;
using HotelReviewsAPI.Data;
using HotelReviewsAPI.Models.Domain;
using HotelReviewsAPI.Models.DTO;
using HotelReviewsAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Authorization;

namespace HotelReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly HotelReviewsDbContext dbContext;
        private readonly IReviewsRepository reviewsRepository;
        private readonly IMapper mapper;

        public ReviewsController(HotelReviewsDbContext dbContext, IReviewsRepository reviewsRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.reviewsRepository = reviewsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviewDomainModel = await reviewsRepository.GetAllAsync();

            return Ok(mapper.Map<List<ReviewDto>>(reviewDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var reviewDomainModel = await reviewsRepository.GetByIdAsync(id);

            return Ok(mapper.Map<Review>(reviewDomainModel));
        }

        [HttpPost("/api/hotels/{hotelIdOrName}/reviews")]
        public async Task<IActionResult> CreateReviewForHotel(string hotelIdOrName, [FromBody] AddReviewRequestDto addReviewRequestDto, [FromQuery] string userName)
        {
            if (!Guid.TryParse(hotelIdOrName, out var hotelId))
            {
                var hotel = dbContext.Hotels.FirstOrDefault(x => x.Name == hotelIdOrName);
                if (hotel == null)
                {
                    return NotFound($"Hotel with name '{hotelIdOrName}' not found.");
                }
                hotelId = hotel.HotelId;
            }

            var user = dbContext.Users.FirstOrDefault(x => x.Username == userName);
            if (user == null)
            {
                return NotFound($"User with name '{userName}' not found.");
            }

            var validationErrors = ValidateReview(addReviewRequestDto);
            if (validationErrors.Any())
            {
                return BadRequest(validationErrors);
            }

            var reviewDomainModel = CreateReview(addReviewRequestDto, hotelId, user.UserId);
            reviewDomainModel = await reviewsRepository.CreateAsync(reviewDomainModel);

            var reviewDtoModel = mapper.Map<AddReviewRequestDto>(reviewDomainModel);
            return Ok(reviewDtoModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateReviewRequestDto updateReviewRequestDto)
        {
            var reviewDomainModel = mapper.Map<Review>(updateReviewRequestDto);

            reviewDomainModel = await reviewsRepository.UpdateAsync(id, reviewDomainModel);

            if (reviewDomainModel == null) {
                return NotFound();
            }
            return Ok(mapper.Map<ReviewDto>(reviewDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedDomainModel = await reviewsRepository.DeleteAsync(id);

            if (deletedDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ReviewDto>(deletedDomainModel));
        }

        private List<string> ValidateReview(AddReviewRequestDto reviewDto)
        {
            var errors = new List<string>();

            if (reviewDto.Rating < 1 || reviewDto.Rating > 5) {
                errors.Add("Rating must be between 1 and 5");
            }
            return errors;
        }

        private Review CreateReview(AddReviewRequestDto reviewDto, Guid hotelId, Guid userId)
        {
            return new Review
            {
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                ReviewDate = DateTime.UtcNow,
                HotelId = hotelId,
                UserId = userId
            };
        }
        }
}
