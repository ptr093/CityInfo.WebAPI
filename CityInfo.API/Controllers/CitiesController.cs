using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository cityInfoRepository;

        public ILogger<CitiesController> _logger { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()
        {
            var cityEntities = await cityInfoRepository.GetCitiesAsync();

            return Ok(Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
        }
        public CitiesController(ILogger<CitiesController> logger, ICityInfoRepository cityInfoRepository,IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id,bool includePointsOfIntrest=false)
        {


            var CityToReturn = await cityInfoRepository.GetCityAsync(id,includePointsOfIntrest);



            if (CityToReturn == null)
            {
                _logger.LogWarning($"The given cityid: {id} does not exist ");
                return NotFound();
            }

            if(includePointsOfIntrest)
            {
                return Ok(Mapper.Map<CityDto>(CityToReturn));
            }



            return Ok(Mapper.Map<CityWithoutPointsOfInterestDto>(CityToReturn));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CityCreationDto>>> CreatePointOfIntrest(CityCreationDto  cityCreation)
        {
           



            var finalPointOfIntrest = Mapper.Map<Entities.City>(cityCreation);

            await cityInfoRepository.AddNewCity(finalPointOfIntrest);
            await cityInfoRepository.SaveChangesAsync();
            var createdPointOfInterest = Mapper.Map<Models.CityWithoutPointsOfInterestDto>(finalPointOfIntrest);

        
            return Ok();
        }


    }
}