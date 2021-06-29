using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomRepository : IRoomManager
    {
        private HotelDbContext _context;
        private IAmenityManager _amenities;

        public RoomRepository(HotelDbContext context, IAmenityManager amenities)
        {
            _context = context;
            _amenities = amenities;
        }
        public async Task<RoomDTO> CreateRoom(RoomDTO dto)
        {
            // convert a roomdto to a room entity. 

            Enum.TryParse(dto.Layout, out Layout layout);
            Room room = new Room()
            {
                Name = dto.Name,
                Layout = layout
            };

            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();

            dto.ID = room.ID;
            return dto;
        }

        public async Task DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);

            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            var room = await _context.Rooms.Where(x => x.ID == id)
                                            .Include(x => x.RoomAmenities)
                                            .FirstOrDefaultAsync();

            RoomDTO dto = new RoomDTO
            {
                Name = room.Name,
                Layout = room.Layout.ToString(),
                ID = room.ID
            };

            dto.Amenities = new List<AmenityDTO>();
            foreach (var item in room.RoomAmenities)
            {
                dto.Amenities.Add(await _amenities.GetAmentity(item.AmenitiesID));
            }

            // Convert the whole Room a RoomDTO
            // some foreach loop
            // for every amentity thats in there call
            //  _amenities.GetAmentity(id)
            // which will return you a DTO
            return dto;
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            List<RoomDTO> dtos = new List<RoomDTO>();

            foreach (var room in rooms)
            {
                dtos.Add(await GetRoom(room.ID));
            }

            return dtos;
        }

        public async Task UpdateRoom(RoomDTO dto)
        {
            // convert the roomDTO to a room entity
            Enum.TryParse(dto.Layout, out Layout layout);

            Room room = new Room()
            {
                Layout = layout,
                Name = dto.Name,
                ID = dto.ID,
            };
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Add AMenity To Room
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities amenity = new RoomAmenities
            {
                AmenitiesID = amenityId,
                RoomID = roomId
            };

            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var amenity = await _context.RoomAmenities.FindAsync(roomId, amenityId);

            if (amenity != null)
            {
                _context.Entry(amenity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
