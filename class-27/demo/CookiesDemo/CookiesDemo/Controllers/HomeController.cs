using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesDemo.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index(string name)
    {
      if (name != null)
      {
        CookieOptions cookieOptions = new CookieOptions();
        cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
        HttpContext.Response.Cookies.Append("name", name, cookieOptions);
      }

      return View();
    }

    public IActionResult Me()
    {
      string name = HttpContext.Request.Cookies["name"];

      ViewData["name"] = name;

      return View();
    }


  }
}
