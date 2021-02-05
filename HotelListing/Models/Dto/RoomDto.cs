using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models.Dto
{
    public class CreateRoomDto
    {

        public int HotelId { get; set; }
  

        public double Price { get; set; }

        public int GuestsAllowed { get; set; }

        public string RoomType { get; set; }
       
    }
    public class RoomDto : CreateRoomDto
    {
        public int Id { get; set; }

        public HotelDto Hotel { get; set; }

    }
}
