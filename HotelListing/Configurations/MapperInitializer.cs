using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configurations
{
    public class MapperInitializer:Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
