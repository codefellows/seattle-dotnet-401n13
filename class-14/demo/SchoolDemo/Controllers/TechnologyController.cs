using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Models.Interfaces;

namespace SchoolDemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TechnologiesController : ControllerBase
  {
    private readonly ITechnology _technology;

    public TechnologiesController(ITechnology technology)
    {
      _technology = technology;
    }

    // GET: api/Technologies
    [HttpGet]
    public async Task<IActionResult> GetTechnologies()
    {
      return Ok(await _technology.GetAll());
    }

    // GET: api/Technologies/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Technology>> GetTechnology(int id)
    {
      Technology technology = await _technology.GetOne(id);
      return technology;
    }

    // PUT: api/Technologies/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTechnology(int id, Technology technology)
    {
      if (id != technology.Id)
      {
        return BadRequest();
      }

      var updatedTechnology = await _technology.Update(id, technology);

      return Ok(updatedTechnology);

    }

    // POST: api/Technologies
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Technology>> PostTechnology(Technology technology)
    {
      await _technology.Create(technology);
      // Returns a 201 Header
      // The body will be the result of calling GetTechnology with the id
      return CreatedAtAction("GetTechnology", new { id = technology.Id }, technology);
    }

    // DELETE: api/Technologies/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTechnology(int id)
    {
      await _technology.Delete(id);
      return NoContent();
    }
  }
}
