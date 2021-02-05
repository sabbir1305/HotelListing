using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name="Bangladesh",
                    ShortName="BN"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "Japan",
                     ShortName = "JPM"
                 },
                  new Country
                  {
                      Id = 3,
                      Name = "Nepal",
                      ShortName = "Np"
                  }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id=1,
                    Address="Dhaka , Metro",
                    CountryId=1,
                    Name="Panpacific Sonargaon",
                    Rating=3.5
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
