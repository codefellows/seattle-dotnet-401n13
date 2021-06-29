using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private HotelDbContext _context;
        private IRoomManager _room;

        public HotelRoomRepository(HotelDbContext context, IRoomManager room)
        {
            _context = context;
            _room = room;
        }
        public async Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId)
        {
            hotelRoom.HotelID = hotelId;
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        public async Task Delete(int roomNumber, int hotelId)
        {
            var hotelRoom = await GetSingleHotelRoom(roomNumber, hotelId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            List<HotelRoom> hotelRooms = await _context.HotelRooms.Where(x => x.HotelID == hotelId)
                                                                    .Include(x => x.Room)
                                                                    .ToListAsync();

            return hotelRooms;
        }

        public async Task<HotelRoom> GetSingleHotelRoom(int roomNumber, int hotelId)
        {
            // hello linq
            //var hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomNumber);

            // magic linq stuff
            var room = await _context.HotelRooms.Where(x => x.HotelID == hotelId && x.RoomNumber == roomNumber)
                                                 .Include(x => x.Hotel)
                                                 .Include(x => x.Room)
                                                 .FirstOrDefaultAsync();

            // Find the rooomId and then call _room.GetRoom(id) to retrieve the room details and the amenityt details
            // RoomDTO roomdto = await _room.GetRoom(room.RoomID);
            /// set dto.Room = roomdto

            return room;
        }

        public async Task Update(HotelRoom hotelroom)
        {
            _context.Entry(hotelroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}
