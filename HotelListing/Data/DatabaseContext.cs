using HotelListing.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());


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

            builder.ApplyConfiguration(new HotelConfig());
      
            builder.Entity<Room>().HasData(
           new Room
           {
               Id = 1,
               GuestsAllowed=5,
               HotelId=1,
               Price=25000,
               RoomType="Delux, for five people"

             
           },
             new Room
             {
                 Id = 2,
                 GuestsAllowed = 2,
                 HotelId = 2,
                 Price = 25000,
                 RoomType = "VIP Lounge"


             }


           );
        }
    
    }
}
