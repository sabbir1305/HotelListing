using HotelListing.Configurations;
using HotelListing.Data;
using HotelListing.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services
{
    public class AuthCustomManager : IAuthCustomManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private  ApiUser _user;

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions =  GenerateTokenOptions(signingCredentials,claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var experation = DateTime.Now.AddMinutes(Convert.ToInt32(jwtSettings.GetSection("LifeTime").Value));
            var options = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: experation,
                signingCredentials:signingCredentials
                );
            return options;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
           {

               new Claim(ClaimTypes.Name,_user.UserName)

           };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = SecurityJWTKey.KEY;
            var IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha512);
        }

        public async Task<bool> ValidateUser(LoginDto loginDto)
        {
             _user = await _userManager.FindByNameAsync(loginDto.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password));
        }
    }
}
