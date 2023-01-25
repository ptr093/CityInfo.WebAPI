using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class CityProfile :Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
            CreateMap<Entities.City, Models.CityDto>();
            CreateMap<Models.CityCreationDto,Entities.City >();
        }
    }
}
