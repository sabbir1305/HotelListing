using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class Room
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public double Price { get; set; }

        public int GuestsAllowed { get; set; }

        public string RoomType { get; set; }
    }
}
