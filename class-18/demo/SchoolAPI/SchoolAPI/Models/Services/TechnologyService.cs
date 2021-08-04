using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using SchoolAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Services
{
  public class TechnologyService : ITechnology
  {
    private SchoolDbContext _context;

    public TechnologyService(SchoolDbContext context)
    {
      _context = context;
    }
    public async Task<Technology> Create(Technology technology)
    {
      // technology is an instance of Sudent
      // the current state of the technology object: raw

      _context.Entry(technology).State = EntityState.Added;
      // the current state of the technology object: added

      await _context.SaveChangesAsync();

      return technology;
    }


    public async Task<List<Technology>> GetTechnologies()
    {
      var technologies = await _context.Technologies.ToListAsync();
      return technologies;
    }

    public async Task<Technology> GetTechnology(int id)
    {
      Technology technology = await _context.Technologies.FindAsync(id);
      return technology;
    }

    public async Task<Technology> UpdateTechnology(int id, Technology technology)
    {
      _context.Entry(technology).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return technology;
    }

    public async Task Delete(int id)
    {
      Technology technology = await GetTechnology(id);
      _context.Entry(technology).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }



  }
}
