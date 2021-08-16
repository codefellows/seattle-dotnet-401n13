using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
  public class PetsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Dog(string name, string  breed, int age)
    {
      Dog rosie = new Dog()
      {
        Name = name, 
        Breed = breed,
        Age = age
      };

      return View(rosie);
    }

    public IActionResult Dogs()
    {


      List<Dog> dogs = new List<Dog>();
      dogs.Add(new Dog() { Name = "Rosie", Breed= "Lab/Boxer", Age = 6 });
      dogs.Add(new Dog() { Name = "Rocky", Breed= "Border Collie", Age = 13 });
      dogs.Add(new Dog() { Name = "Axl", Breed= "Dane", Age = 4 });
      dogs.Add(new Dog() { Name = "Luna", Breed= "Dane", Age = 2 });

      return View(dogs);
    }
  }
}
