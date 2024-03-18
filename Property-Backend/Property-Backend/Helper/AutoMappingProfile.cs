using AutoMapper;
using Property_Backend.Model;
using Property_Backend.Model.Dto.CityDto;

namespace Property_Backend.Helper
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<City,cityResponseDto>();
        }

    }
}
