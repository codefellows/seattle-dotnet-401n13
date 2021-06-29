using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [Required]
        [Display(Name = "Name of Hotel:")]
        public int HotelID { get; set; }

        [Required]
        
        [Display(Name = "Room Type")]
        public int RoomID { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        
        public int RoomNumber { get; set; }

        [Required]
        [Display(Name = "Nightly Rate of Stay")]
        public decimal Rate { get; set; }

        [Required]
        [Display(Name = "Is this Hotel Room Pet Friendly?")]
        public bool PetFriendly { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }

    }
}
