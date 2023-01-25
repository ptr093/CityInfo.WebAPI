using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        public CityInfoRepository(CityInfoContext cityInfoContext)
        {
            CityInfoContext = cityInfoContext ?? throw new ArgumentNullException(nameof(cityInfoContext));
        }

        public CityInfoContext CityInfoContext { get; }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await CityInfoContext.Cities.OrderBy(c=>c.Name).ToListAsync();
        }

        public async Task<bool> CityExitsAsync(int CityId)
        {
            return await CityInfoContext.Cities.AnyAsync(c=>c.Id== CityId);
         }

        public async Task<City?> GetCityAsync(int cityId, bool includePointOfIntrest)
        {
            if (includePointOfIntrest)
            {
                return await CityInfoContext.Cities.Include(c=>c.PointOfIntrests).Where(c=>c.Id==cityId).FirstOrDefaultAsync();
            }

            return await CityInfoContext.Cities.Where(c=>c.Id== cityId).FirstOrDefaultAsync();
        }

        public  async Task<IEnumerable<PointOfIntrest>> GetPointsOfIntrestForCityAsync(int cityId)
        {
            return await CityInfoContext.PointsOfIntrest.Where(c => c.CityId == cityId).ToListAsync();
        }

        public async Task<PointOfIntrest?> GetPointOfIntrestForCityAsync(int cityId, int pointOfIntrestId)
        {
            return await CityInfoContext.PointsOfIntrest.Where(c => c.Id == cityId && c.Id==pointOfIntrestId).FirstOrDefaultAsync() ;
        }

        public async Task AddPointsOfIntrestForCityAsync(int cityId, PointOfIntrest pointOfIntrest)
        {
            var city = await GetCityAsync(cityId, false);
            if (city != null)
            {
                city.PointOfIntrests.Add(pointOfIntrest);
               
            }
        }
        public async Task AddNewCity(City city)
        {
            CityInfoContext.Cities.Add(city);

        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await CityInfoContext.SaveChangesAsync() >=0);
        }
    }
}
