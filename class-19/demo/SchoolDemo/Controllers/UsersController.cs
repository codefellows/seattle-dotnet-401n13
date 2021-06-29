using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolDemo.Models;
using SchoolDemo.Models.Api;
using SchoolDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService userService;

    public UsersController(IUserService service)
    {
      userService = service;
    }

    // ROUTES

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterUser data)
    {
      // Note: data (RegisterUser) comes from an inbound DTO/Model created for this purpose
      // this.ModelState?  This comes from MVC Binding and shares an interface with the Model
      var user = await userService.Register(data, this.ModelState);
      if (ModelState.IsValid)
      {
        return user;
      }

      return BadRequest(new ValidationProblemDetails(ModelState));
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginData data)
    {
      var user = await userService.Authenticate(data.Username, data.Password);

      if (user == null)
      {
        return Unauthorized();
      }

      return user;
    }

    // Whoa! New annotation that will be able to Read the bearer token
    // and return a user based on the claim/principal within...
    [Authorize(Roles ="Editor")]
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> Me()
    {
      // Following the [Authorize] phase, this.User will be ... you.
      // Put a breakpoint here and inspect to see what's passed to our getUser method
      return await userService.GetUser(this.User);
    }
  }
}
