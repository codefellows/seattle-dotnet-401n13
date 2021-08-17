using FormDemo.Models;
using FormDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormDemo.Controllers
{
  public class HomeController : Controller
  {

    private readonly IPet _petService;
    public HomeController(IPet p)
    {
      _petService = p;
    }

    public async Task<ActionResult<IEnumerable<Pet>>> Index()
    {
      var list = await _petService.GetAll();
      return View(list);
    }



    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Pet pet)
    {
      await _petService.Create(pet);
      if(!ModelState.IsValid) { return View(); }
      return Content("Pet was added");
    }

    [HttpGet]
    public async Task<IActionResult> Edit( int id )
    {
      // looked up a pet from the db by id ...
      Pet pet = await _petService.GetOne(id);
      return View(pet);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Pet pet)
    {
      await _petService.Update(pet);
      if(!ModelState.IsValid) { return View();  }
      return Content("Pet was Updated");
    }
  }
}
