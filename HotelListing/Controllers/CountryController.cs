using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _imapper;
        private readonly ILogger<CountryController> _logger;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger , IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _imapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries =await _unitOfWork.CoutiresRepo.GetAll();
                var mappedCountry = _imapper.Map<List<CountryDto>>(countries);
                return Ok(mappedCountry);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal server error. Please try again later");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.CoutiresRepo.Get(q=>q.Id==id,new List<string> { "Hotels"});
                var mappedCountry = _imapper.Map<CountryDto>(country);
                return Ok(mappedCountry);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCountry)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }
    }
}
