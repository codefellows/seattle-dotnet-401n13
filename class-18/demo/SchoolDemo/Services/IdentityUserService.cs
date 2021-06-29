using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolDemo.Models;
using SchoolDemo.Models.Api;
using SchoolDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Services
{
  public class IdentityUserService : IUserService
  {
    private UserManager<ApplicationUser> userManager;

    public IdentityUserService(UserManager<ApplicationUser> manager)
    {
      userManager = manager;
    }

    public async Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState)
    {
      // throw new NotImplementedException();
      var user = new ApplicationUser
      {
        UserName = data.Username,
        Email = data.Email,
        PhoneNumber = data.PhoneNumber
      };

      var result = await userManager.CreateAsync(user, data.Password);

      if (result.Succeeded)
      {
        return new UserDto
        {
          Id = user.Id,
          Username = user.UserName
        };
      }

      // What about our errors?
      foreach (var error in result.Errors)
      {
        var errorKey =
            error.Code.Contains("Password") ? nameof(data.Password) :
            error.Code.Contains("Email") ? nameof(data.Email) :
            error.Code.Contains("UserName") ? nameof(data.Username) :
            "";
        modelState.AddModelError(errorKey, error.Description);
      }

      return null;

    }

    public async Task<UserDto> Authenticate(string username, string password)
    {
      var user = await userManager.FindByNameAsync(username);

      if (await userManager.CheckPasswordAsync(user, password))
      {
        return new UserDto
        {
          Id = user.Id,
          Username = user.UserName,
        };
      }

      return null;
    }

  }
}
