using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models.Dto
{

    public class CreateCountryDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }
    }

    public class CountryDto : CreateCountryDto
    {
        public int Id { get; set; }

        public IList<HotelDto> Hotels { get; set; }

    }
}
