using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager , 
            SignInManager<ApiUser> signInManager,
            ILogger<AccountController> logger,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDto);
                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDto.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
        }


        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDto userDto)
        //{
        //    _logger.LogInformation($"Login attempt for {userDto.Email}");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
              
        //        var result = await _signInManager.PasswordSignInAsync(userDto.Email,userDto.Password,false,false);

        //        if (!result.Succeeded)
        //        {

        //            return Unauthorized(userDto);
        //        }
        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
        //        return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
        //    }
        //}


    }
}
