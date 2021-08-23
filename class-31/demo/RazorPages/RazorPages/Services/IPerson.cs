using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Services
{
  public interface IPerson
  {
    // Create a new person

    Task<Person> Create(Person person);

    // Get all the people
    Task<List<Person>> GetAll();
  }
}
