using AutoMapper;
using HotelReviewsAPI.Data;
using HotelReviewsAPI.Models.Domain;
using HotelReviewsAPI.Models.DTO;
using HotelReviewsAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelReviewsDbContext dbContext;
        private readonly IHotelsRepository hotelRepository;
        private readonly IMapper mapper;

        public HotelsController(HotelReviewsDbContext _dbContext, IHotelsRepository hotelRepository, IMapper mapper)
        {
            dbContext = _dbContext;
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotelDomainModel = await hotelRepository.GetAllAsync();

            return Ok(mapper.Map<List<HotelDto>>(hotelDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var hotelDomainModel = await hotelRepository.GetByIdAsync(id);

            if (hotelDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HotelDto>(hotelDomainModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddHotelRequestDto addHotelRequestDto)
        {
            if (ModelState.IsValid)
            {
                var hotelDomainModel = mapper.Map<Hotel>(addHotelRequestDto);

                hotelDomainModel = await hotelRepository.CreateAsync(hotelDomainModel);

                var hotelDtoModel = mapper.Map<HotelDto>(hotelDomainModel);

                return Ok(hotelDtoModel);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateHotelRequestDto updateHotelRequestDto)
        {
            var hotelDomainModel = mapper.Map<Hotel>(updateHotelRequestDto);

            hotelDomainModel = await hotelRepository.UpdateAsync(id, hotelDomainModel);

            if (hotelDomainModel == null)
            {
                return null;
            }

            return Ok(mapper.Map<HotelDto>(hotelDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedHotelDomainModel = await hotelRepository.DeleteAsync(id);

            if (deletedHotelDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HotelDto>(deletedHotelDomainModel));
        }
    }
}
