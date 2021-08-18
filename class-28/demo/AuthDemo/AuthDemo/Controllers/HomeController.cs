using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo.Controllers
{
  public class HomeController : Controller
  {
    [Authorize]
    public IActionResult Index()
    {
      return View();
    }

    // http://localhost:1234/Home/Remember?name=foofoo
    public IActionResult Remember(string name)
    {
      if(name != null)
      {
        // Set a cookie with the name in it...
        CookieOptions cookieOptions = new CookieOptions();
        // Cookie expires in 7 days
        cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
        HttpContext.Response.Cookies.Append("name", name, cookieOptions);
        return Content("Ok, Saved It");
      }

      return Content("Please provide a name");

    }

    [Authorize(Roles="Administrator")]
    public IActionResult Iam()
    {
      // app.get('/home/iam', (req,res) => {});
      string name = HttpContext.Request.Cookies["name"];
      ViewData["name"] = name;
      return View();
    }
  }
}
