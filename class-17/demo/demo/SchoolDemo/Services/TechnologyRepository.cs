using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SchoolDemo.Services
{
  public class TechnologyRepository : ITechnology
  {
    private SchoolDbContext _context;

    public TechnologyRepository(SchoolDbContext context)
    {
      _context = context;
    }
    public async Task<Technology> Create(Technology technology)
    {
      _context.Entry(technology).State = Microsoft.EntityFrameworkCore.EntityState.Added;
      await _context.SaveChangesAsync();
      return technology;
    }

    public async Task<Technology> GetOne(int id)
    {
      Technology technology = await _context.Technologies.FindAsync(id);
      return technology;
    }

    public async Task<List<Technology>> GetAll()
    {
      var technology = await _context.Technologies.ToListAsync();
      return technology;
    }

    public async Task<Technology> Update(int id, Technology technology)
    {
      _context.Entry(technology).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      await _context.SaveChangesAsync();
      return technology;
    }

    public async Task Delete(int id)
    {
      Technology technology = await GetOne(id);
      _context.Entry(technology).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

  }
}
