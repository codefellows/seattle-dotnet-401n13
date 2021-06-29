using FormsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsDemo.Controllers
{
  public class HomeController : Controller
  {

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    // Weakly Typed Form -- no moddel, just named params
    public IActionResult FormTest(string firstname, string lastname)
    {
      ViewData.Add("first", firstname);
      ViewData.Add("last", lastname);
      return View();
    }


    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }


    [HttpPost]
    public IActionResult Add(Dog dog)
    {

      if (!ModelState.IsValid) { return View(dog); }

      return Content("Dog Added");

    }

    public IActionResult Edit()
    {
      Dog dog = new Dog()
      {
        Name = "Rosie",
        Breed = "Mutt"
      };

      return View(dog);
    }

    [HttpPost]
    public IActionResult Update()
    {
      return null;
    }


  }
}
