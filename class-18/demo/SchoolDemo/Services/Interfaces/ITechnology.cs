using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Services.Interfaces
{
  public interface ITechnology
  {
    // Create
    Task<Technology> Create(Technology technology);

    // Read

    // Get all
    Task<List<Technology>> GetAll();

    // Get one by id
    Task<Technology> GetOne(int id);

    // Update
    Task<Technology> Update(int id, Technology technology);

    // Delete
    Task Delete(int id);

  }
}
