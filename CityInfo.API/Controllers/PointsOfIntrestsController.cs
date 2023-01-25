using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
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
        private readonly ICityInfoRepository cityInfoRepository;

        public ILogger<PointsOfIntrestsController> _logger { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<PointOfIntrestDto>>> GetPointsOfIntrests(int cityId)
        {

            if(!await cityInfoRepository.CityExitsAsync(cityId))
            {
                _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of intrest.");
                return NotFound();
            }
            var city = await cityInfoRepository.GetPointsOfIntrestForCityAsync(cityId);

            return Ok(Mapper.Map<IEnumerable<PointOfIntrestDto>>(city));
        }


        public PointsOfIntrestsController(ILogger<PointsOfIntrestsController> logger, ICityInfoRepository cityInfoRepository,IMapper  mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("pointofIntrest", Name = "GetPointOfIntrest")]
        public async  Task<ActionResult<IEnumerable<PointOfIntrestDto>>> GetPointOfIntrest(int cityId, int pointOfIntrestId)
        {
            if (!await cityInfoRepository.CityExitsAsync(cityId))
            {
                _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of intrest.");
                return NotFound();
            }

            var PointsOfIntrest = await cityInfoRepository.GetPointOfIntrestForCityAsync(cityId, pointOfIntrestId);

            if (PointsOfIntrest == null) return NotFound();

           

            return Ok(Mapper.Map<PointOfIntrestDto>(PointsOfIntrest));
        }


        [HttpPost]
        public  async Task<ActionResult<IEnumerable<PointOfIntrestDto>>> CreatePointOfIntrest(int cityId, PointOfIntrestCreationDto pointOfIntrestCreation)
        {
            if (!await cityInfoRepository.CityExitsAsync(cityId))
            {
                _logger.LogInformation($"City with id {cityId} wasn't found");
                return NotFound();
            }



            var finalPointOfIntrest = Mapper.Map<Entities.PointOfIntrest>(pointOfIntrestCreation);

            await cityInfoRepository.AddPointsOfIntrestForCityAsync(cityId, finalPointOfIntrest);
            await cityInfoRepository.SaveChangesAsync();
            var createdPointOfInterest = Mapper.Map<Models.PointOfIntrestDto>(finalPointOfIntrest);

            return CreatedAtRoute("GetPointOfIntrest",
                new
                {
                    CityId = cityId,
                    PointOfIntrestId = createdPointOfInterest.Id

                },
                createdPointOfInterest);
           
        }
    }
}