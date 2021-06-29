using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsDemo.Models
{
  public class Dog
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Breed { get; set; }
    [Required]
    public string Owner { get; set; }
  }
}
