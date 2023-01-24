using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofintrest")]
    [ApiController]
    public class PointsOfIntrestsController : ControllerBase
    {
        private readonly CitiesDataStore citiesData;

        public ILogger<PointsOfIntrestsController> _logger { get; }

        [HttpGet]
        public ActionResult<IEnumerable<PointOfIntrestDto>> GetPointsOfIntrests(int id)
        {
            var city = citiesData.Cities.FirstOrDefault(c => c.Id == id);

            return city == null ? NotFound() : Ok(city.PointOfIntrests);
        }


        public PointsOfIntrestsController(ILogger<PointsOfIntrestsController> logger, CitiesDataStore citiesData)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.citiesData = citiesData ?? throw new ArgumentNullException(nameof(citiesData));
        }

        [HttpGet("pointofIntrest", Name = "GetPointOfIntrest")]
        public ActionResult<IEnumerable<PointOfIntrestDto>> GetPointOfIntrest(int cityId, int pointOfIntrestId)
        {
            var city = citiesData.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var pointOfIntrest = city.PointOfIntrests.FirstOrDefault(c => c.Id == pointOfIntrestId);

            if (pointOfIntrest == null) return NotFound();

            return Ok(pointOfIntrest);
        }


        [HttpPost]
        public ActionResult<IEnumerable<PointOfIntrestDto>> CreatePointOfIntrest(int cityId, PointOfIntrestCreationDto pointOfIntrestCreation)
        {
            var city = citiesData.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of intrest.");

                return NotFound();

            }

            var maxPointOfIntrest = city.PointOfIntrests.Max(s => s.Id);

            var finalPointOfIntrest = new PointOfIntrestDto()
            {
                Id = maxPointOfIntrest + 1,
                Name = pointOfIntrestCreation.Name,
                Description = pointOfIntrestCreation.Description
            };
            city.PointOfIntrests.Add(finalPointOfIntrest);
            return CreatedAtRoute("GetPointOfIntrest", new
            {
                cityId = cityId,
                pointOfIntrestId = finalPointOfIntrest.Id
            }, finalPointOfIntrest);
        }
    }
}