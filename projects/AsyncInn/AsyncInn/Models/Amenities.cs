using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a name")]
        [Display(Name = "Amenity Name:")]
        public string Name { get; set; }

        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
