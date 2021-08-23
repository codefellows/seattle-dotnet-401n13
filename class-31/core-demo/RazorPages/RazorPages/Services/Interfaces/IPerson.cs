using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Services.Interfaces
{
  public interface IPerson
  {
    Task<Person> Create(Person person);

    Task<List<Person>> GetAll();
  }
}
