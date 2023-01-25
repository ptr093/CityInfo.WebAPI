using CityInfo.API.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto
                {
                    Id=1,
                    Name="Kraków",
                    Description="Miasto Królów Polskich",
                    PointOfIntrests =new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id=1,
                            Name ="Bazylika Mariacka",
                            Description ="Słynna bazylika z dwiema wieżami"
                        },
                        new PointOfIntrestDto()
                        {
                            Id=2,
                            Name="Zamek królewski na wawelu",
                            Description="średniowieczny zamek królewski"
                        }
                    }
                },
                new CityDto()
                {
                    Id=2,
                    Name="Gdanśk",
                    Description ="Piękne miasto położone nad morzem",
                      PointOfIntrests =new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id=1,
                            Name ="Ratusz Głównego Miasta",
                            Description ="Najokazalsza i najcenniejsza budowla świecka dawnego Gdańska, siedziba władz miasta. Budowany był od 1379 do 1492 roku."
                        },
                        new PointOfIntrestDto()
                        {
                            Id=2,
                            Name="Dwór Artusa",
                            Description="Przez wiele lat był jednym z najwspanialszych tego typu obiektów w Europie północnej."
                        }
                    }
                },
                new CityDto()
                {
                    Id=3,
                    Name ="Warszawa",
                    Description="Stolica",
                      PointOfIntrests =new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id=1,
                            Name ="Łazienki Królewskie",
                            Description ="to jeden z najpiękniejszych kompleksów ogrodowych nie tylko w Polsce, ale i w Europie "
                        },
                        new PointOfIntrestDto()
                        {
                            Id=2,
                            Name="Pałac Kultury i Nauki",
                            Description="To tak naprawdę wizytówka stolicy i najwyższy budynek w Polsce (ma 237 m wysokości) "
                        }
                    }
                }


            };

        }
    }
}