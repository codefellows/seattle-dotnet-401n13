using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }


    public IActionResult Hello()
    {
      return View();
    }
  }
}
