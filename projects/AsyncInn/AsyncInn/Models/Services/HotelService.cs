using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotelManager
    {
        private HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int id)
        {
            var hotel = await GetHotel(id);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotel = await _context.Hotels.Where(x => x.ID == id)
                                             .Include(x => x.HotelRooms)
                                             .ThenInclude(x => x.Room)
                                             .ThenInclude(x => x.RoomAmenities)
                                             .ThenInclude(x => x.Amenities)
                                             .FirstOrDefaultAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
