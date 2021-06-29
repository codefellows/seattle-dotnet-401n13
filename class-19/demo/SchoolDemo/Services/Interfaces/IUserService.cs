using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolDemo.Models;
using SchoolDemo.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolDemo.Services.Interfaces
{
  public interface IUserService
  {
    public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);

    public Task<UserDto> Authenticate(string username, string password);

    public Task<UserDto> GetUser(ClaimsPrincipal user);

  }
}
