using CookiesDemo.Auth.Models.Dto;
using CookiesDemo.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CookiesDemo.Controllers
{


  public class LoginController : Controller
  {

    private IUserService userService;

    public LoginController(IUserService service)
    {
      userService = service;
    }

    // ROUTES
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Welcome()
    {
      return View();
    }

    public IActionResult Signup()
    {
      return View();
    }


    // Takes a post to "/register"
    [HttpPost]
    public async Task<ActionResult<UserDto>> Signup(RegisterUser data)
    {
      // Hardcoding FTW
      data.Roles = new List<string>() { "guest" };

      var user = await userService.Register(data, this.ModelState);
      if (ModelState.IsValid)
      {
        return Redirect("/login/welcome");
      }

      return View();
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Authenticate(LoginData data)
    {
      var user = await userService.Authenticate(data.Username, data.Password);

      if (user == null)
      {
        this.ModelState.AddModelError(String.Empty, "Invalid Login");
        return RedirectToAction("Index");
      }

      return Redirect("/login/welcome");
    }

    // Whoa! New annotation that will be able to Read the bearer token
    // and return a user based on the claim/principal within...
    // [Authorize]
    // [Authorize(Roles = "Guest")]
    [Authorize(Policy = "read")]
    public async Task<ActionResult<UserDto>> Me()
    {
      return View();
    }

  }

}

