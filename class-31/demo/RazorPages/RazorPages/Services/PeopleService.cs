using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Services
{
  public class PeopleService : IPerson
  {
    // Identify the need for context
    private DemoDbContext _context;

    // Constructor make the context available
    public PeopleService(DemoDbContext ctx)
    {
      _context = ctx;
    }

    public async Task<Person> Create(Person person)
    {
      _context.Entry(person).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return person;
    }

    public async Task<List<Person>> GetAll()
    {
      return await _context.People.ToListAsync();
    }
  }
}
