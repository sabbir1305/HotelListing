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

namespace HotelListing
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork , ILogger<HotelController> logger , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.HotelsRepo.GetAll();
                var mappedHotels = _mapper.Map<List<HotelDto>>(hotels);

                return Ok(mappedHotels);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHotels)}");
                return StatusCode(500, "Internal server error. Please try agan later");
            }
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel =  await _unitOfWork.HotelsRepo.Get(x => x.Id == id,new List<string> {"Rooms"});
                var mappedHotel = _mapper.Map<HotelDto>(hotel);
                return Ok(mappedHotel);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHotel)}");
                return StatusCode(500, "Internal server error. Please try agan later");
            }
        }


    }
}
