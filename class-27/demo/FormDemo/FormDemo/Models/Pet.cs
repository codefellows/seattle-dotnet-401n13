using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormDemo.Models
{
  public class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Owner { get; set; }

    public PetType Type { get; set; }

  }

  public enum PetType
  {
    Cat,
    Dog,
    Hamster
  }
}
