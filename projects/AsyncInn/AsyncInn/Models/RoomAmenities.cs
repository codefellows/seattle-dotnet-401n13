using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [Required]
        [Display(Name = "Amenity Name: ")]
        public int AmenitiesID { get; set; }

        [Required]
        [Display(Name = "Room Type: ")]
        public int RoomID { get; set; }

        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}
