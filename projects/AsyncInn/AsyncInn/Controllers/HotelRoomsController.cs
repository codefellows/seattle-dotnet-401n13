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

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/Hotel/4/rooms
        [HttpGet, Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            return await _hotelRoom.GetHotelRooms(hotelId);
        }

        // GET: api/HotelRooms/5
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int roomNumber, int hotelId)
        {
            var hotelRoom = await _hotelRoom.GetSingleHotelRoom(roomNumber, hotelId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelID || roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            //update
            await _hotelRoom.Update(hotelRoom);

            return NoContent();
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost, Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom, int hotelId)
        {
            await _hotelRoom.Create(hotelRoom, hotelId);
            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelID }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int roomNumber, int hotelId)
        {
            await _hotelRoom.Delete(roomNumber, hotelId);

            return NoContent();
        }
    }
}
