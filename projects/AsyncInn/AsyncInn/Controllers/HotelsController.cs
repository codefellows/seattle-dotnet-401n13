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
    public class HotelsController : ControllerBase
    {
        private readonly IHotelManager _hotel;

        public HotelsController(IHotelManager hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<List<Hotel>> GetHotels()
        {
            return await _hotel.GetHotels();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel([FromRoute] int id)
        {
            var hotel = await _hotel.GetHotel(id);
            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel([FromRoute] int id, [FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel.ID)
            {
                return BadRequest();
            }

            await _hotel.UpdateHotel(hotel);

            return NoContent();
        }

        // POST: api/Hotels
        [HttpPost]
        public async Task<IActionResult> PostHotel([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hotel.CreateHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hotel.DeleteHotel(id);

            return Ok();
        }
    }
}