using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TechnologiesController : ControllerBase
  {
    // _technology is "technology serivce" which uses the actual db context
    private readonly ITechnology _technology;

    public TechnologiesController(ITechnology s)
    {
      _technology = s;
    }

    // GET: api/Technologies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Technology>>> GetTechnologies()
    {
      // You should count the list ...
      var list = await _technology.GetTechnologies();
      return Ok(list);
    }

    // GET: api/Technologies/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Technology>> GetTechnology(int id)
    {
      Technology technology = await _technology.GetTechnology(id);
      return technology;
    }

    // PUT: api/Technologies/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTechnology(int id, Technology technology)
    {
      if (id != technology.Id)
      {
        return BadRequest();
      }

      var updatedTechnology = await _technology.UpdateTechnology(id, technology);

      return Ok(updatedTechnology);
    }

    // POST: api/Technologies
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Technology>> PostTechnology(Technology technology)
    {
      await _technology.Create(technology);

      // Return a 201 Header to browser
      // The body of the request will be us running GetTechnology(id);
      return CreatedAtAction("GetTechnology", new { id = technology.Id }, technology);
    }

    // DELETE: api/Technologies/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnologies(int id)
    {
      await _technology.Delete(id);
      return NoContent();
    }

  }
}
