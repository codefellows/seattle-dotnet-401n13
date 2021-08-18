using AuthDemo.Auth.Models.Dto;
using AuthDemo.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo.Controllers
{
  public class AuthController : Controller
  {

    // Use DI to bring in the user service
    private IUserService userService;

    public AuthController(IUserService service)
    {
      userService = service;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Signup()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Signup(RegisterUser data)
    {
      // Hardcode the role(s)
      data.Roles = new List<string>() { "guest" };

      // Create a user with the user service
      var user = await userService.Register(data, this.ModelState);

      if(ModelState.IsValid)
      {
        return Redirect("/");
      }

      return View();
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Authenticate(LoginData data)
    {
      // Check with the user service to ... see if we're in the system
      var user = await userService.Authenticate(data.Username, data.Password);
      if(user == null)
      {
        this.ModelState.AddModelError(String.Empty, "Invalid Login");
        return RedirectToAction("Index");
      }

      return Redirect("/");
    }
  }
}
