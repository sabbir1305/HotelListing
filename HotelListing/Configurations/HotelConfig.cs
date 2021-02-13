using HotelListing.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configurations
{
    public class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
          new Hotel
          {
              Id = 1,
              Address = "Dhaka , Metro",
              CountryId = 1,
              Name = "Panpacific Sonargaon",
              Rating = 3.5
          },
             new Hotel
             {
                 Id = 2,
                 Address = "Dhaka , Metro",
                 CountryId = 1,
                 Name = "Westin",
                 Rating = 4.5
             },
                new Hotel
                {
                    Id = 3,
                    Address = "Dhaka , Metro",
                    CountryId = 2,
                    Name = "Grand Paladin",
                    Rating = 5
                }
          );

        }
    }
}
