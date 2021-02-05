using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models.Dto
{
     public class CreateHotelDto
    {

        public string Name { get; set; }
        public string Address { get; set; }

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }
        public int CountryId { get; set; }
    }
    public class HotelDto : CreateHotelDto
    {
        public int Id { get; set; }
       public CountryDto Country { get; set; }
        public IList<RoomDto> Rooms { get; set; }
    }
}
