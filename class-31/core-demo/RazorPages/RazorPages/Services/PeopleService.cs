using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Services
{
  public class PeopleService : IPerson
  {

    private DemoDbContext _context;

    public PeopleService(DemoDbContext context)
    {
      _context = context;
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
