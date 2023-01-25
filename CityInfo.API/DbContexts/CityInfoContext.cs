using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Models.CityInfo.API.Models;
using Microsoft.EntityFrameworkCore;


namespace CityInfo.API.DbContexts
{
    public class CityInfoContext:DbContext
    {
        public CityInfoContext(DbContextOptions <CityInfoContext> options) : base(options)
        {

        }

  

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfIntrest> PointsOfIntrest { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder    modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("Warszawa")
                {
                    Id = 1,
                    Description = "Stolica"
                },
                new City("Gdanśk")
                {
                    Id = 2,
                    Description = "Piękne miasto położone nad morzem"
                },
                new City("Kraków")
                {
                    Id = 3,
                    Description = "Miasto Królów Polskich"
                }
                );
            modelBuilder.Entity<PointOfIntrest>().HasData(
                new PointOfIntrest("Ratusz Głównego Miasta") {
                    Id = 1,
                   CityId=2,
                    Description = "Najokazalsza i najcenniejsza budowla świecka dawnego Gdańska, siedziba władz miasta. Budowany był od 1379 do 1492 roku."
                },
                 new PointOfIntrest("Dwór Artusa")
                 {
                     Id = 2,
                     CityId=2,
                     Description = "Przez wiele lat był jednym z najwspanialszych tego typu obiektów w Europie północnej."
                 },
                 new PointOfIntrest("Bazylika Mariacka")
                 {
                       Id = 3,
                     CityId=3,
                       Description = "Słynna bazylika z dwiema wieżami"
                 },
                 new PointOfIntrest("Zamek królewski na wawelu")
                  {
                            Id = 4,
                            CityId = 3,
                            Description = "średniowieczny zamek królewski"
                  },
                  new PointOfIntrest("Łazienki Królewskie")
                  {
                      Id = 5,
                      CityId = 2,
                      Description = "to jeden z najpiękniejszych kompleksów ogrodowych nie tylko w Polsce, ale i w Europie "
                  },
                  new PointOfIntrest("Pałac Kultury i Nauki")
                   {
                            Id = 6,
                            CityId = 2,
                            Description = "To tak naprawdę wizytówka stolicy i najwyższy budynek w Polsce (ma 237 m wysokości) "
                   }
                );

               

            }

          
     }           
}

