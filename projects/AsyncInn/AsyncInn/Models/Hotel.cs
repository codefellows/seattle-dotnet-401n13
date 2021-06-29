using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Hotel Address: ")]
        public string Address { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
