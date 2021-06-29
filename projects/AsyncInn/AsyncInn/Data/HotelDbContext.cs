using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite key associations
            // fluid API
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelID, hr.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.RoomID, ce.AmenitiesID });

            // Seeding basic data into the database
            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, Name = "Seahawks Snooze", Layout = Layout.TwoBedSuite },
                new Room { ID = 2, Name = "Restful Rainier", Layout = Layout.TwoBedSuite },
                new Room { ID = 3, Name = "Couples Retreat", Layout = Layout.OneBedSuite },
                new Room { ID = 4, Name = "Officially Business", Layout = Layout.Studio },
                new Room { ID = 5, Name = "The Playhouse", Layout = Layout.TwoBedSuite },
                new Room { ID = 6, Name = "The Staycation", Layout = Layout.OneBedSuite }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { ID = 1, Name = "Emerald City Stay", Address = "123 Seattle Way", Phone = "123-456-7654" },
                new Hotel { ID = 2, Name = "Las Vegas Strip", Address = "123 LasVegas Strip Way", Phone = "123-876-1946" },
                new Hotel { ID = 3, Name = "Disney Adventures", Address = "987 Dizney Way", Phone = "481-512-3421" },
                new Hotel { ID = 4, Name = "Pirates Life", Address = "84 Treasure Way", Phone = "975-588-9621" },
                new Hotel { ID = 5, Name = "Grand Excursion", Address = "123 Fancy Way", Phone = "493-396-9785" }
                );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities { ID = 1, Name = "Mini Bar" },
                new Amenities { ID = 2, Name = "Coffee Maker" },
                new Amenities { ID = 3, Name = "Jacuzzi Tub" },
                new Amenities { ID = 4, Name = "Netflix" },
                new Amenities { ID = 5, Name = "Petting Zoo" }
                );
        }

        // Creating basic tables
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public DbSet<Room> Rooms { get; set; }





    }
}
