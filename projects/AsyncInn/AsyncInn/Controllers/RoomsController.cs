using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomManager _room;

        public RoomsController(IRoomManager room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return await _room.GetRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            await _room.UpdateRoom(room);
            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            await _room.CreateRoom(room);

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);

            return NoContent();
        }

        [HttpPost, Route("{roomId}/Amenity/{amenityId}")]
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
        }
    }
}
