using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Interfaces
{
  public interface ITechnology
  {
    // CREATE
    Task<Technology> Create(Technology technology);

    // GET ALL

    Task<List<Technology>> GetTechnologies();

    // GET ONE BY ID
    Task<Technology> GetTechnology(int id);

    // UPDATE
    Task<Technology> UpdateTechnology(int id, Technology technology);

    // DELETE
    Task Delete(int id);

  }
}
