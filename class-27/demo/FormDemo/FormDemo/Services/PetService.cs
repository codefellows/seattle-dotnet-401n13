using FormDemo.Data;
using FormDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormDemo.Services
{
  public class PetService : IPet
  {

    private AnimalsDbContext _context;

    public PetService(AnimalsDbContext context)
    {
      _context = context;
    }

    public async Task<Pet> Create(Pet pet)
    {
      _context.Entry(pet).State = Microsoft.EntityFrameworkCore.EntityState.Added;
      await _context.SaveChangesAsync();
      return pet;
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Pet>> GetAll()
    {
      return await _context.Pets.ToListAsync();
    }

    public async Task<Pet> GetOne(int id)
    {
      Pet pet = await _context.Pets.FindAsync(id);
      return pet;
    }

    public async Task<Pet> Update(Pet pet)
    {
      _context.Entry(pet).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return pet;
    }
  }
}
