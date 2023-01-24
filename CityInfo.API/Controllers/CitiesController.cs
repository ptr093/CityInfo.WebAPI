using CityInfo.API.Models;
using CityInfo.API.Models.CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesDataStore citiesData;

        public ILogger<CitiesController> _logger { get; }

        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(citiesData.Cities);
        }
        public CitiesController(ILogger<CitiesController> logger, CitiesDataStore citiesData)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.citiesData = citiesData ?? throw new ArgumentNullException(nameof(citiesData));
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {


            var CityToReturn = citiesData.Cities.FirstOrDefault(c => c.Id == id);


            if (CityToReturn == null)
            {
                _logger.LogWarning($"The given cityid: {id} does not exist ");
                return NotFound();
            }




            return Ok(CityToReturn);
        }


    }
}