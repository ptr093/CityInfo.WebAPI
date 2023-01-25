using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId,bool includePointOfIntrest);
        Task<IEnumerable<PointOfIntrest>> GetPointsOfIntrestForCityAsync(int cityId);
        Task<PointOfIntrest?> GetPointOfIntrestForCityAsync(int cityId, int pointOfIntrestId);

        Task<bool> CityExitsAsync(int CityId);

        Task AddPointsOfIntrestForCityAsync(int cityId, PointOfIntrest pointOfIntrest);

        Task<bool> SaveChangesAsync();

        Task AddNewCity(City city);
    }
}
