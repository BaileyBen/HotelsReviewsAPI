using AutoMapper;
using HotelReviewsAPI.Models.Domain;
using HotelReviewsAPI.Models.DTO;

namespace HotelReviewsAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<AddHotelRequestDto, Hotel>().ReverseMap();
            CreateMap<UpdateHotelRequestDto,Hotel>().ReverseMap();
        }
    }
}
