using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class PointOfIntrestProfile:Profile
    {
        public PointOfIntrestProfile()
        {
            CreateMap<Entities.PointOfIntrest, Models.PointOfIntrestDto>();
            CreateMap<Models.PointOfIntrestCreationDto, Entities.PointOfIntrest>();
        }
       
    }
}
